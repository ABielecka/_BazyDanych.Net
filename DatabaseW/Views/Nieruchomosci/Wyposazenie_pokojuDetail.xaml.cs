using System;
using System.Windows;

namespace DatabaseW.Views.Nieruchomosci
{
    public partial class Wyposazenie_pokojuDetail : Window
    {
        #region Private Members
        private Models.Wyposazenie_pokoju _data;
        private bool _addNew = false;
        private Models.Wyposazenie_pokoju _dataOld;
        #endregion Private Members

        public Models.Wyposazenie_pokoju Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public bool AddNew
        {
            get { return _addNew; }
            set { _addNew = value; }
        }

        #region Constructors
        public Wyposazenie_pokojuDetail()
        {
            InitializeComponent();
        }
        #endregion Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_addNew)
            {
                _dataOld = new Models.Wyposazenie_pokoju()
                {
                    IdWyposazeniaPokoju = _data.IdWyposazeniaPokoju,
                    Wyposazenie = _data.Wyposazenie
                };
            }
            this.DataContext = _data;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_data.Wyposazenie == null)
                {
                    MessageBox.Show("Proszę podać wszystkie wymagane dane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnAnuluj_Click(object sender, RoutedEventArgs e)
        {
            if (!_addNew)
            {
                _data.IdWyposazeniaPokoju = _dataOld.IdWyposazeniaPokoju;
                _data.Wyposazenie = _dataOld.Wyposazenie;
            }
            this.DialogResult = false;
        }
    }
}
