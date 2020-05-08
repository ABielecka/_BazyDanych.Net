using System;
using System.Windows.Threading;

namespace DatabaseW.DataViewModel
{
    public class LoadDataStart
    {
        GetData _parentDialog = null;

        public LoadDataStart(GetData parent)
        {
            this._parentDialog = parent;
        }

        public void Run()
        {
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Minimum = 0; }));
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Maximum = 6; }));
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Value = 0; }));

            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.labelCo.Content = "Słowniki Wyposażeń"; }));
            App._oSlownik_wyposazen.DataService.AreDataLoaded = false;
            App._oSlownik_wyposazen.Load();
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Value = 1; }));

            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.labelCo.Content = "Lista najmów"; }));
            App._oNajem.DataService.AreDataLoaded = false;
            App._oNajem.Load();
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Value = 2; }));

            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.labelCo.Content = "Nieruchomości"; }));
            App._oNieruchomosc.DataService.AreDataLoaded = false;
            App._oNieruchomosc.Load();
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Value = 3; }));

            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.labelCo.Content = "Użytkownicy"; }));
            App._oOsoba.DataService.AreDataLoaded = false;
            App._oOsoba.Load();
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Value = 4; }));

            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.labelCo.Content = "Typ nieruchomości"; }));
            App._oTyp.DataService.AreDataLoaded = false;
            App._oTyp.Load();
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Value = 5; }));

            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.labelCo.Content = "Wojewodztwa"; }));
            App._oSlownik_Wojewodztw.DataService.AreDataLoaded = false;
            App._oSlownik_Wojewodztw.Load();
            _parentDialog.progressBar.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.progressBar.Value = 6; }));

            _parentDialog.Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate { _parentDialog.Close(); }));
        }
    }
}
