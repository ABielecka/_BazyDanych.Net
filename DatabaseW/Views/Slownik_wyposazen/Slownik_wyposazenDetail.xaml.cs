using System;
using System.Windows;

namespace DatabaseW.Views.Slownik_wyposazen
{
    public partial class Slownik_wyposazenDetail : Window
    {
        #region Private Members
        private Models.Slownik_wyposazen _data;
        private bool _addNew = false;
        private Models.Slownik_wyposazen _dataOld;
        #endregion Private Members

        public Models.Slownik_wyposazen Data
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
        public Slownik_wyposazenDetail()
        {
            InitializeComponent();
        }
        #endregion Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_addNew)
            {
                _dataOld = new Models.Slownik_wyposazen()
                {
                    IdWyposazenia = _data.IdWyposazenia,
                    Opis = _data.Opis
                };
            }
            this.DataContext = _data;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_data.Opis))
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
                _data.IdWyposazenia = _dataOld.IdWyposazenia;
                _data.Opis = _dataOld.Opis;
            }
            this.DialogResult = false;
        }
    }
}
