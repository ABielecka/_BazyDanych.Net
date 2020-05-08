using System.Windows;
using System.Windows.Controls;

namespace DatabaseW.Views.Typ_nieruchomosci
{
    public partial class Typ_nieruchomosciList : UserControl
    {
        public Typ_nieruchomosciList()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App._oTyp;
        }
    }
}
