using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DatabaseW.Views.Nieruchomosci
{
    public partial class WynajmijNieruchomoscDetail : Window
    {
        #region Private Members
        private Models.Najem _data;
        private bool _addNew = false;
        private Models.Najem _dataOld;
        private Models.Nieruchomosci _dataNier;
        #endregion Private Members

        public Models.Najem Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public bool AddNew
        {
            get { return _addNew; }
            set { _addNew = value; }
        }

        public Models.Nieruchomosci DataNier
        {
            get { return _dataNier; }
            set { _dataNier = value; }
        }

        #region Constructors
        public WynajmijNieruchomoscDetail()
        {
            InitializeComponent();
        }
        #endregion Constructors

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbNajem.ItemsSource = App._oOsoba.DataList.OrderBy(p => p.NazwiskoImie);
            if (!_addNew)
            {
                _dataOld = new Models.Najem()
                {
                    IdWynajmu = _data.IdWynajmu,
                    OsobaNajmujaca = _data.OsobaNajmujaca,
                    UstalonaCenaNajmu = _data.UstalonaCenaNajmu,
                    WynajemOd = _data.WynajemOd,
                    WynajemDo = _data.WynajemDo,
                    Nieruchomosc = _data.Nieruchomosc,
                    Identyfikator = _data.Identyfikator
                };
                txtIdent.IsReadOnly = true;
                cmbNajem.IsEnabled = false;
            }
            else
            {
                _data.Nieruchomosc = _dataNier;
                _data.UstalonaCenaNajmu = _dataNier.CenaWynajmuNieruchomosci;
            }
            this.DataContext = _data;
        }

        private void btnZapisz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((_data.OsobaNajmujaca == null) ||
                   (_data.UstalonaCenaNajmu == 0) ||
                   (_data.WynajemOd == null) ||
                   (_data.WynajemDo == null) ||
                   (_data.Nieruchomosc == null) ||
                   (string.IsNullOrWhiteSpace(_data.Identyfikator)))
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
                _data.IdWynajmu = _dataOld.IdWynajmu;
                _data.OsobaNajmujaca = _dataOld.OsobaNajmujaca;
                _data.UstalonaCenaNajmu = _dataOld.UstalonaCenaNajmu;
                _data.WynajemOd = _dataOld.WynajemOd;
                _data.WynajemDo = _dataOld.WynajemDo;
                _data.Nieruchomosc = _dataOld.Nieruchomosc;
                _data.Identyfikator = _dataOld.Identyfikator;
            }
            this.DialogResult = false;
        }
    }
}
