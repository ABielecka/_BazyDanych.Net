﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace DatabaseW.DataViewModel.Osoby
{
    public class OsobyDataService
    {
        private List<Models.Osoby> _dataList = new List<Models.Osoby>();
        private bool _areDataLoaded = false;
        public event EventHandler DataLoaded;

        public List<Models.Osoby> DataList
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
                var data = App.Ctx.Osobies.Include("WojewodztwoZamieszkania")
                                          .OrderBy(k => k.Nazwisko)
                                          .ThenBy(k => k.Imie)
                                          .ThenBy(k => k.DataUrodzenia).ToList<Models.Osoby>();
                foreach (Models.Osoby us in data)
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
        public bool Save(Models.Osoby data)
        {
            try
            {
                App.Ctx.Osobies.Add(data);
                App.Ctx.SaveChanges();
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
        public bool Update(Models.Osoby data)
        {
            try
            {
                App.Ctx.Entry(data).State = EntityState.Modified;
                App.Ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public bool Remove(Models.Osoby data)
        {
            try
            {
                App.Ctx.Osobies.Remove(data);
                App.Ctx.SaveChanges();
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
