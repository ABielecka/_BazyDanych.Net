using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DatabaseW.Views.Nieruchomosci;
using DatabaseW.Views.Pokoje;
using DatabaseW.Views.Najem;
using System.Windows;

namespace DatabaseW.DataViewModel.Najem
{
    public class NajemListViewModel : ViewModel
    {
        private ObservableCollection<Models.Najem> _dataList = new ObservableCollection<Models.Najem>();
        private NajemDataService _dataService = new NajemDataService();

        private Models.Najem _selected;
        private ViewModelCommand _editCommand = null;
        private ViewModelCommand _removeCommand = null;

        public ObservableCollection<Models.Najem> DataList
        {
            get { return _dataList; }
            set { _dataList = value; NotifyPropertyChanged("DataList"); }
        }

        public NajemDataService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
        }

        public void Load()
        {
            if (_dataService.AreDataLoaded)
            {
                _dataList = new ObservableCollection<Models.Najem>();
                ShapeAndLoad(_dataService.DataList);
            }
            else
            {
                _dataList = new ObservableCollection<Models.Najem>();
                _dataService.DataLoaded += (s, e) =>
                {
                    ShapeAndLoad(_dataService.DataList);
                };
                _dataService.LoadData();
            }
        }
        private void ShapeAndLoad(List<Models.Najem> list)
        {
            var shaped = new ObservableCollection<Models.Najem>();
            foreach (Models.Najem obj in list)
            {
                shaped.Add(obj);
            }
            DataList = shaped;
        }

        public Models.Najem Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                NotifyPropertyChanged("Selected");
                EditCommand.OnCanExecuteChanged();
                RemoveCommand.OnCanExecuteChanged();
            }
        }

        #region Command
        public ViewModelCommand EditCommand
        {
            get
            {
                if (_editCommand == null)
                {
                    _editCommand = new ViewModelCommand(p => editNew(), p => (Selected != null) ? true : false);
                }
                return _editCommand;
            }
        }
        public ViewModelCommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new ViewModelCommand(p => removeNew(), p => (Selected != null) ? true : false);
                }
                return _removeCommand;
            }
        }

        private void editNew()
        {
            try
            {
                if (_selected.Pokoj != null)
                {
                    WynajmijPokojDetail _dlg = new WynajmijPokojDetail();
                    _dlg.AddNew = false;
                    _dlg.Data = _selected;
                    _dlg.Closed += (s, ea) =>
                    {
                        if (_dlg.DialogResult == true)
                        {
                            if (_dataService.Update(_dlg.Data))
                            {
                                _dataService.AreDataLoaded = true;
                                Load();
                            }
                        }
                    };
                    _dlg.ShowDialog();
                }
                else
                {
                    WynajmijNieruchomoscDetail _dlg = new WynajmijNieruchomoscDetail();
                    _dlg.AddNew = false;
                    _dlg.Data = _selected;
                    _dlg.Closed += (s, ea) =>
                    {
                        if (_dlg.DialogResult == true)
                        {
                            if (_dataService.Update(_dlg.Data))
                            {
                                _dataService.AreDataLoaded = true;
                                Load();
                            }
                        }
                    };
                    _dlg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void removeNew()
        {
            try
            {
                if (MessageBox.Show("Czy chcesz usunąć?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Models.Nieruchomosci _nier = _selected.Nieruchomosc;
                    Models.Pokoje _pok = _selected.Pokoj;
                    _dataService.AreDataLoaded = true;
                    if (_dataService.Remove(_selected))
                    {
                        if (_nier != null && _pok == null)
                        {
                            _nier.Status = false;
                            foreach (Models.Pokoje _p in _nier.Pokoje)
                            {
                                _p.Status = false;
                            }
                        }
                        else if (_nier != null && _pok != null)
                        {
                            _nier.Status = false;
                            _pok.Status = false;
                        }
                        App._oNieruchomosc.DataService.Update(_nier);
                        Load();
                        App._oNieruchomosc.Selected = _nier;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}