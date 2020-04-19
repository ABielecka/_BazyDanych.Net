using DatabaseW.DataViewModel;
using Property_rental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DatabaseW.Models
{
    public class Nieruchomosci : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idNieruchomosci;
        private Slownik_Wojewodztw _wojewodztwoNieruchomosci;
        private string _miastoNieruchomosci;
        private string _ulicaNieruchomosci;
        private decimal _metrazNieruchomosci;
        private string _opisNieruchomosci;
        private double _cenaWynajmuNieruchomosci;
        private DateTime _okresWynajmuOd;
        private DateTime? _okresWynajmuDo;          //okres wynajmu do - opcjonalnie
        private string _typWynajmu;
        private bool _status;
        private Typ_nieruchomosci _typNieruchomosci; //slownik
        private Osoby _osobaWynajmujaca;
        private IList<Pokoje> _pokoje;
        private IList<Wyposazenie_nieruchomosci> _wyposazenie;
        #endregion Private Members

        #region Constructors
        public Nieruchomosci()
        {
            _pokoje = new List<Pokoje>();
            _wyposazenie = new List<Wyposazenie_nieruchomosci>();
        }

        public Nieruchomosci(long idNieruchomosci, Slownik_Wojewodztw wojewodztwoNieruchomosci, string miastoNieruchomosci, string ulicaNieruchomosci, decimal metrazNieruchomosci, string opisNieruchomosci, double cenaWynajmuNieruchomosci, DateTime okresWynajmuOd, DateTime? okresWynajmuDo, string typWynajmu, bool status, Typ_nieruchomosci typNieruchomosci, Osoby osobaWynajmujaca)
        {
            _idNieruchomosci = idNieruchomosci;
            _wojewodztwoNieruchomosci = wojewodztwoNieruchomosci;
            _miastoNieruchomosci = miastoNieruchomosci;
            _ulicaNieruchomosci = ulicaNieruchomosci;
            _metrazNieruchomosci = metrazNieruchomosci;
            _opisNieruchomosci = opisNieruchomosci;
            _cenaWynajmuNieruchomosci = cenaWynajmuNieruchomosci;
            _okresWynajmuOd = okresWynajmuOd;
            _okresWynajmuDo = okresWynajmuDo;
            _typWynajmu = typWynajmu;
            _status = status;
            _typNieruchomosci = typNieruchomosci;
            _osobaWynajmujaca = osobaWynajmujaca;
        }

        #endregion Constructors

        #region Public Attributes
        public long IdNieruchomosci
        {
            get { return _idNieruchomosci; }
            set { _idNieruchomosci = value; }
        }

        public decimal MetrazNieruchomosci
        {
            get { return _metrazNieruchomosci; }
            set { _metrazNieruchomosci = value; }
        }

        public string OpisNieruchomosci
        {
            get { return _opisNieruchomosci; }
            set { _opisNieruchomosci = value; }
        }

        public double CenaWynajmuNieruchomosci
        {
            get { return _cenaWynajmuNieruchomosci; }
            set { _cenaWynajmuNieruchomosci = value; }
        }

        public DateTime OkresWynajmuOd
        {
            get { return _okresWynajmuOd; }
            set { _okresWynajmuOd = value; }
        }

        public DateTime? OkresWynajmuDo
        {
            get { return _okresWynajmuDo; }
            set { _okresWynajmuDo = value; }
        }

        public string TypWynajmu
        {
            get { return _typWynajmu; }
            set { _typWynajmu = value; }
        }

        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public Typ_nieruchomosci TypNieruchomosci
        {
            get { return _typNieruchomosci; }
            set { _typNieruchomosci = value; }
        }

        public Osoby OsobaWynajmujaca
        {
            get { return _osobaWynajmujaca; }
            set { _osobaWynajmujaca = value; }
        }

        public IList<Pokoje> Pokoje
        {
            get { return _pokoje; }
            set { _pokoje = value; }
        }

        public IList<Wyposazenie_nieruchomosci> Wyposazenie
        {
            get { return _wyposazenie; }
            set { _wyposazenie = value; }
        }

        public Slownik_Wojewodztw WojewodztwoNieruchomosci
        {
            get { return _wojewodztwoNieruchomosci; }
            set { _wojewodztwoNieruchomosci = value; }
        }

        public string MiastoNieruchomosci
        {
            get { return _miastoNieruchomosci; }
            set { _miastoNieruchomosci = value; }
        }

        public string UlicaNieruchomosci
        {
            get { return _ulicaNieruchomosci; }
            set { _ulicaNieruchomosci = value; }
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
                if (propertyName == string.Empty || propertyName == "IdNieruchomosci")
                {
                    if (this.IdNieruchomosci == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "WojewodztwoNieruchomosci")
                {
                    if (this.WojewodztwoNieruchomosci == null)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "MiastoNieruchomosci")
                {
                    if (string.IsNullOrWhiteSpace(this.MiastoNieruchomosci))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "UlicaNieruchomosci")
                {
                    if (string.IsNullOrWhiteSpace(this.UlicaNieruchomosci))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "MetrazNieruchomosci")
                {
                    if (this.MetrazNieruchomosci == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "OpisNieruchomosci")
                {
                    if (string.IsNullOrWhiteSpace(this.OpisNieruchomosci))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "CenaWynajmuNieruchomosci")
                {
                    if (this.CenaWynajmuNieruchomosci == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "TypWynajmu")
                {
                    if (string.IsNullOrWhiteSpace(this.TypWynajmu))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "CenaWynajmuNieruchomosci")
                {
                    if (this.CenaWynajmuNieruchomosci == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "Status")
                {
                    if (this.Status == (!false || !true))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "OkresWynajmuOd")
                {
                    if (this.OkresWynajmuOd == null)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "TypNieruchomosci")
                {
                    if (this.TypNieruchomosci == null)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "OsobaWynajmująca")
                {
                    if (this.OsobaWynajmujaca == null)
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
