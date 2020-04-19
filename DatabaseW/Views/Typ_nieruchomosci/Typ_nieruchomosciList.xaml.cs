using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseW.Views.Typ_nieruchomosci
{
    /// <summary>
    /// Interaction logic for Typ_nieruchomosciList.xaml
    /// </summary>
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
