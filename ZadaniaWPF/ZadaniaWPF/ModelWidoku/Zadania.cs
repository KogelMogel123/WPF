using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
namespace ZadaniaWPF.ModelWidoku
{
    public class Zadania
    {
        private const string ścieżkaPlikuXml = "zadania.xml";
        //przechowywanie dwóch kolekcji
        private Model.Zadania model;
        public ObservableCollection<Zadanie> ListaZadań { get; } =
        new ObservableCollection<Zadanie>();
        private void KopiujZadania()
        {
            ListaZadań.CollectionChanged -= SynchronizacjaModelu;
            ListaZadań.Clear();
            foreach (Model.Zadanie zadanie in model)
                ListaZadań.Add(new Zadanie(zadanie));
            ListaZadań.CollectionChanged += SynchronizacjaModelu;
        }
        public Zadania()
        {
            if (System.IO.File.Exists(ścieżkaPlikuXml))
                model = Model.PlikXml.Czytaj(ścieżkaPlikuXml);
            else model = new Model.Zadania();
            //testy – początek
            model.DodajZadanie(new Model.Zadanie("Pierwsze", DateTime.Now,
                DateTime.Now.AddDays(2), Model.PriorytetZadania.Ważne));
            model.DodajZadanie(new Model.Zadanie("Drugie", DateTime.Now,
                DateTime.Now.AddDays(2), Model.PriorytetZadania.Ważne));
            model.DodajZadanie(new Model.Zadanie("Trzecie", DateTime.Now,
                DateTime.Now.AddDays(1), Model.PriorytetZadania.MniejWażne));
            model.DodajZadanie(new Model.Zadanie("Czwarte", DateTime.Now,
                DateTime.Now.AddDays(3), Model.PriorytetZadania.Krytyczne));
            model.DodajZadanie(new Model.Zadanie("Piąte", DateTime.Now, new
                DateTime(2015, 03, 15, 1, 2, 3), Model.PriorytetZadania.Krytyczne));
            model.DodajZadanie(new Model.Zadanie("Szóste", DateTime.Now, new
                DateTime(2015, 03, 14, 1, 2, 3), Model.PriorytetZadania.Krytyczne));
            //testy – koniec
            KopiujZadania();
        }
        private void SynchronizacjaModelu(object sender,
        NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Zadanie noweZadanie = (Zadanie)e.NewItems[0];
                    if (noweZadanie != null)
                        model.DodajZadanie(noweZadanie.GetModel());
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Zadanie usuwaneZadanie = (Zadanie)e.OldItems[0];
                    if (usuwaneZadanie != null)
                        model.UsuńZadanie(usuwaneZadanie.GetModel());
                    break;
            }
        }
    }
}