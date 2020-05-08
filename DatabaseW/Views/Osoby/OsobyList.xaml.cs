using System.Windows;
using System.Windows.Controls;

namespace DatabaseW.Views.Osoby
{
    public partial class OsobyList : UserControl
    {
        public OsobyList()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App._oOsoba;
        }
    }
}
