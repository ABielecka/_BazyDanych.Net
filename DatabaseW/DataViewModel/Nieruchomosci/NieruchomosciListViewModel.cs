using DatabaseW.Views.APIs;
using DatabaseW.Views.Nieruchomosci;
using DatabaseW.Views.Pokoje;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web;
using System.Windows;

namespace DatabaseW.DataViewModel.Nieruchomosci
{
    public class NieruchomosciListViewModel : ViewModel
    {
        private ObservableCollection<Models.Nieruchomosci> _dataList = new ObservableCollection<Models.Nieruchomosci>();
        private ObservableCollection<Models.Wyposazenie_nieruchomosci> _dataListW = new ObservableCollection<Models.Wyposazenie_nieruchomosci>();
        private ObservableCollection<Models.Pokoje> _dataListPok = new ObservableCollection<Models.Pokoje>();
        private ObservableCollection<Models.Wyposazenie_pokoju> _dataListWPok = new ObservableCollection<Models.Wyposazenie_pokoju>();
        private NieruchomosciDataService _dataService = new NieruchomosciDataService();

        private Models.Nieruchomosci _selected;
        private Models.Wyposazenie_nieruchomosci _selectedW;
        private Models.Pokoje _selectedPok;
        private Models.Wyposazenie_pokoju _selectedWPok;

        private ViewModelCommand _addCommand = null;
        private ViewModelCommand _editCommand = null;
        private ViewModelCommand _removeCommand = null;
        private ViewModelCommand _showMapCommand = null;
        private ViewModelCommand _showSearchCommand = null;

        private ViewModelCommand _addCommandW = null;
        private ViewModelCommand _editCommandW = null;
        private ViewModelCommand _removeCommandW = null;

        private ViewModelCommand _addCommandPok = null;
        private ViewModelCommand _editCommandPok = null;
        private ViewModelCommand _removeCommandPok = null;

        private ViewModelCommand _addCommandWPok = null;
        private ViewModelCommand _editCommandWPok = null;
        private ViewModelCommand _removeCommandWPok = null;

        public ObservableCollection<Models.Nieruchomosci> DataList
        {
            get { return _dataList; }
            set { _dataList = value; NotifyPropertyChanged("DataList"); }
        }
        public ObservableCollection<Models.Pokoje> DataListPok
        {
            get { return _dataListPok; }
            set { _dataListPok = value; NotifyPropertyChanged("DataListPok"); }
        }
        public ObservableCollection<Models.Wyposazenie_pokoju> DataListWPok
        {
            get { return _dataListWPok; }
            set { _dataListWPok = value; NotifyPropertyChanged("DataListWPok"); }
        }
        public ObservableCollection<Models.Wyposazenie_nieruchomosci> DataListW
        {
            get { return _dataListW; }
            set { _dataListW = value; NotifyPropertyChanged("DataListW"); }
        }

        public NieruchomosciDataService DataService
        {
            get { return _dataService; }
            set { _dataService = value; }
        }

        public void Load()
        {
            if (_dataService.AreDataLoaded)
            {
                _dataList = new ObservableCollection<Models.Nieruchomosci>();
                ShapeAndLoad(_dataService.DataList);
            }
            else
            {
                _dataList = new ObservableCollection<Models.Nieruchomosci>();
                _dataService.DataLoaded += (s, e) =>
                {
                    ShapeAndLoad(_dataService.DataList);
                };
                _dataService.LoadData();
            }
        }
        private void ShapeAndLoad(List<Models.Nieruchomosci> list)
        {
            var shaped = new ObservableCollection<Models.Nieruchomosci>();
            foreach (Models.Nieruchomosci obj in list)
            {
                shaped.Add(obj);
            }
            DataList = shaped;
        }

