using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using tour_planner.DTOs;
using tour_planner.Models;

namespace tour_planner.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        
        public ICommand AddTour { get; }
        public ICommand DeleteTour { get; }
        public ICommand ModifyTour { get; }

        public MainViewModel()
        {
            AddTour = new RelayCommand<List<string>>(Add);
            DeleteTour = new RelayCommand<string>(Delete);
            ModifyTour = new RelayCommand<string>(Modify);

            Observer.Instance.TourList = new ObservableCollection<TourInfo>() { };
            Observer.Instance.TourList.CollectionChanged += UpdateTourNameList;
        }

        public ObservableCollection<TourInfo> TourList
        {
            get => Observer.Instance.TourList;
            set
            {
                Observer.Instance.TourList = value;
                //UpdateTourNameList();
                OnPropertyChanged("TourList");
            }
        }

        ObservableCollection<TourLog> tourLogList = new ObservableCollection<TourLog> { };
        public ObservableCollection<TourLog> TourLogList
        {
            get => tourLogList;
            set
            {
                tourLogList = value;
                OnPropertyChanged("TourLogList");
            }
        }

        private TourInfo selectedTour;
        public TourInfo SelectedTour
        {
            get { return selectedTour; }
            set
            {
                selectedTour = value;
                OnPropertyChanged("SelectedTour");
            }
        }

        //private Visibility tourInputVisible = Visibility.Collapsed;
        public Visibility TourInputVisible
        {
            get {
                //return tourInputVisible;
                return Observer.Instance.TourInputVisible;
            }
            set
            {
                Observer.Instance.TourInputVisible = value;
                OnPropertyChanged("TourInputVisible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        void UpdateTourNameList(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TourInfo item in e.NewItems)
                {
                    //TourLogList.Add(item.Tourlogs);
                }
            }
            if (e.OldItems != null)
            {
                foreach (TourInfo item in e.OldItems)
                {
                    //TourLogList.Remove(TourLogList.Where(i => i.id == item.id).Single());
                }
            }
        }

        public void ConvertInputToTour()
        {

        }

        public void CalculateDistance()
        {

        }

        public void CalculateTime()
        {

        }

        public void Add(List<string> placeholder)
        {
            this.TourInputVisible = Visibility.Visible;
            
        }

        public void Delete(string placeholder)
        {
            if (SelectedTour != null && TourList.Count() != 0)
            {
               TourList.Remove(SelectedTour);
            }
        }

        public void Modify(string placeholder)
        {
            if (SelectedTour != null && TourList.Count() != 0)
            {
                SelectedTour.Name = "TestValue1";
                SelectedTour.Description = "this is a modified description";
                SelectedTour.ModeOfTransportation = "Car";
                SelectedTour.RouteInfo.From = "test";
                SelectedTour.RouteInfo.To = "test2";
                SelectedTour.RouteInfo.Distance = "test"; //calculate distance func?
                SelectedTour.RouteInfo.EstimateTime = "test";
                SelectedTour.RouteInfo.PictureFilePath = "test";
            }
        }

        

    }
}
