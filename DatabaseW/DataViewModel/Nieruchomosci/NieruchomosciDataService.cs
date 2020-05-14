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
        private List<Models.Pokoje> _dataListPok = new List<Models.Pokoje>();

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

        #region Nieruchomosci
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
                var data = App.Ctx.Nieruchomoscis.Include("Pokoje")
                    .Include("Wyposazenie")
                    .Include("WojewodztwoNieruchomosci")
                    .Include("TypNieruchomosci")
                    .Include("OsobaWynajmujaca")
                    .Include("Pokoje")
                    .Include("Pokoje.Wyposazenie")
                    .OrderBy(k => k.IdNieruchomosci).ToList<Models.Nieruchomosci>();
                foreach (Models.Nieruchomosci us in data)
                {
                    _dataList.Add(us);
                }
                OnDataLoaded();
                App.loggerFile.Info("Poprawnie załadowana informacja.");
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
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
                App.loggerFile.Error(ex, "Error!");
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
                App.loggerFile.Error(ex, "Error!");
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
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        #region Wyposazenie nieruchomosci
        public bool Update(Models.Wyposazenie_nieruchomosci data)
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
        public bool Remove(Models.Wyposazenie_nieruchomosci data, long id)
        {
            try
            {
                App.Ctx.Wyposazenie_Nieruchomoscis.Remove(data);
                App.Ctx.SaveChanges();
                foreach(Models.Nieruchomosci ex in _dataList.Where(k => k.IdNieruchomosci == id))
                {
                    ex.Wyposazenie.Remove(data);
                }
                return true;
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        #endregion

        #region Pokoje
        public bool Update(Models.Pokoje data)
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
        public bool Remove(Models.Pokoje data, long id)
        {
            try
            {
                App.Ctx.Pokojes.Remove(data);
                App.Ctx.SaveChanges();
                foreach (Models.Nieruchomosci ex in _dataList.Where(k => k.IdNieruchomosci == id))
                {
                    ex.Pokoje.Remove(data);
                }
                return true;
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        #endregion

        #region Wyposazenie Pokoju
        public bool Update(Models.Wyposazenie_pokoju data)
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
        public bool Remove(Models.Wyposazenie_pokoju data, long id, long id_pok)
        {
            try
            {
                App.Ctx.Wyposazenie_Pokojus.Remove(data);
                App.Ctx.SaveChanges();
                foreach (Models.Nieruchomosci ex in _dataList.Where(k => k.IdNieruchomosci == id))
                {
                    foreach(Models.Pokoje exx in _dataListPok.Where(k => k.IdPokoju == id_pok))
                    {
                        exx.Wyposazenie.Remove(data);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                App.loggerFile.Error(ex, "Error!");
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        #endregion
        #endregion
    }
}
