using System.Windows;
using System.Windows.Controls;

namespace DatabaseW.Views.Nieruchomosci
{
    public partial class NieruchomosciList : UserControl
    {
        public NieruchomosciList()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App._oNieruchomosc;
        }
    }
}
