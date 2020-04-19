using DatabaseW.DataViewModel;
using System;
using System.ComponentModel;

namespace DatabaseW.Models
{
    public class Najem : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idWynajmu;
        private Osoby _osobaNajmująca;
        private Nieruchomosci _nieruchomosc;
        private Pokoje _pokoj;
        private DateTime _wynajemOd;
        private DateTime _wynajemDo;
        private double _ustalonaCenaNajmu;
        #endregion Private Members

        #region Constructors
        public Najem()
        {
        }

        public Najem(long idWynajmu, Osoby osobaWynajmujaca, Nieruchomosci nieruchomosc, Pokoje pokoj, DateTime wynajemOd, DateTime wynajemDo, double ustalonaCenaNajmu)
        {
            _idWynajmu = idWynajmu;
            _nieruchomosc = nieruchomosc;
            _pokoj = pokoj;
            _wynajemOd = wynajemOd;
            _wynajemDo = wynajemDo;
            _ustalonaCenaNajmu = ustalonaCenaNajmu;
        }
        #endregion Constructors

        #region Public Attributes
        public long IdWynajmu
        {
            get { return _idWynajmu; }
            set { _idWynajmu = value; }
        }

        public Osoby OsobaNajmująca
        {
            get { return _osobaNajmująca; }
            set { _osobaNajmująca = value; }
        }

        public Nieruchomosci Nieruchomosc
        {
            get { return _nieruchomosc; }
            set { _nieruchomosc = value; }
        }

        public Pokoje Pokoj
        {
            get { return _pokoj; }
            set { _pokoj = value; }
        }

        public DateTime WynajemOd
        {
            get { return _wynajemOd; }
            set { _wynajemOd = value; }
        }

        public DateTime WynajemDo
        {
            get { return _wynajemDo; }
            set { _wynajemDo = value; }
        }

        public double UstalonaCenaNajmu
        {
            get { return _ustalonaCenaNajmu; }
            set { _ustalonaCenaNajmu = value; }
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
                if (propertyName == string.Empty || propertyName == "IdWynajmu")
                {
                    if (this.IdWynajmu == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "UstalonaCenaNajmu")
                {
                    if (this.UstalonaCenaNajmu == 0)
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
