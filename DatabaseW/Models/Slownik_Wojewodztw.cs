using DatabaseW.DataViewModel;
using System;
using System.ComponentModel;

namespace DatabaseW.Models
{
    public class Slownik_Wojewodztw : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idWojewodztwa;
        private string _nazwaWojewodztwa;
        #endregion Private Members

        #region Constructors
        public Slownik_Wojewodztw()
        {
        }
        public Slownik_Wojewodztw(long idWojewodztwa, string nazwaWojewodztwa)
        {
            _idWojewodztwa = idWojewodztwa;
            _nazwaWojewodztwa = nazwaWojewodztwa;
        }
        #endregion Constructors

        #region Public Attributes
        public long IdWojewodztwa
        {
            get { return _idWojewodztwa; }
            set { _idWojewodztwa = value; }
        }
        public string NazwaWojewodztwa
        {
            get { return _nazwaWojewodztwa; }
            set { _nazwaWojewodztwa = value; }
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
                if (propertyName == string.Empty || propertyName == "IdWojewodztwa")
                {
                    if (this.IdWojewodztwa == 0)
                    {
                        result += "Pole jest obowiązkowe." + Environment.NewLine;
                    }
                }
                if (propertyName == string.Empty || propertyName == "NazwaWojewodztwa")
                {
                    if (string.IsNullOrWhiteSpace(this.NazwaWojewodztwa))
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
