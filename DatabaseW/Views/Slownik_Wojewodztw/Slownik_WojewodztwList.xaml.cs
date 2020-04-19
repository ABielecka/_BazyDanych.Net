using System.Windows;
using System.Windows.Controls;

namespace DatabaseW.Views.Slownik_Wojewodztw
{
    public partial class Slownik_WojewodztwList : UserControl
    {
        public Slownik_WojewodztwList()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = App._oSlownik_Wojewodztw;
        }
    }
}
