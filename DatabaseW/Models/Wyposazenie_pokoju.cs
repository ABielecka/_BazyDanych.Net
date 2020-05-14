using DatabaseW.DataViewModel;
using System;
using System.ComponentModel;

namespace DatabaseW.Models
{
    public class Wyposazenie_pokoju : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idWyposazeniaPokoju;
        private Slownik_wyposazen _wyposazenie;
        #endregion Private Members

        #region Constructors
        public Wyposazenie_pokoju()
        {
        }
        public Wyposazenie_pokoju(long idWyposazeniaPokoju, Slownik_wyposazen wyposazenie)
        {
            _idWyposazeniaPokoju = idWyposazeniaPokoju;
            _wyposazenie = wyposazenie;
        }
        #endregion Constructors

        #region Public Attributes
        public long IdWyposazeniaPokoju
        {
            get { return _idWyposazeniaPokoju; }
            set { _idWyposazeniaPokoju = value; NotifyPropertyChanged("IdWyposazeniaPokoju"); }
        }
        public Slownik_wyposazen Wyposazenie
        {
            get { return _wyposazenie; }
            set { _wyposazenie = value; NotifyPropertyChanged("Wyposazenie"); }
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
                if (propertyName == string.Empty || propertyName == "IdWyposazeniaPokoju")
                {
                    if (this.IdWyposazeniaPokoju == 0)
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
