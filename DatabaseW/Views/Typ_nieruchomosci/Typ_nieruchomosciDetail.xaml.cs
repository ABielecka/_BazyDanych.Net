using System;
using System.Windows;

namespace DatabaseW.Views.Typ_nieruchomosci
{
    public partial class Typ_nieruchomosciDetail : Window
    {
        #region Private Members
        private Models.Typ_nieruchomosci _data;
        private bool _addNew = false;
        private Models.Typ_nieruchomosci _dataOld;
        #endregion Private Members

        public Models.Typ_nieruchomosci Data
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
        public Typ_nieruchomosciDetail()
        {
            InitializeComponent();
        }
        #endregion Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_addNew)
            {
                _dataOld = new Models.Typ_nieruchomosci()
                {
                    IdTyp = _data.IdTyp,
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
                _data.IdTyp = _dataOld.IdTyp;
                _data.Opis = _dataOld.Opis;
            }
            this.DialogResult = false;
        }
    }
}
