using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DatabaseW.DataViewModel.Najem
{
    public class NajemDataService
    {
        private List<Models.Najem> _dataList = new List<Models.Najem>();
        private bool _areDataLoaded = false;
        public event EventHandler DataLoaded;

        public List<Models.Najem> DataList
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
                var data = App.Ctx.Najems.OrderBy(k => k.IdWynajmu)
                                         .ToList<Models.Najem>();
                foreach (Models.Najem us in data)
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

        public bool Save(Models.Najem data)
        {
            try
            {
                App.Ctx.Najems.Add(data);
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

        public bool Update(Models.Najem data)
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

        public bool Remove(Models.Najem data)
        {
            try
            {
                App.Ctx.Najems.Remove(data);
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
