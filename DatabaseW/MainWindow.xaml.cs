using System;
using System.Linq;
using System.Windows;
using Xceed.Wpf.AvalonDock.Layout;

namespace DatabaseW
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var ctx = App.Ctx.Osobies.ToList<Models.Osoby>();
            }
            catch (Exception ex)
            {

            }

        }

        #region Event
        private void tviNierychomosci_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            foreach (LayoutDocument l in PaneLayoutDocument.Children.Where(p => p.Title.Equals("Nieruchomosci")))
            {
                l.IsActive = true;
                return;
            }

            LayoutDocument ld = new LayoutDocument();
            ld.Title = "Nieruchomosci";

            ld.Content = App._vNieruchomosci;
            PaneLayoutDocument.Children.Add(ld);
        }
        private void tviOsoby_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            foreach (LayoutDocument l in PaneLayoutDocument.Children.Where(p => p.Title.Equals("Osoby")))
            {
                l.IsActive = true;
                return;
            }

            LayoutDocument ld = new LayoutDocument();
            ld.Title = "Osoby";

            ld.Content = App._vOsoby;
            PaneLayoutDocument.Children.Add(ld);
        }
        private void tviNajem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            foreach (LayoutDocument l in PaneLayoutDocument.Children.Where(p => p.Title.Equals("Najem")))
            {
                l.IsActive = true;
                return;
            }

            LayoutDocument ld = new LayoutDocument();
            ld.Title = "Najem";

            ld.Content = App._vNajem;
            PaneLayoutDocument.Children.Add(ld);
        }

        private void treeWoj_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            foreach(LayoutDocument l in PaneLayoutDocument.Children.Where(p => p.Title.Equals("Wojewodztwa")))
            {
                l.IsActive = true;
                return;
            }

            LayoutDocument ld = new LayoutDocument();
            ld.Title = "Wojewodztwa";

            ld.Content = App._vSlownik_Wojewodztw;
            PaneLayoutDocument.Children.Add(ld);
        }

        private void treeWyp_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            foreach (LayoutDocument l in PaneLayoutDocument.Children.Where(p => p.Title.Equals("Wyposażenie")))
            {
                l.IsActive = true;
                return;
            }

            LayoutDocument ld = new LayoutDocument();
            ld.Title = "Wyposażenie";

            ld.Content = App._vSlownik_wyposazen;
            PaneLayoutDocument.Children.Add(ld);
        }

        private void treeTyp_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            foreach (LayoutDocument l in PaneLayoutDocument.Children.Where(p => p.Title.Equals("Typ nieruchomości")))
            {
                l.IsActive = true;
                return;
            }

            LayoutDocument ld = new LayoutDocument();
            ld.Title = "Typ nieruchomości";

            ld.Content = App._vTyp_nieruchomosci;
            PaneLayoutDocument.Children.Add(ld);
        }
        #endregion
    }
}
