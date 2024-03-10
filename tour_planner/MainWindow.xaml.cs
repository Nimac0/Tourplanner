using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;
namespace tour_planner
{

    public class MyData
    {
        public string Date { get; set; }
        public string Duration { get; set; }
        public string Distance { get; set; }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<MyData> data = new List<MyData>
            {
                new MyData { Date = "Value 1", Duration = "Value 2", Distance = "Value 3" },
                new MyData { Date = "Value 4", Duration = "Value 5", Distance = "Value 6" },
                new MyData { Date = "Value 7", Duration = "Value 8", Distance = "Value 9" },
                new MyData { Date = "Value 10", Duration = "Value 11", Distance = "Value 12" }
            };
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
    }
}
