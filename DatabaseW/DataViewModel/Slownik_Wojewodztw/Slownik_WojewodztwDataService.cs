using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DatabaseW.DataViewModel.Slownik_Wojewodztw
{
    public class Slownik_WojewodztwDataService
    {
        private List<Models.Slownik_Wojewodztw> _dataList = new List<Models.Slownik_Wojewodztw>();
        private bool _areDataLoaded = false;
        public event EventHandler DataLoaded;

        public List<Models.Slownik_Wojewodztw> DataList
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
                var data = App.Ctx.Slownik_Wojewodztws.OrderBy(k => k.NazwaWojewodztwa).ToList<Models.Slownik_Wojewodztw>();
                foreach (Models.Slownik_Wojewodztw us in data)
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
        public bool Save(Models.Slownik_Wojewodztw data)
        {
            try
            {
                App.Ctx.Slownik_Wojewodztws.Add(data);
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
        public bool Update(Models.Slownik_Wojewodztw data)
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
        public bool Remove(Models.Slownik_Wojewodztw data)
        {
            try
            {
                App.Ctx.Slownik_Wojewodztws.Remove(data);
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
