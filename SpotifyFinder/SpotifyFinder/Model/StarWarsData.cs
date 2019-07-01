using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyFinder.Model
{
    public class StarWarsData
    {
        public string name { get; set; }
        public string population { get; set; }
    }
    //json2csharp.com - stronka do robienia modelu z pliku json
    public class Result
    {
        public string name { get; set; }
        //public string rotation_period { get; set; }
        //public string orbital_period { get; set; }
        //public string diameter { get; set; }
        //public string climate { get; set; }
        //public string gravity { get; set; }
        //public string terrain { get; set; }
        //public string surface_water { get; set; }
        public string population { get; set; }
        //public List<object> residents { get; set; }
        //public List<string> films { get; set; }
        //public DateTime created { get; set; }
        //public DateTime edited { get; set; }
        //public string url { get; set; }
    }

    public class RootObject
    {
        //public int count { get; set; }
        //public string next { get; set; }
        //public object previous { get; set; }
        public List<Result> results { get; set; }
    }
}
