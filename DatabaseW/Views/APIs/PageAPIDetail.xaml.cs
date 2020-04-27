using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;

namespace DatabaseW.Views.APIs
{
    public partial class PageAPIDetail : Window
    {
        private string _adres;

        private ObservableCollection<Models.Local.PageAPI> _dataList;
        private Models.Local.PageAPI _selected;

        public Models.Local.PageAPI Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public PageAPIDetail(string adres)
        {
            _adres = adres;
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            txtAdres.Text = _adres;
            cmbSearch.Items.Add("Bankomat");
            cmbSearch.Items.Add("Bar");
            cmbSearch.Items.Add("Restauracja");
            cmbSearch.Items.Add("Szkoła");
            //tu można dodać więcej opcji
            //////////////////////////////////////////////////
            //////////////////////////////////////////////////
            //////////////////////////////////////////////////
            //////////////////////////////////////////////////
            //////////////////////////////////////////////////
            //////////////////////////////////////////////////
            //////////////////////////////////////////////////
            //////////////////////////////////////////////////
            //////////////////////////////////////////////////
        }

        private void WbMapSearch_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            SetSilent(WbMapSearch, true);
        }

        public static void SetSilent(WebBrowser browser, bool silent)
        {
            if (browser == null)
                throw new ArgumentNullException("browser");

            IOleServiceProvider sp = browser.Document as IOleServiceProvider;
            if (sp != null)
            {
                Guid IID_IWebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
                Guid IID_IWebBrowser2 = new Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E");

                object webBrowser;
                sp.QueryService(ref IID_IWebBrowserApp, ref IID_IWebBrowser2, out webBrowser);
                if (webBrowser != null)
                {
                    webBrowser.GetType().InvokeMember("Silent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.PutDispProperty, null, webBrowser, new object[] { silent });
                }
            }
        }

        [ComImport, Guid("6D5140C1-7436-11CE-8034-00AA006009FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IOleServiceProvider
        {
            [PreserveSig]
            int QueryService([In] ref Guid guidService, [In] ref Guid riid, [MarshalAs(UnmanagedType.IDispatch)] out object ppvObject);
        }

        private string GooglePlaceUrl(string input)
        {
            string url = "https://maps.googleapis.com/maps/api/place/textsearch/json?query=";
            url += HttpUtility.UrlEncode(input, Encoding.UTF8);
            url += "&key=AIzaSyAVgl184eqSfpsflfzIpTbV5Ra9Hr7nE9E";
            return url;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _dataList = new ObservableCollection<Models.Local.PageAPI>();
                string url = cmbSearch.SelectedItem.ToString().Trim() + "+in+" + txtAdres.Text.Trim();
                url = GooglePlaceUrl(url);
                WebClient webC = new WebClient() { Encoding = Encoding.UTF8 };
                var json = webC.DownloadString(new Uri(url));
                JObject ex = JObject.Parse(json);
                JArray results = (JArray)ex["results"];

                Models.Local.PageAPI search;

                foreach (var r in results)
                {
                    search = new Models.Local.PageAPI();
                    search.FormattedAddress = (string)r["formatted_address"];
                    search.Name = (string)r["name"];
                    search.Lat = (string)r["geometry"]["location"]["lat"];
                    search.Lng = (string)r["geometry"]["location"]["lng"];
                    search.Place_id = (string)r["place_id"];
                    _dataList.Add(search);
                }
                dataGridSearch.ItemsSource = null;
                dataGridSearch.ItemsSource = _dataList;
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDistance_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //metoda dla Distance Matrix 
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
