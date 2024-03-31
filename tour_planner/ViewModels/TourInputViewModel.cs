using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using tour_planner.DTOs;

namespace tour_planner.ViewModels
{
    public class TourInputViewModel : INotifyPropertyChanged, IListener
    {
        public int IdCounter { get; set; } = 1;
        public ICommand SubmitTourInput { get; }
        public ICommand CancelTourInput { get; }

        public TourInputViewModel()
        {
            SubmitTourInput = new RelayCommand<string>(Submit);
            CancelTourInput = new RelayCommand<string>(Cancel);

            Observer.Instance.registerListener(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Visibility TourInputVisible
        {
            get
            {
                //return tourInputVisible;
                return Observer.Instance.TourInputVisible;
            }
            set
            {
                Observer.Instance.TourInputVisible = value;
                OnPropertyChanged("TourInputVisible");
            }
        }

        public void OnUpdate()
        {
            OnPropertyChanged("TourInputVisible");
        }

        public void Submit(string placeholder)
        {
            Observer.Instance.TourList.Add(new TourInfo
            {
                Id = IdCounter,
                Name = "TestValue1",
                Description = "this is a description",
                ModeOfTransportation = "Bike",
                Tourlogs = new List<TourLog>
                {
                    new TourLog
                    {
                        Date = new DateTime(2023,03,03),
                        Duration = new TimeSpan(30),
                        Distance = 2,
                        Difficulty = "Easy",
                        Rating = "5/5",
                        Comment = "this is a comment"
                    },
                    new TourLog
                    {
                        Date = new DateTime(2023,03,03),
                        Duration = new TimeSpan(30),
                        Distance = 2,
                        Difficulty = "Easy",
                        Rating = "5/5",
                        Comment = "this is a comment"
                    }
                },
                RouteInfo = new RouteInfo
                {
                    From = "test", 
                    To = "test2",
                    Distance = "test",
                    EstimateTime = "test",
                    PictureFilePath = "test"
                }
            });
            IdCounter++;
            this.TourInputVisible = Visibility.Collapsed;
        }

        public void Cancel(string placeholder)
        {
            this.TourInputVisible = Visibility.Collapsed;
        }
    }
}
