using System;
using System.Windows;

namespace DatabaseW.Views.Slownik_Wojewodztw
{
    public partial class Slownik_WojewodztwDetail : Window
    {
        #region Private Members
        private Models.Slownik_Wojewodztw _data;
        private bool _addNew = false;
        private Models.Slownik_Wojewodztw _dataOld;
        #endregion Private Members

        public Models.Slownik_Wojewodztw Data
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
        public Slownik_WojewodztwDetail()
        {
            InitializeComponent();
        }
        #endregion Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_addNew)
            {
                _dataOld = new Models.Slownik_Wojewodztw()
                {
                    IdWojewodztwa = _data.IdWojewodztwa,
                    NazwaWojewodztwa = _data.NazwaWojewodztwa
                };
            }
            this.DataContext = _data;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_data.NazwaWojewodztwa))
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
                _data.IdWojewodztwa = _dataOld.IdWojewodztwa;
                _data.NazwaWojewodztwa = _dataOld.NazwaWojewodztwa;
            }
            this.DialogResult = false;
        }
    }
}
