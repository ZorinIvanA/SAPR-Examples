using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DataBinding
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public Decimal PriceMin { get; set; }
        public Decimal? PriceMax { get; set; }

        private UInt32 _areaMin;
        public UInt32 AreaMin {
            get { return _areaMin; }
            set
            {
                _areaMin = value;
                DoPropertyChanged("AreaMin");
            }
        }
        public UInt32? AreaMax { get; set; }

        public Dictionary<String, Color> MetroStations { get; set; }

        private KeyValuePair<String, Color> _selectedStation;
        public KeyValuePair<String, Color> SelectedStation
        {
            get { return _selectedStation; }
            set
            {
                _selectedStation = value;
                DoPropertyChanged("SelectedStation");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void DoPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public ObservableCollection<FlatViewModel> Flats { get; set; }

        public ICommand Filter { get; set; }

        public MainWindowViewModel()
        {
            FillStations();
            FillFlats();
            Filter = new FilterCommand();
        }

        private void FillStations()
        {
            MetroStations = new Dictionary<string, Color>();
            MetroStations.Add("Академическая", Colors.Orange);
            MetroStations.Add("Профсоюзная", Colors.Orange);
            MetroStations.Add("Октябрьская", Colors.Orange);
            MetroStations.Add("Шаболовская", Colors.Orange);
            MetroStations.Add("Нахимовский проспект", Colors.Gray);
            MetroStations.Add("Севастопольская", Colors.Gray);
            MetroStations.Add("Коломенская", Colors.DarkGreen);
        }

        private void FillFlats()
        {
            Flats = new ObservableCollection<FlatViewModel>();
            Flats.Add(
                new FlatViewModel()
                {
                    Adress = "Профсоюзная ул. д. 1",
                    Area = 40,
                    Price = 2000000,
                    Number = "100",
                    SubwayStation = "Профсоюзная"
                });
            Flats.Add(
                new FlatViewModel()
                {
                    Adress = "Профсоюзная ул. д. 5",
                    Area = 20,
                    Price = 1500000,
                    Number = "50",
                    SubwayStation = "Профсоюзная"
                });
            Flats.Add(
                new FlatViewModel()
                {
                    Adress = "Азовская ул. д. 3",
                    Area = 20,
                    Price = 1520000,
                    Number = "20",
                    SubwayStation = "Севастопольская"
                });
        }
    }
}
