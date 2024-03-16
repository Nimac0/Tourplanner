﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using tour_planner.DTOs;
using tour_planner.Models;

namespace tour_planner.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        public int IdCounter { get; set; } = 1;
        public ICommand AddTour { get; }
        public ICommand DeleteTour { get; }
        public ICommand ModifyTour { get; }

        public MainViewModel()
        {
            AddTour = new RelayCommand<List<string>>(Add);
            DeleteTour = new RelayCommand<string>(Delete);
            ModifyTour = new RelayCommand<string>(Modify);

            tourList = new ObservableCollection<TourInfo>() { };
            tourList.CollectionChanged += UpdateTourNameList;
        }

        ObservableCollection<TourInfo> tourList;
        public ObservableCollection<TourInfo> TourList
        {
            get => tourList;
            set
            {
                tourList = value;
                //UpdateTourNameList();
                OnPropertyChanged("TourList");
            }
        }
        ObservableCollection<string> tourNameList = new ObservableCollection<string> { };
        public ObservableCollection<string> TourNameList
        {
            get => tourNameList;
            set
            {
                tourNameList = value;
                OnPropertyChanged("TourNameList");
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

        private string selectedTour;
        public string SelectedTour
        {
            get { return selectedTour; }
            set
            {
                selectedTour = value;
                //if (selectedTour != null)
                    //TourLogList = new ObservableCollection<TourLog>(selectedTour.Tourlogs);
                //else
                    //TourLogList = null;
                OnPropertyChanged("SelectedTour");
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
                    TourNameList.Add(item.Name);
                    //TourLogList.Add(item.Tourlogs);
                }
            }
            if (e.OldItems != null)
            {
                foreach (TourInfo item in e.OldItems)
                {
                    TourNameList.Remove(TourNameList.Where(i => i == item.Name).Single());
                    //TourLogList.Add(item.Tourlogs);
                }
            }
        }

        public void Add(List<string> placeholder)
        {
            TourList.Add(new TourInfo
            {
                Id = IdCounter,
                Name = "TestValue1",
                PictureFilePath = "test1",
                Tourlogs = new List<TourLog>
                {
                    new TourLog
                    {
                        Date = "testvalues1",
                        Duration = "testduration1",
                        Distance = "testdistance1"
                    }
                }
            });
            IdCounter++;
        }

        public void Delete(string placeholder)
        {
            if (SelectedTour != null && TourList.Count() != 0)
            {
               TourList.Remove(TourList.Where(i => i.Name == SelectedTour).Single());
            }
        }

        public void Modify(string placeholder)
        {

        }

    }
}
