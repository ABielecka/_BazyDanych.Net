using System.Windows;
using System.Windows.Controls;

namespace DatabaseW.Views.Slownik_wyposazen
{
    public partial class Slownik_wyposazenList : UserControl
    {
        public Slownik_wyposazenList()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App._oSlownik_wyposazen;
        }
    }
}
