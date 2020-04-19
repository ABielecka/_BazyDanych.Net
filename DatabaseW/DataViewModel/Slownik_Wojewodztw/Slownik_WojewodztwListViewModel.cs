using DatabaseW.Views.Slownik_Wojewodztw;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DatabaseW.DataViewModel.Slownik_Wojewodztw
{
    public class Slownik_WojewodztwListViewModel : ViewModel
    {
        private ObservableCollection<Models.Slownik_Wojewodztw> _dataList = new ObservableCollection<Models.Slownik_Wojewodztw>();
        private Slownik_WojewodztwDataService _dataService = new Slownik_WojewodztwDataService();
        private Models.Slownik_Wojewodztw _selected;

        public ObservableCollection<Models.Slownik_Wojewodztw> DataList
        {
            get { return _dataList; }
            set { _dataList = value; NotifyPropertyChanged("DataList"); }
        }

        public Slownik_WojewodztwDataService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
        }

        public Models.Slownik_Wojewodztw Selected
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

        public void Load()
        {
            if (_dataService.AreDataLoaded)
            {
                _dataList = new ObservableCollection<Models.Slownik_Wojewodztw>();
                ShapeAndLoad(_dataService.DataList);
            }
            else
            {
                _dataList = new ObservableCollection<Models.Slownik_Wojewodztw>();
                _dataService.DataLoaded += (s, e) =>
                {
                    ShapeAndLoad(_dataService.DataList);
                };
                _dataService.LoadData();
            }
        }

        private void ShapeAndLoad(List<Models.Slownik_Wojewodztw> list)
        {
            var shaped = new ObservableCollection<Models.Slownik_Wojewodztw>();
            foreach (Models.Slownik_Wojewodztw obj in list)
            {
                shaped.Add(obj);
            }
            DataList = shaped;
        }

        #region Command
        private ViewModelCommand _addCommand = null;
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

        private ViewModelCommand _editCommand = null;
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

        private ViewModelCommand _removeCommand = null;
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
                Slownik_WojewodztwDetail _dlg = new Slownik_WojewodztwDetail();
                _dlg.AddNew = true;
                _dlg.Data = new Models.Slownik_Wojewodztw();
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
                Slownik_WojewodztwDetail _dlg = new Slownik_WojewodztwDetail();
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
