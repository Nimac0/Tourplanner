using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
namespace tour_planner
{

    public class MyData
    {
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public double Distance { get; set; }
    }
    public partial class MainWindow : Window
    {
            List<MyData> data = new List<MyData>
            {
             
            };
        public MainWindow()
        {
          
            InitializeComponent();
            MyDataGrid.ItemsSource = data;
            var uri = new Uri("pack://application:,,,/tour_planner;component/imgs/rute/ruta1.png", UriKind.Absolute);
            var bitmap = new BitmapImage(uri);
            RutaImg.Source = bitmap;
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

        // Read operation
        private void Tours_ReadButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your read logic here
            MessageBox.Show("Read operation");
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
            // Implement your create logic here
            //MessageBox.Show("Create operation!");
            // data.Add(new MyData { Date = DateTime.Now, Duration = TimeSpan.FromMinutes(45), Distance = "Value " });
            if (TimeSpan.TryParse(DurationTextBox.Text, out TimeSpan duration) &&
                double.TryParse(DistanceTextBox.Text, out double distance))
            {
                // Add a new item to the list
                data.Add(new MyData() { Date = DateTime.Now, Duration = duration, Distance = distance });
                MyDataGrid.Items.Refresh();
                MessageBox.Show("Item created successfully.");
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid values.");
            }


            MyDataGrid.Items.Refresh();
        }

        // Read operation
        private void ToursLog_ReadButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your read logic here
            MessageBox.Show("Read operation!");
        }

        // Update operation
        private void ToursLog_UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your update logic here
            MessageBox.Show("Update operation!");
        }

        // Delete operation
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your delete logic here
            MessageBox.Show("Delete operation!");
        }
    }
}
