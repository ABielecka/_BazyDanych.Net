using DatabaseW.DataViewModel;
using System;
using System.Threading;
using System.Windows;

namespace DatabaseW.Views
{
    public partial class Login : Window
    {
        bool _closed = false;

        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_closed)
            {
                MainWindow mainWnd = new MainWindow();
                LoadData();
                mainWnd.Show();
            }
        }

        private void LoadData()
        {
            try
            {
                LoadDataStart loadData = null;
                Thread loadedThread = null;
                GetData dlg = new GetData();

                loadData = new LoadDataStart(dlg);
                loadedThread = new Thread(new ThreadStart(loadData.Run));
                loadedThread.IsBackground = false;

                dlg.getThread(loadedThread);
                dlg.ShowDialog();
                dlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            _closed = false;
            Application.Current.Shutdown();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            _closed = true;
            this.Close();
        }
    }
}
