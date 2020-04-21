using System;
using System.Linq;
using System.Windows;

namespace DatabaseW.Views.Osoby
{
    public partial class OsobyDetail : Window
    {
        #region Private Members
        private Models.Osoby _data;
        private bool _addNew = false;
        private Models.Osoby _dataOld;
        #endregion Private Members

        public Models.Osoby Data
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
        public OsobyDetail()
        {
            InitializeComponent();
        }
        #endregion Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbWoj.ItemsSource = App._oSlownik_Wojewodztw.DataList.OrderBy(p => p.NazwaWojewodztwa);
            if (!_addNew)
            {
                _dataOld = new Models.Osoby()
                {
                    IdOsoby = _data.IdOsoby,
                    Imie = _data.Imie,
                    Nazwisko = _data.Nazwisko,
                    DataUrodzenia = _data.DataUrodzenia,
                    WojewodztwoZamieszkania = _data.WojewodztwoZamieszkania,
                    MiastoZamieszkania = _data.MiastoZamieszkania,
                    UlicaZamieszkania = _data.UlicaZamieszkania,
                    Telefon = _data.Telefon
                };
            }
            this.DataContext = _data;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_data.Imie) ||
                   string.IsNullOrWhiteSpace(_data.Nazwisko) ||
                   (_data.WojewodztwoZamieszkania == null) ||
                   string.IsNullOrWhiteSpace(_data.MiastoZamieszkania) ||
                   string.IsNullOrWhiteSpace(_data.UlicaZamieszkania) ||
                   string.IsNullOrWhiteSpace(_data.Telefon))
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
                _data.IdOsoby = _dataOld.IdOsoby;
                _data.Imie = _dataOld.Imie;
                _data.Nazwisko = _dataOld.Nazwisko;
                _data.DataUrodzenia = _dataOld.DataUrodzenia;
                _data.WojewodztwoZamieszkania = _dataOld.WojewodztwoZamieszkania;
                _data.MiastoZamieszkania = _dataOld.MiastoZamieszkania;
                _data.UlicaZamieszkania = _dataOld.UlicaZamieszkania;
                _data.Telefon = _dataOld.Telefon;
            }
            this.DialogResult = false;
        }
    }
}
