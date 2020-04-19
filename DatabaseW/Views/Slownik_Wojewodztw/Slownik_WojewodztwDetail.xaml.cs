﻿using System;
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

namespace DatabaseW.Views.Slownik_Wojewodztw
{
    public partial class Slownik_WojewodztwDetail : Window
    {
        #region Private Members
        private Models.Slownik_Wojewodztw _data;
        #endregion Private Members

        public Models.Slownik_Wojewodztw Data
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

        private Models.Slownik_Wojewodztw _dataOld;

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
