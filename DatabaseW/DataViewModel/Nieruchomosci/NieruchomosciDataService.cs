using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DatabaseW.DataViewModel.Nieruchomosci
{
    public class NieruchomosciDataService
    {
        private List<Models.Nieruchomosci> _dataList = new List<Models.Nieruchomosci>();
        private bool _areDataLoaded = false;
        public event EventHandler DataLoaded;

        public List<Models.Nieruchomosci> DataList
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
                var data = App.Ctx.Nieruchomoscis.OrderBy(k => k.IdNieruchomosci).ToList<Models.Nieruchomosci>();
                foreach (Models.Nieruchomosci us in data)
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

        public bool Save(Models.Nieruchomosci data)
        {
            try
            {
                App.Ctx.Nieruchomoscis.Add(data);
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

        public bool Update(Models.Nieruchomosci data)
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

        public bool Remove(Models.Nieruchomosci data)
        {
            try
            {
                App.Ctx.Nieruchomoscis.Remove(data);
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
