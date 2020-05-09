﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Data;
using System.Xml;
using System.Security.Policy;
using System.Linq;

namespace DatabaseW.Views.APIs
{
    
    public class vmDistance
    {
        public string durtion { get; set; }
        public double distance { get; set; }
    }
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
            cmbSearch.Items.Add("Apteka");
            cmbSearch.Items.Add("Kino");
            cmbSearch.Items.Add("Teatr");
            cmbSearch.Items.Add("Sklep");
            cmbSearch.Items.Add("Lotnisko");
            cmbSearch.Items.Add("Ratusz");
            cmbSearch.Items.Add("Drukarnia");
            cmbSearch.Items.Add("Galeria");
            cmbSearch.Items.Add("Uczelnia");
            cmbSearch.Items.Add("Park");
            cmbSearch.Items.Add("Siłownia");
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
                if (cmbSearch.SelectedItem == null)
                {
                    MessageBox.Show("Proszę wybrać typ POI z listy", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
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

        //private string GooglDistanceMatrixUrl(string input)
        //{
        //    string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins=";
        //    url += input;
        //    url += "&key=AIzaSyDxAC7sQJdA9a9LUIjmqf13oEY-whT8CEI";
        //    return url;
        //}

        private void btnDistance_Click(object sender, RoutedEventArgs e)
        {
            vmDistance objDistance = new vmDistance();
            try
            {
                string DistanceApiUrl = "https://maps.googleapis.com/maps/api/distancematrix/xml?origins=";
                string myKey = "AIzaSyDxAC7sQJdA9a9LUIjmqf13oEY-whT8CEI";
                _selected.FormattedAddress = string.Concat(Selected.FormattedAddress.Where(c => !char.IsWhiteSpace(c)));
                _selected.FormattedAddress = _selected.FormattedAddress.Replace(',', '+');
                _adres = string.Concat(txtAdres.Text.Where(c => !char.IsWhiteSpace(c)));
                _adres = _adres.Replace(',', '+');
                string url = DistanceApiUrl + _adres.Trim() + "&destinations=" + _selected.FormattedAddress.Trim() + "&mode=driving&sensor=false&language=en-EN&units=imperial" + "&key=" + myKey;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader sreader = new StreamReader(dataStream);
                string responsereader = sreader.ReadToEnd();
                response.Close();

                DataSet ds = new DataSet();
                ds.ReadXml(new XmlTextReader(new StringReader(responsereader)));
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables["element"].Rows[0]["status"].ToString() == "OK")
                    {
                        objDistance.durtion = Convert.ToString(ds.Tables["duration"].Rows[0]["text"].ToString().Trim());
                        objDistance.distance = Convert.ToDouble(ds.Tables["distance"].Rows[0]["text"].ToString().Replace("ft", "").Trim());
                    }
                }
                txtDuration.Text = objDistance.durtion;
                txtDistance.Text = Convert.ToString(objDistance.distance);
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.InnerException != null) ? ex.Message + "\n\r\n\r" + ex.InnerException.Message : ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
