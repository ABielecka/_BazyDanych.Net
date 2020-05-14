using DatabaseW.DataViewModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseW.Models
{
    public class Osoby : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idOsoby;
        private string _nazwisko;
        private string _imie;
        private Slownik_Wojewodztw _wojewodztwoZamieszkania;
        private string _miastoZamieszkania;
        private string _ulicaZamieszkania;              //adres zamieszkania do możliwego dalszego rozwoju
        private DateTime? _dataUrodzenia;               //data urodzenia - opcjonalna
        private string _telefon;
        #endregion Private Members

        #region Constructors
        public Osoby()
        {
        }
        public Osoby(long idOsoby, string nazwisko, string imie, Slownik_Wojewodztw wojewodztwoZamieszkania, string miastoZamieszkania, string ulicaZamieszkania, DateTime? dataUrodzenia, string telefon)
        {
            _idOsoby = idOsoby;
            _nazwisko = nazwisko;
            _imie = imie;
            _wojewodztwoZamieszkania = wojewodztwoZamieszkania;
            _miastoZamieszkania = miastoZamieszkania;
            _ulicaZamieszkania = ulicaZamieszkania;
            _dataUrodzenia = dataUrodzenia;
            _telefon = telefon;
        }
        #endregion Constructors

        #region Public Attributes
        public long IdOsoby
        {
            get { return _idOsoby; }
            set { _idOsoby = value; NotifyPropertyChanged("IdOsoby"); }
        }
        public string Nazwisko
        {
            get { return _nazwisko; }
            set { _nazwisko = value; NotifyPropertyChanged("Nazwisko"); }
        }
        public string Imie
        {
            get { return _imie; }
            set { _imie = value; NotifyPropertyChanged("Imie"); }
        }
        public DateTime? DataUrodzenia
        {
            get { return _dataUrodzenia; }
            set { _dataUrodzenia = value; NotifyPropertyChanged("DataUrodzenia"); }
        }
        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; NotifyPropertyChanged("Telefon"); }
        }
        public Slownik_Wojewodztw WojewodztwoZamieszkania
        {
            get { return _wojewodztwoZamieszkania; }
            set { _wojewodztwoZamieszkania = value; NotifyPropertyChanged("WojewodztwoZamieszkania"); }
        }
        public string MiastoZamieszkania
        {
            get { return _miastoZamieszkania; }
            set { _miastoZamieszkania = value; NotifyPropertyChanged("MiastoZamieszkania"); }
        }
        public string UlicaZamieszkania
        {
            get { return _ulicaZamieszkania; }
            set { _ulicaZamieszkania = value; NotifyPropertyChanged("UlicaZamieszkania"); }
        }
        [NotMapped]
        public string NazwiskoImie
        {
            get { return _nazwisko + " " + _imie;  }
        }
        #endregion Public Attributes

        #region IDataErrorInfo Members
        public string Error
        {
            get { return this[null]; }
        }
        public string this[string propertyName]
        {
            get
            {
                string result = string.Empty;
                propertyName = propertyName ?? string.Empty;
                if (propertyName == string.Empty || propertyName == "IdOsoby")
                {
                    if (this.IdOsoby == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "Nazwisko")
                {
                    if (string.IsNullOrWhiteSpace(this.Nazwisko))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "Imie")
                {
                    if (string.IsNullOrWhiteSpace(this.Imie))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "WojewodztwoZamieszkania")
                {
                    if (this.WojewodztwoZamieszkania == null)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "MiastoZamieszkania")
                {
                    if (string.IsNullOrWhiteSpace(this.MiastoZamieszkania))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "UlicaZamieszkania")
                {
                    if (string.IsNullOrWhiteSpace(this.UlicaZamieszkania))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "Telefon")
                {
                    if (string.IsNullOrWhiteSpace(this.Telefon))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                return result.TrimEnd();
            }
        }
        #endregion
    }
}
