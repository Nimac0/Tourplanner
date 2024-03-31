using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using tour_planner.ViewModels;

namespace tour_planner.UserControls
{
    /// <summary>
    /// Interaction logic for TourInputView.xaml
    /// </summary>
    public partial class TourInputView : UserControl
    {
        public TourInputView()
        {
            InitializeComponent();
            DataContext = new ViewModels.TourInputViewModel();
        }
    }
}
