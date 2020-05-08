using DatabaseW.DataViewModel;

namespace DatabaseW.Models.Local
{
    public class PageAPI : ViewModel
    {
        #region Private Members
        private string formattedAddress;
        private string lat;
        private string lng;
        private string name;
        private string place_id;
        #endregion Private Members

        #region Constructors
        public PageAPI()
        {
        }
        #endregion Constructors

        #region Public Attributes
        public string FormattedAddress
        {
            get { return formattedAddress; }
            set { formattedAddress = value; NotifyPropertyChanged("FormattedAddress"); }
        }

        public string Lat
        {
            get { return lat; }
            set { lat = value; NotifyPropertyChanged("Lat"); }
        }

        public string Lng
        {
            get { return lng; }
            set { lng = value; NotifyPropertyChanged("Lng"); }
        }

        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }

        public string Place_id
        {
            get { return place_id; }
            set { place_id = value; NotifyPropertyChanged("Place_id"); }
        }
        #endregion Public Attributes
    }
}
