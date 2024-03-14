using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
namespace tour_planner
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel();
        }
        private void SearchTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                PlaceholderTextBlock.Visibility = Visibility.Visible;
            }
            else
                PlaceholderTextBlock.Visibility = Visibility.Collapsed;
            
        }
    }
}
