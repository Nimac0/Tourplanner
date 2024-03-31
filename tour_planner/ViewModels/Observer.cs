using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using tour_planner.DTOs;

namespace tour_planner.ViewModels
{
    // not thread-safe
    public sealed class Observer
    {
        private static Observer instance = null;

        private Observer()
        {
        }

        public static Observer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Observer();
                }
                return instance;
            }
        }

        private IListener listener;

        public void registerListener(IListener listener)
        {
            this.listener = listener;
        }

        private Visibility tourInputVisible = Visibility.Collapsed;
        public Visibility TourInputVisible
        {
            get
            {
                return this.tourInputVisible;
            }
            set
            {
                this.tourInputVisible = value;
                this.listener.OnUpdate();
            }
        }
        
        private ObservableCollection<TourInfo> tourList;
        public ObservableCollection<TourInfo> TourList
{
            get
            {
                return this.tourList;
            }
            set
            {
                this.tourList = value;
                this.listener.OnUpdate();
            }
        }
    }
}
