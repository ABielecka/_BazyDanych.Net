using DatabaseW.DataViewModel;
using System;
using System.ComponentModel;

namespace DatabaseW.Models
{
    public class Slownik_wyposazen : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idWyposazenia;
        private string _opis;
        #endregion Private Members

        #region Constructors
        public Slownik_wyposazen()
        {
        }

        public Slownik_wyposazen(long idWyposazenia, string opis)
        {
            _idWyposazenia = idWyposazenia;
            _opis = opis;
        }
        #endregion Constructors

        #region Public Attributes
        public long IdWyposazenia
        {
            get { return _idWyposazenia; }
            set { _idWyposazenia = value; }
        }

        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
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
                if (propertyName == string.Empty || propertyName == "IdWyposazenia")
                {
                    if (this.IdWyposazenia == 0)
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
                return result.TrimEnd();
            }
        }
        #endregion
    }
}
