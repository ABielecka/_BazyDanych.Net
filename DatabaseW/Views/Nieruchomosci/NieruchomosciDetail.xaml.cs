using System;
using System.Linq;
using System.Windows;

namespace DatabaseW.Views.Nieruchomosci
{
    public partial class NieruchomosciDetail : Window
    {
        #region Private Members
        private Models.Nieruchomosci _data;
        #endregion Private Members

        public Models.Nieruchomosci Data
        {
            get { return _data; }
            set { _data = value; }
        }

        private bool _addNew = false;
        public bool AddNew
        {
            get { return _addNew; }
            set { _addNew = value; }
        }

        private Models.Nieruchomosci _dataOld;

        #region Constructors
        public NieruchomosciDetail()
        {
            InitializeComponent();
        }
        #endregion Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbWoj.ItemsSource = App._oSlownik_Wojewodztw.DataList.OrderBy(p => p.NazwaWojewodztwa);
            cmbTypN.ItemsSource = App._oTyp.DataList.OrderBy(p => p.Opis);
            if (!_addNew)
            {
                _dataOld = new Models.Nieruchomosci()
                {
                    IdNieruchomosci = _data.IdNieruchomosci,
                    Status = _data.Status,
                    OsobaWynajmujaca = _data.OsobaWynajmujaca,
                    TypNieruchomosci = _data.TypNieruchomosci,
                    TypWynajmu = _data.TypWynajmu,
                    OpisNieruchomosci = _data.OpisNieruchomosci,
                    MetrazNieruchomosci = _data.MetrazNieruchomosci,
                    CenaWynajmuNieruchomosci = _data.CenaWynajmuNieruchomosci,
                    OkresWynajmuOd = _data.OkresWynajmuOd,
                    OkresWynajmuDo = _data.OkresWynajmuDo,
                    WojewodztwoNieruchomosci = _data.WojewodztwoNieruchomosci,
                    MiastoNieruchomosci = _data.MiastoNieruchomosci,
                    UlicaNieruchomosci = _data.UlicaNieruchomosci
                };
            }
            this.DataContext = _data;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((_data.Status = (!false || !true)) ||
                    (_data.OsobaWynajmujaca == null) ||
                   (_data.TypNieruchomosci == null) ||
                   (_data.TypWynajmu == null) ||
                   string.IsNullOrWhiteSpace(_data.OpisNieruchomosci) ||
                   (_data.MetrazNieruchomosci == null) ||
                   (_data.CenaWynajmuNieruchomosci == null) ||
                   (_data.OkresWynajmuOd == null) ||
                   (_data.WojewodztwoNieruchomosci == null) ||
                   string.IsNullOrWhiteSpace(_data.MiastoNieruchomosci) ||
                   string.IsNullOrWhiteSpace(_data.UlicaNieruchomosci))
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
                _data.IdNieruchomosci = _dataOld.IdNieruchomosci;
                _data.Status = _dataOld.Status;
                _data.OsobaWynajmujaca = _dataOld.OsobaWynajmujaca;
                _data.TypNieruchomosci = _dataOld.TypNieruchomosci;
                _data.TypWynajmu = _dataOld.TypWynajmu;
                _data.OpisNieruchomosci = _dataOld.OpisNieruchomosci;
                _data.MetrazNieruchomosci = _dataOld.MetrazNieruchomosci;
                _data.CenaWynajmuNieruchomosci = _dataOld.CenaWynajmuNieruchomosci;
                _data.OkresWynajmuOd = _dataOld.OkresWynajmuOd;
                _data.OkresWynajmuDo = _dataOld.OkresWynajmuDo;
                _data.WojewodztwoNieruchomosci = _dataOld.WojewodztwoNieruchomosci;
                _data.MiastoNieruchomosci = _dataOld.MiastoNieruchomosci;
                _data.UlicaNieruchomosci = _dataOld.UlicaNieruchomosci;
            }
            this.DialogResult = false;
        }
    }
}
