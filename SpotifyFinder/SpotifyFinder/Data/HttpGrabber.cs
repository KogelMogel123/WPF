using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyFinder.Model;

namespace SpotifyFinder.Data
{
    public class HttpGrabber
    {
        private string baseAdress = "https://swapi.co/api/";

        internal ObservableCollection<Result> SearchList = new ObservableCollection<Result>();  

        /// <summary>
        /// Serialize RootObject
        /// </summary>
        /// <returns></returns>
        public async Task MakeStringGreatAgain(string search)
        {
            RootObject root = new RootObject();
            try
            {
                root = JsonConvert.DeserializeObject<RootObject>(await GetFromStream(search));
            }
            catch(Exception ex)
            {
                var a = ex.Message.ToString();
            }
            try
            {
                SearchList.ToList().All(p => SearchList.Remove(p));
                foreach (var item in root.results) SearchList.Add(item);
            }
            catch
            {
                //just pass
            }
        }
        /// <summary>
        /// Get test data from http 
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetFromStream(string search)
        {
            string testRequest = search;

            try
            {
                var response = await GetRequestAsync(testRequest);

                using (var ResponseReader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    return await ResponseReader.ReadToEndAsync();
                }
            }
            catch (Exception)
            {
                //just pass
            }

            return testRequest;
        }
        /// <summary>
        /// Get HttpWebRequest
        /// </summary>
        /// <param name="testRequest"></param>
        /// <returns></returns>
        private async Task<WebResponse> GetRequestAsync(string testRequest)
        {
            try
            {
                var request = HttpWebRequest.CreateHttp(baseAdress + $"{testRequest}/ ");
                request.Method = WebRequestMethods.Http.Get;
                request.ContentType = "application/json; charset=utf-8";

                return await request.GetResponseAsync();
            }
            catch(WebException wex)
            {
                return wex?.Response as WebResponse;
            }
            catch(Exception ex)
            {
                
            }

            return null;
        }
    }
}