        public Models.Nieruchomosci Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                _dataListW.Clear();
                _dataListPok.Clear();
                if (_selected != null)
                {
                    foreach (Models.Wyposazenie_nieruchomosci obj in _selected.Wyposazenie)
                    {
                        _dataListW.Add(obj);
                    }
                    foreach (Models.Pokoje obj in _selected.Pokoje)
                    {
                        _dataListPok.Add(obj);
                    }
                }
                NotifyPropertyChanged("Selected");
                EditCommand.OnCanExecuteChanged();
                RemoveCommand.OnCanExecuteChanged();
                AddCommandW.OnCanExecuteChanged();
                AddCommandPok.OnCanExecuteChanged();
                ShowMapCommand.OnCanExecuteChanged();
                ShowSearchCommand.OnCanExecuteChanged();
            }
        }
        public Models.Wyposazenie_nieruchomosci SelectedW
        {
            get { return _selectedW; }
            set
            {
                _selectedW = value;
                NotifyPropertyChanged("SelectedW");
                EditCommandW.OnCanExecuteChanged();
                RemoveCommandW.OnCanExecuteChanged();
            }
        }
        public Models.Pokoje SelectedPok
        {
            get { return _selectedPok; }
            set
            {
                _selectedPok = value;
                _dataListWPok.Clear();
                if (_selectedPok != null)
                {
                    foreach (Models.Wyposazenie_pokoju obj in _selectedPok.Wyposazenie)
                    {
                        _dataListWPok.Add(obj);
                    }
                }
                NotifyPropertyChanged("SelectedPok");
                EditCommandPok.OnCanExecuteChanged();
                RemoveCommandPok.OnCanExecuteChanged();
                AddCommandWPok.OnCanExecuteChanged();
            }
        }
        public Models.Wyposazenie_pokoju SelectedWPok
        {
            get { return _selectedWPok; }
            set
            {
                _selectedWPok = value;
                NotifyPropertyChanged("SelectedWyp");
                EditCommandWPok.OnCanExecuteChanged();
                RemoveCommandWPok.OnCanExecuteChanged();
            }
        }


        #region Command
        #region Nieruchomosci
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
        public ViewModelCommand ShowMapCommand
        {
            get
            {
                if (_showMapCommand == null)
                {
                    _showMapCommand = new ViewModelCommand(p => showMapCommand(), p => true);
                }
                return _showMapCommand;
            }
        }
        public ViewModelCommand ShowSearchCommand
        {
            get
            {
                if (_showSearchCommand == null)
                {
                    _showSearchCommand = new ViewModelCommand(p => showSearchCommand(), p => true);
                }
                return _showSearchCommand;
            }
        }

        private void addNew()
        {
            try
            {
                NieruchomosciDetail _dlg = new NieruchomosciDetail();
                _dlg.AddNew = true;
                _dlg.Data = new Models.Nieruchomosci();
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
                NieruchomosciDetail _dlg = new NieruchomosciDetail();
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
        private void showMapCommand()
        {
            try
            {
                if (Selected == null) return;

                string url = "https://www.google.com/maps/search/?api=1&";

                string adres = _selected.UlicaNieruchomosci.Trim() + ","
                                + _selected.MiastoNieruchomosci.Trim()
                                + "," + _selected.WojewodztwoNieruchomosci.NazwaWojewodztwa.Trim()
                                + ",Polska";
                url += "query=" + HttpUtility.UrlEncode(adres, Encoding.UTF8);
                url += "&t=m";

                MapApiDetail _dlg = new MapApiDetail(url);
                _dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void showSearchCommand()
        {
            try
            {

                string adres = _selected.UlicaNieruchomosci.Trim() + ","
                                + _selected.MiastoNieruchomosci.Trim()
                                + "," + _selected.WojewodztwoNieruchomosci.NazwaWojewodztwa.Trim()
                                + ",Polska";
                PageAPIDetail _dlg = new PageAPIDetail(adres);
                _dlg.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region WyposazenieNieruchomosci
        public ViewModelCommand AddCommandW
        {
            get
            {
                if (_addCommandW == null)
                {
                    _addCommandW = new ViewModelCommand(p => addNewW(), p => (Selected != null) ? true : false);
                }
                return _addCommandW;
            }
        }
        public ViewModelCommand EditCommandW
        {
            get
            {
                if (_editCommandW == null)
                {
                    _editCommandW = new ViewModelCommand(p => editNewW(), p => (SelectedW != null) ? true : false);
                }
                return _editCommandW;
            }
        }
        public ViewModelCommand RemoveCommandW
        {
            get
            {
                if (_removeCommandW == null)
                {
                    _removeCommandW = new ViewModelCommand(p => removeNewW(), p => (SelectedW != null) ? true : false);
                }
                return _removeCommandW;
            }
        }

        private void addNewW()
        {
            try
            {
                Wyposazenie_nieruchomosciDetail _dlg = new Wyposazenie_nieruchomosciDetail();
                _dlg.AddNew = true;
                _dlg.Data = new Models.Wyposazenie_nieruchomosci();
                _dlg.Closed += (s, ea) =>
                {
                    if (_dlg.DialogResult == true)
                    {
                        _selected.Wyposazenie.Add(_dlg.Data);
                        if (_dataService.Update(_selected))
                        {
                            _dataService.AreDataLoaded = true;
                            Selected = _selected;
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
        private void editNewW()
        {
            try
            {
                Wyposazenie_nieruchomosciDetail _dlg = new Wyposazenie_nieruchomosciDetail();
                _dlg.AddNew = false;
                _dlg.Data = _selectedW;
                _dlg.Closed += (s, ea) =>
                {
                    if (_dlg.DialogResult == true)
                    {
                        if (_dataService.Update(_dlg.Data))
                        {
                            Selected = _selected;
                            SelectedW = _dlg.Data;
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
        private void removeNewW()
        {
            try
            {
                if (MessageBox.Show("Czy chcesz usunąć?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _dataService.AreDataLoaded = true;
                    if (_dataService.Remove(_selectedW, Selected.IdNieruchomosci))
                    {
                        Selected = _selected;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Pokoje
        public ViewModelCommand AddCommandPok
        {
            get
            {
                if (_addCommandPok == null)
                {
                    _addCommandPok = new ViewModelCommand(p => addNewPok(), p => (Selected != null) ? true : false);
                }
                return _addCommandPok;
            }
        }
        public ViewModelCommand EditCommandPok
        {
            get
            {
                if (_editCommandPok == null)
                {
                    _editCommandPok = new ViewModelCommand(p => editNewPok(), p => (SelectedPok != null) ? true : false);
                }
                return _editCommandPok;
            }
        }
        public ViewModelCommand RemoveCommandPok
        {
            get
            {
                if (_removeCommandPok == null)
                {
                    _removeCommandPok = new ViewModelCommand(p => removeNewPok(), p => (SelectedPok != null) ? true : false);
                }
                return _removeCommandPok;
            }
        }

        private void addNewPok()
        {
            try
            {
                PokojeDetail _dlg = new PokojeDetail();
                _dlg.AddNew = true;
                _dlg.Data = new Models.Pokoje();
                _dlg.Closed += (s, ea) =>
                {
                    if (_dlg.DialogResult == true)
                    {
                        _selected.Pokoje.Add(_dlg.Data);
                        if (_dataService.Update(_selected))
                        {
                            _dataService.AreDataLoaded = true;
                            Selected = _selected;
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
        private void editNewPok()
        {
            try
            {
                PokojeDetail _dlg = new PokojeDetail();
                _dlg.AddNew = false;
                _dlg.Data = _selectedPok;
                _dlg.Closed += (s, ea) =>
                {
                    if (_dlg.DialogResult == true)
                    {
                        if (_dataService.Update(_dlg.Data))
                        {
                            Selected = _selected;
                            SelectedPok = _dlg.Data;
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
        private void removeNewPok()
        {
            try
            {
                if (MessageBox.Show("Czy chcesz usunąć?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _dataService.AreDataLoaded = true;
                    if (_dataService.Remove(_selectedPok, Selected.IdNieruchomosci))
                    {
                        Selected = _selected;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region WyposazeniePokoju
        public ViewModelCommand AddCommandWPok
        {
            get
            {
                if (_addCommandWPok == null)
                {
                    _addCommandWPok = new ViewModelCommand(p => addNewWPok(), p => (Selected != null) ? true : false);
                }
                return _addCommandWPok;
            }
        }
        public ViewModelCommand EditCommandWPok
        {
            get
            {
                if (_editCommandWPok == null)
                {
                    _editCommandWPok = new ViewModelCommand(p => editNewWPok(), p => (SelectedWPok != null) ? true : false);
                }
                return _editCommandWPok;
            }
        }
        public ViewModelCommand RemoveCommandWPok
        {
            get
            {
                if (_removeCommandWPok == null)
                {
                    _removeCommandWPok = new ViewModelCommand(p => removeNewWPok(), p => (SelectedWPok != null) ? true : false);
                }
                return _removeCommandWPok;
            }
        }

        private void addNewWPok()
        {
            try
            {
                Wyposazenie_pokojuDetail _dlg = new Wyposazenie_pokojuDetail();
                _dlg.AddNew = true;
                _dlg.Data = new Models.Wyposazenie_pokoju();
                _dlg.Closed += (s, ea) =>
                {
                    if (_dlg.DialogResult == true)
                    {
                        _selectedPok.Wyposazenie.Add(_dlg.Data);
                        if (_dataService.Update(_selectedPok))
                        {
                            _dataService.AreDataLoaded = true;
                            SelectedPok = _selectedPok;
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
        private void editNewWPok()
        {
            try
            {
                Wyposazenie_pokojuDetail _dlg = new Wyposazenie_pokojuDetail();
                _dlg.AddNew = false;
                _dlg.Data = _selectedWPok;
                _dlg.Closed += (s, ea) =>
                {
                    if (_dlg.DialogResult == true)
                    {
                        if (_dataService.Update(_dlg.Data))
                        {
                            SelectedPok = _selectedPok;
                            SelectedWPok = _dlg.Data;
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
        private void removeNewWPok()
        {
            try
            {
                if (MessageBox.Show("Czy chcesz usunąć?", "Pytanie", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _dataService.AreDataLoaded = true;
                    if (_dataService.Remove(_selectedWPok, Selected.IdNieruchomosci, SelectedPok.IdPokoju))
                    {
                        SelectedPok = _selectedPok;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #endregion
    }
}
