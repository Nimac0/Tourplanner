using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using tour_planner.DTOs;

namespace tour_planner
{
    public partial class MainWindow : Window
    {
        List<TourLog> data = new List<TourLog>
        {

        };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModels.MainViewModel();
            MyDataGrid.ItemsSource = data;
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

        private void Tours_CreateButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your create logic here
            MessageBox.Show("Create operation");
        }

        // Update operation
        private void Tours_UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your update logic here
            MessageBox.Show("Update operation");
        }

        // Delete operation
        private void Tours_DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your delete logic here
            MessageBox.Show("Delete operation");
        }
        private void ToursLog_CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TimeSpan.TryParse(DurationTextBox.Text, out TimeSpan duration) &&
                float.TryParse(DistanceTextBox.Text, out float distance))
            {
                data.Add(new TourLog() { Date = DateTime.Now, Duration = duration, Distance = distance });
                MyDataGrid.Items.Refresh();
                MessageBox.Show("Item created successfully.");
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid values.");
            }
            MyDataGrid.Items.Refresh();
        }


        private void ToursLog_UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (data.Count > 0)
            {
                var item = data[0];
                item.Date = DateTime.Now;
                item.Duration = TimeSpan.FromMinutes(45);
                item.Distance = 15;
                MyDataGrid.Items.Refresh();
                MessageBox.Show("Item updated successfully.");
            }
            else
            {
                MessageBox.Show("No items to update.");
            }
        }

        // Delete operation
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (data.Count > 0)
            {
                data.RemoveAt(0);
                MyDataGrid.Items.Refresh();
                MessageBox.Show("Item deleted successfully.");
            }
            else
            {
                MessageBox.Show("No items to delete.");
            }
        }

        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            //objUpdate
        }
    }
}
