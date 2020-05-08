using System.Threading;
using System.Windows;

namespace DatabaseW.DataViewModel
{
    public partial class GetData : Window
    {
        Thread loadedThreadd = null;
        //private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);

        public GetData()
        {
            InitializeComponent();
            progressBar.Minimum = 0;
            progressBar.Maximum = 10;
            progressBar.Value = 0;
            labelCo.Content = "";
        }

        public void getThread(Thread watek)
        {
            loadedThreadd = watek;
        }

        public void closeThread()
        {
            loadedThreadd.Interrupt();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadedThreadd.Start();
        }
    }
}
