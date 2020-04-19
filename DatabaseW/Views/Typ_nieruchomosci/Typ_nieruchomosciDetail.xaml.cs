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

namespace DatabaseW.Views.Typ_nieruchomosci
{
    public partial class Typ_nieruchomosciDetail : Window
    {
        #region Private Members
        private Models.Typ_nieruchomosci _data;
        #endregion Private Members

        public Models.Typ_nieruchomosci Data
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

        private Models.Typ_nieruchomosci _dataOld;

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
