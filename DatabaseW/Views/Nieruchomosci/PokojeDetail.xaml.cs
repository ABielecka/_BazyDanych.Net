using System;
using System.Windows;

namespace DatabaseW.Views.Pokoje
{
    public partial class PokojeDetail : Window
    {
        #region Private Members
        private Models.Pokoje _data;
        private bool _addNew = false;
        private Models.Pokoje _dataOld;
        #endregion Private Members

        public Models.Pokoje Data
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
        public PokojeDetail()
        {
            InitializeComponent();
        }
        #endregion Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!_addNew)
            {
                _dataOld = new Models.Pokoje()
                {
                    IdPokoju = _data.IdPokoju,
                    Status = _data.Status,
                    IloscOsobwPokoju = _data.IloscOsobwPokoju,
                    Opis = _data.Opis,
                    MetrazPokoju = _data.MetrazPokoju,
                    CenaWynajmuPokoju = _data.CenaWynajmuPokoju,
                    OkresWynajmuOd = _data.OkresWynajmuOd,
                    OkresWynajmuDo = _data.OkresWynajmuDo,
                    Wyposazenie = _data.Wyposazenie
                };
            }
            this.DataContext = _data;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((_data.IloscOsobwPokoju <= 0) ||
                   string.IsNullOrWhiteSpace(_data.Opis) ||
                   (_data.MetrazPokoju <= 0) ||
                   (_data.CenaWynajmuPokoju <= 0) ||
                   (_data.OkresWynajmuOd == null) ||
                   (_data.Wyposazenie == null))
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
                _data.IdPokoju = _dataOld.IdPokoju;
                _data.Status = _dataOld.Status;
                _data.IloscOsobwPokoju = _dataOld.IloscOsobwPokoju;
                _data.Opis = _dataOld.Opis;
                _data.MetrazPokoju = _dataOld.MetrazPokoju;
                _data.CenaWynajmuPokoju = _dataOld.CenaWynajmuPokoju;
                _data.OkresWynajmuOd = _dataOld.OkresWynajmuOd;
                _data.OkresWynajmuDo = _dataOld.OkresWynajmuDo;
                _data.Wyposazenie = _dataOld.Wyposazenie;
            }
            this.DialogResult = false;
        }
    }
}
