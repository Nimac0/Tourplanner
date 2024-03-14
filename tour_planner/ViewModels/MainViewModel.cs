using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tour_planner.DTOs;
using tour_planner.Models;

namespace tour_planner.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {

        public ICommand AddTour { get; }
        public ICommand DeleteTour { get; }
        public ICommand ModifyTour { get; }

        public MainViewModel()
        {
            AddTour = new RelayCommand<List<string>>(Add);
            DeleteTour = new RelayCommand<string>(Delete);
            ModifyTour = new RelayCommand<string>(Modify);
        }

        ObservableCollection<string> tourNameList = new ObservableCollection<string>
        {
            "test","test2","test3"
        };
        public ObservableCollection<string> TourNameList
        {
            get => tourNameList;
            set
            {
                tourNameList = value;
                OnPropertyChanged("TourNameList");
            }
        }

        ObservableCollection<TourLog> tourLogList = new ObservableCollection<TourLog> {
            new TourLog { Date = "testvalues", Duration = "testduration", Distance = "testdistance"},
            new TourLog { Date = "testvalues", Duration = "testduration", Distance = "testdistance"}
        };
        public ObservableCollection<TourLog> TourLogList
        {
            get => tourLogList;
            set
            {
                tourLogList = value;
                OnPropertyChanged("TourLogList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Add(List<string> placeholder)
        {
            TourNameList.Add("yet another test value");
        }

        public void Delete(string placeholder)
        {

        }

        public void Modify(string placeholder)
        {

        }

    }
}
