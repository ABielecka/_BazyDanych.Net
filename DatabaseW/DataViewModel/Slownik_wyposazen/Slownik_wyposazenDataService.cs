using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DatabaseW.DataViewModel.Slownik_wyposazen
{
    public class Slownik_wyposazenDataService
    {
        private List<Models.Slownik_wyposazen> _dataList = new List<Models.Slownik_wyposazen>();
        private bool _areDataLoaded = false;
        public event EventHandler DataLoaded;

        public List<Models.Slownik_wyposazen> DataList
        {
            get { return _dataList; }
            set { _dataList = value; }
        }

        public bool AreDataLoaded
        {
            get { return _areDataLoaded; }
            set { _areDataLoaded = value; }
        }

        protected void OnDataLoaded()
        {
            if (DataLoaded != null)
            {
                DataLoaded(null, EventArgs.Empty);
            }
        }

        public void LoadData()
        {
            try
            {
                _dataList.Clear();
                var data = App.Ctx.Slownik_Wyposazens.OrderBy(k => k.Opis).ToList<Models.Slownik_wyposazen>();
                foreach (Models.Slownik_wyposazen us in data)
                {
                    _dataList.Add(us);
                }
                OnDataLoaded();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool Save(Models.Slownik_wyposazen data)
        {
            try
            {
                App.Ctx.Slownik_Wyposazens.Add(data);
                App.Ctx.SaveChanges();
                _dataList.Add(data);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public bool Update(Models.Slownik_wyposazen data)
        {
            try
            {
                App.Ctx.Entry(data).State = EntityState.Modified;
                App.Ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public bool Remove(Models.Slownik_wyposazen data)
        {
            try
            {
                App.Ctx.Slownik_Wyposazens.Remove(data);
                App.Ctx.SaveChanges();
                _dataList.Remove(data);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
