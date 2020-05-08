using DatabaseW.DataViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DatabaseW.Models
{
    public class Pokoje : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idPokoju;
        private decimal _metrazPokoju;
        private int _iloscOsobwPokoju;
        private string _opis;
        private double _cenaWynajmuPokoju;
        private DateTime _okresWynajmuOd;
        private DateTime? _okresWynajmuDo;
        private IList<Wyposazenie_pokoju> _wyposazenie;
        private bool _status;
        #endregion Private Members

        #region Constructors
        public Pokoje()
        {
            _wyposazenie = new List<Wyposazenie_pokoju>();
        }
        public Pokoje(long idPokoju, decimal metrazPokoju, int iloscOsobwPokoju, string opis, double cenaWynajmuPokoju, DateTime okresWynajmuOd, DateTime okresWynajmuDo, bool status)
        {
            _idPokoju = idPokoju;
            _metrazPokoju = metrazPokoju;
            _iloscOsobwPokoju = iloscOsobwPokoju;
            _opis = opis;
            _cenaWynajmuPokoju = cenaWynajmuPokoju;
            _okresWynajmuOd = okresWynajmuOd;
            _okresWynajmuDo = okresWynajmuDo;
            _status = status;
        }
        #endregion Constructors

        #region Public Attributes
        public long IdPokoju
        {
            get { return _idPokoju; }
            set { _idPokoju = value; }
        }
        public decimal MetrazPokoju
        {
            get { return _metrazPokoju; }
            set { _metrazPokoju = value; }
        }
        public int IloscOsobwPokoju
        {
            get { return _iloscOsobwPokoju; }
            set { _iloscOsobwPokoju = value; }
        }
        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
        }
        public double CenaWynajmuPokoju
        {
            get { return _cenaWynajmuPokoju; }
            set { _cenaWynajmuPokoju = value; }
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
        public IList<Wyposazenie_pokoju> Wyposazenie
        {
            get { return _wyposazenie; }
            set { _wyposazenie = value; }
        }
        public bool Status
        {
            get { return _status; }
            set { _status = value; }
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
                if (propertyName == string.Empty || propertyName == "IdPokoju")
                {
                    if (this.IdPokoju == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "MetrazPokoju")
                {
                    if (this.MetrazPokoju == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "IloscOsobwPokoju")
                {
                    if (this.IloscOsobwPokoju == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "Opis")
                {
                    if (string.IsNullOrWhiteSpace(this.Opis))
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "CenaWynajmuPokoju")
                {
                    if (this.CenaWynajmuPokoju == 0)
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
                return result.TrimEnd();
            }
        }
        #endregion
    }
}
