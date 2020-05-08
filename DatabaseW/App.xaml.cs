using DatabaseW.DataViewModel.Najem;
using DatabaseW.DataViewModel.Nieruchomosci;
using DatabaseW.DataViewModel.Osoby;
using DatabaseW.DataViewModel.Slownik_Wojewodztw;
using DatabaseW.DataViewModel.Slownik_wyposazen;
using DatabaseW.DataViewModel.Typ_nieruchomosci;
using DatabaseW.Views.Najem;
using DatabaseW.Views.Nieruchomosci;
using DatabaseW.Views.Osoby;
using DatabaseW.Views.Slownik_Wojewodztw;
using DatabaseW.Views.Slownik_wyposazen;
using DatabaseW.Views.Typ_nieruchomosci;
using NLog;
using Property_rental.Models;
using System.Windows;

namespace DatabaseW
{
    public partial class App : Application
    {
        public static Logger loggerFile = LogManager.GetLogger("fileLogger");
        public static string _conString = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = A-nna)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = XE))); User Id = PROPERTY_RENT; Password = Losos123";
        //public static string _conString = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP-I0C0U32)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = XE))); User Id = PROPERTY_RENT; Password = Alicja1234";
        private static Context _context;

        //Modele
        public static Slownik_wyposazenListViewModel _oSlownik_wyposazen = new Slownik_wyposazenListViewModel();
        public static NajemListViewModel _oNajem = new NajemListViewModel();
        public static NieruchomosciListViewModel _oNieruchomosc = new NieruchomosciListViewModel();
        public static OsobyListViewModel _oOsoba = new OsobyListViewModel();
        public static Slownik_WojewodztwListViewModel _oSlownik_Wojewodztw = new Slownik_WojewodztwListViewModel();
        public static Typ_nieruchomosciListViewModel _oTyp = new Typ_nieruchomosciListViewModel();

        //View
        public static Slownik_wyposazenList _vSlownik_wyposazen = new Slownik_wyposazenList();
        public static Slownik_WojewodztwList _vSlownik_Wojewodztw = new Slownik_WojewodztwList();
        public static NajemList _vNajem = new NajemList();
        public static NieruchomosciList _vNieruchomosci = new NieruchomosciList();
        public static OsobyList _vOsoby = new OsobyList();
        public static Typ_nieruchomosciList _vTyp_nieruchomosci = new Typ_nieruchomosciList();

        public static Context Ctx
        {
            get
            {
                if (_context == null)
                {
                    _context = new Context();
                }
                return _context;
            }
        }
    }
}
