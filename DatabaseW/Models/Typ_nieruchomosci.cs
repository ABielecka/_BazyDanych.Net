using DatabaseW.DataViewModel;
using System;
using System.ComponentModel;

namespace DatabaseW.Models
{
    public class Typ_nieruchomosci : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idTyp;
        private string _opis;
        #endregion Private Members

        #region Constructors
        public Typ_nieruchomosci()
        {
        }
        public Typ_nieruchomosci(long idTyp, string opis)
        {
            _idTyp = idTyp;
            _opis = opis;
        }
        #endregion Constructors

        #region Public Attributes
        public long IdTyp
        {
            get { return _idTyp; }
            set { _idTyp = value; NotifyPropertyChanged("IdTyp"); }
        }
        public string Opis
        {
            get { return _opis; }
            set { _opis = value; NotifyPropertyChanged("Opis"); }
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
                if (propertyName == string.Empty || propertyName == "IdTyp")
                {
                    if (this.IdTyp == 0)
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
