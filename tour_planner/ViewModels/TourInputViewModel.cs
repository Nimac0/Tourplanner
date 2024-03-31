using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using tour_planner.DTOs;

namespace tour_planner.ViewModels
{
    public class TourInputViewModel : INotifyPropertyChanged, IListener
    {
        public int IdCounter { get; set; } = 1;
        public ICommand SubmitTourInput { get; }
        public ICommand CancelTourInput { get; }

        public TourInfoInput TourUserInput
        {
            get { return Observer.Instance.TourUserInput; }
            set
            {
                Observer.Instance.TourUserInput = value;
                OnPropertyChanged("TourUserInput");
            }
        }

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
            OnPropertyChanged("TourUserInput");
        }


        public bool IsAnyNullOrEmpty(TourInfoInput userInput)
        {
            foreach (PropertyInfo pi in userInput.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(userInput);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                    return false;
                }
                if (pi.PropertyType == null)
                {
                    return true;
                }
            }
            return false;
        }

        public TourInfo ConvertInputToTour(TourInfoInput userInput)
        {
            return new TourInfo()
            {
                Id = IdCounter,
                Name = userInput.Tourname,
                Description = userInput.Description,
                ModeOfTransportation = userInput.Transportation,
                Tourlogs = new List<TourLog>() { },
                RouteInfo = new RouteInfo
                {
                    From = userInput.From,
                    To = userInput.To,
                    Distance = "",
                    EstimateTime = "",
                    PictureFilePath = ""
                }
            };
        }

        public void ClearInputFields()
        {
            this.TourUserInput = new TourInfoInput();
            this.TourUserInput.Tourname = string.Empty;
            this.TourUserInput.Description = string.Empty;
            this.TourUserInput.Transportation = string.Empty;
            this.TourUserInput.From = string.Empty;
            this.TourUserInput.To = string.Empty;
        }

        public void Submit(string placeholder)
        {
            if (this.IsAnyNullOrEmpty(this.TourUserInput))
            {
                this.TourInputVisible = Visibility.Collapsed;
                return;
            }
            
            if (this.TourUserInput.Modify)
            {
                TourInfo modifiedTour = Observer.Instance.TourList.ElementAt(Observer.Instance.SelectedTour.Id - 1);
                modifiedTour.Name = this.TourUserInput.Tourname;
                modifiedTour.Description = this.TourUserInput.Description;
                modifiedTour.ModeOfTransportation = this.TourUserInput.Transportation;
                modifiedTour.RouteInfo.From = this.TourUserInput.From;
                modifiedTour.RouteInfo.To = this.TourUserInput.To;
                int index = Observer.Instance.SelectedTour.Id-1;
                if (index >= 0 && index < Observer.Instance.TourList.Count)
                {
                    Observer.Instance.TourList[index] = modifiedTour;
                }
                this.ClearInputFields();
                this.TourInputVisible = Visibility.Collapsed;

                Observer.Instance.TourList.Add(null);
                Observer.Instance.TourList.Remove(null);
                return;
            }
            TourInfo newTour = ConvertInputToTour(this.TourUserInput);
            Observer.Instance.TourList.Add(newTour);
            IdCounter++;
            this.ClearInputFields();
            this.TourInputVisible = Visibility.Collapsed;
             
        }

        public void Cancel(string placeholder)
        {
            this.TourInputVisible = Visibility.Collapsed;
        }
    }
}
