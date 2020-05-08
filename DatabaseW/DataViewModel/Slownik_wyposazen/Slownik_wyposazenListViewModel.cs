using DatabaseW.Views.Slownik_wyposazen;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DatabaseW.DataViewModel.Slownik_wyposazen
{
    public class Slownik_wyposazenListViewModel : ViewModel
    {
        private ObservableCollection<Models.Slownik_wyposazen> _dataList = new ObservableCollection<Models.Slownik_wyposazen>();
        private Slownik_wyposazenDataService _dataService = new Slownik_wyposazenDataService();

        private Models.Slownik_wyposazen _selected;
        private ViewModelCommand _addCommand = null;
        private ViewModelCommand _editCommand = null;
        private ViewModelCommand _removeCommand = null;

        public ObservableCollection<Models.Slownik_wyposazen> DataList
        {
            get { return _dataList; }
            set { _dataList = value; NotifyPropertyChanged("DataList"); }
        }
        public Slownik_wyposazenDataService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
        }

        public void Load()
        {
            if (_dataService.AreDataLoaded)
            {
                _dataList = new ObservableCollection<Models.Slownik_wyposazen>();
                ShapeAndLoad(_dataService.DataList);
            }
            else
            {
                _dataList = new ObservableCollection<Models.Slownik_wyposazen>();
                _dataService.DataLoaded += (s, e) =>
                {
                    ShapeAndLoad(_dataService.DataList);
                };
                _dataService.LoadData();
            }
        }
        private void ShapeAndLoad(List<Models.Slownik_wyposazen> list)
        {
            var shaped = new ObservableCollection<Models.Slownik_wyposazen>();
            foreach (Models.Slownik_wyposazen obj in list)
            {
                shaped.Add(obj);
            }
            DataList = shaped;
        }

        public Models.Slownik_wyposazen Selected
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
        public ViewModelCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new ViewModelCommand(p => addNew(), p => true);
                }
                return _addCommand;
            }
        }
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

        private void addNew()
        {
            try
            {
                Slownik_wyposazenDetail _dlg = new Slownik_wyposazenDetail();
                _dlg.AddNew = true;
                _dlg.Data = new Models.Slownik_wyposazen();
                _dlg.Closed += (s, ea) =>
                {
                    if (_dlg.DialogResult == true)
                    {
                        if (_dataService.Save(_dlg.Data))
                        {
                            _dataService.AreDataLoaded = true;
                            Load();
                        }
                    }
                };
                _dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void editNew()
        {
            try
            {
                Slownik_wyposazenDetail _dlg = new Slownik_wyposazenDetail();
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
                    _dataService.AreDataLoaded = true;
                    if (_dataService.Remove(_selected))
                    {
                        Load();
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
