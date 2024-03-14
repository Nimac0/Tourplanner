using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourplanner.ViewModels
{
    public class TourListViewModel: INotifyPropertyChanged
    {
        List<string> tournameList;
        public List<string> TournameList
        {
            get => tournameList;
            set
            {
                tournameList = value;
                OnPropertyChanged("TournameList");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
