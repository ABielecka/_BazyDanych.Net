using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace DatabaseW.DataViewModel.Najem
{
    public class NajemListViewModel : ViewModel
    {
        private ObservableCollection<Models.Najem> _dataList = new ObservableCollection<Models.Najem>();
        private NajemDataService _dataService = new NajemDataService();

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

        private Models.Najem _selected;

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

            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
