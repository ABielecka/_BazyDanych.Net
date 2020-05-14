using Property_rental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DatabaseW.DataViewModel.Typ_nieruchomosci
{
    public class Typ_nieruchomosciDataService
    {
        private List<Models.Typ_nieruchomosci> _dataList = new List<Models.Typ_nieruchomosci>();
        private bool _areDataLoaded = false;
        private Context _context;
        public event EventHandler DataLoaded;

        public Typ_nieruchomosciDataService(Context _ctx)
        {
            _context = _ctx;
        }

        public List<Models.Typ_nieruchomosci> DataList
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
                var data = _context.Typ_Nieruchomoscis.OrderBy(k => k.Opis).ToList<Models.Typ_nieruchomosci>();
                foreach (Models.Typ_nieruchomosci us in data)
                {
                    _dataList.Add(us);
                }
                OnDataLoaded();
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public bool Save(Models.Typ_nieruchomosci data)
        {
            try
            {
                _context.Typ_Nieruchomoscis.Add(data);
                _context.SaveChanges();
                _dataList.Add(data);

                return true;
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public bool Update(Models.Typ_nieruchomosci data)
        {
            try
            {
                _context.Entry(data).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public bool Remove(Models.Typ_nieruchomosci data)
        {
            try
            {
                _context.Typ_Nieruchomoscis.Remove(data);
                _context.SaveChanges();
                _dataList.Remove(data);

                return true;
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
    }
}
