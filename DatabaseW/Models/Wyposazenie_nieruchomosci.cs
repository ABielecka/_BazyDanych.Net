using DatabaseW.DataViewModel;
using DatabaseW.Models;
using System;
using System.ComponentModel;

namespace Property_rental.Models
{
    public class Wyposazenie_nieruchomosci : ViewModel, IDataErrorInfo
    {
        #region Private Members
        private long _idWyposazeniaNieruchomosci;
        private Slownik_wyposazen _wyposazenie;
        #endregion Private Members

        #region Constructors
        public Wyposazenie_nieruchomosci()
        {
        }

        public Wyposazenie_nieruchomosci(long idWyposazeniaNieruchomosci, Slownik_wyposazen wyposazenie)
        {
            _idWyposazeniaNieruchomosci = idWyposazeniaNieruchomosci;
            _wyposazenie = wyposazenie;
        }
        #endregion Constructors

        #region Public Attributes
        public long IdWyposazeniaNieruchomosci
        {
            get { return _idWyposazeniaNieruchomosci; }
            set { _idWyposazeniaNieruchomosci = value; }
        }
        public Slownik_wyposazen Wyposazenie
        {
            get { return _wyposazenie; }
            set { _wyposazenie = value; }
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
                if (propertyName == string.Empty || propertyName == "IdWyposazeniaNieruchomosci")
                {
                    if (this.IdWyposazeniaNieruchomosci == 0)
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
