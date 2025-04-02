using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;
using SEP_Age.Models;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts.Definitions.Charts;
using System.Collections.ObjectModel;

namespace SEP_Age
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ObservableValue> ChartValues { get; set; }
        public SeriesCollection SeriesCollection { get; set; }

        private AppDbContext _context;

        public MainWindow()
        {
            InitializeComponent();
            SeriesCollection = new SeriesCollection();
            ChartValues = new ObservableCollection<ObservableValue>();
            LoadData();
            DataContext = this;
        }

        private void LoadData()
        {
            try
            {
                using (_context = new AppDbContext())
                {
                    DataContext = this;

                    проектыGrid.ItemsSource = _context.Проектs.ToList();
                    площадиGrid.ItemsSource = _context.Площадьs.ToList();
                    профилиGrid.ItemsSource = _context.Профильs.ToList();
                    пунктыНаблюденияGrid.ItemsSource = _context.ПунктыНаблюдs.ToList();
                    измеренияGrid.ItemsSource = _context.Измеренияs.ToList();
                    кордыGrid.ItemsSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void проектыGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedProject = проектыGrid.SelectedItem as Проект;
            if (selectedProject != null)
            {
                using (_context = new AppDbContext())
                {
                    var площади = _context.СписокПлощадейs
                        .Where(sp => sp.IdПроекта == selectedProject.Id) 
                        .Select(sp => sp.IdПлощадиNavigation)
                        .ToList();

                    площадиGrid.ItemsSource = площади;
                }
            }
        }
        private void площадиGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedПлощадь = площадиGrid.SelectedItem as Площадь;
            if (selectedПлощадь != null)
            {
                using (_context = new AppDbContext())
                {
                    var профили = _context.СписокПрофилейs
                        .Where(sp => sp.IdПлощади == selectedПлощадь.Id)
                        .Select(sp => sp.IdПрофиляNavigation)
                        .ToList();

                    профилиGrid.ItemsSource = профили;

                    var координаты = _context.КоординатыПлощадиs
                        .Where(k => k.IdПлощади == selectedПлощадь.Id)
                        .ToList();

                    кордыGrid.ItemsSource = координаты;
                    DrawПлощади(координаты);
                }
            }
        }
        private void DrawПлощади(List<КоординатыПлощади> координаты)
        {
            Bitmap bitmap = new Bitmap(420,360);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {

                graphics.Clear(System.Drawing.Color.White);
                System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);

                if (координаты.Count > 1)
                {
                    for (int i = 1; i < координаты.Count; i++)
                    {
                        graphics.DrawLine(pen, координаты[i - 1].X, координаты[i - 1].Y, координаты[i].X, координаты[i].Y);
                    }
                    graphics.DrawLine(pen, координаты[координаты.Count - 1].X, координаты[координаты.Count - 1].Y, координаты[0].X, координаты[0].Y);
                }
            }

            using (var memory = new System.IO.MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                pictureBox.Source = bitmapImage;
            }
        }

        private void DrawПрофили(List<КоординатыПрофиля> координаты)
        {
            Bitmap bitmap = new Bitmap(420, 360);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {

                graphics.Clear(System.Drawing.Color.White);
                System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.Black, 1);

                if (координаты.Count > 1)
                {
                    for (int i = 1; i < координаты.Count; i++)
                    {
                        graphics.DrawLine(pen, координаты[i - 1].X, координаты[i - 1].Y, координаты[i].X, координаты[i].Y);
                    }
                    graphics.DrawLine(pen, координаты[координаты.Count - 1].X, координаты[координаты.Count - 1].Y, координаты[0].X, координаты[0].Y);
                }
            }

            using (var memory = new System.IO.MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                pictureBox.Source = bitmapImage;
            }
        }

        private void профилиGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedПрофиль = профилиGrid.SelectedItem as Профиль;
            if (selectedПрофиль != null)
            {
                using (_context = new AppDbContext())
                {
                    var пункты = _context.СписокПунктовs
                        .Where(sp => sp.IdПрофиля == selectedПрофиль.Id)
                        .Select(sp => sp.IdПунктаNavigation)
                        .ToList();

                    пунктыНаблюденияGrid.ItemsSource = пункты;

                    var координаты = _context.КоординатыПрофиляs
                        .Where(k => k.IdПлощади == selectedПрофиль.Id) 
                        .ToList();

                    кордыGrid.ItemsSource = координаты;
                    DrawПрофили(координаты);
                }
            }
        }

        private void пунктыНаблюденияGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedПункт = пунктыНаблюденияGrid.SelectedItem as ПунктыНаблюд;
            if (selectedПункт != null)
            {
                using (_context = new AppDbContext())
                {
                    var измерения = _context.СписокИзмеренийs
                        .Where(si => si.IdПункта == selectedПункт.Id)
                        .Select(si => si.IdИзмеренияNavigation)
                        .ToList();

                    измеренияGrid.ItemsSource = измерения;
                }
            }

        }
        private void измеренияGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedMeasurement = измеренияGrid.SelectedItem as Измерения;
            if (selectedMeasurement != null)
            {
                var allMeasurements = GetAllMeasurements();
                ChartValues.Clear();
                foreach (var measurement in allMeasurements)
                {
                    ChartValues.Add(new ObservableValue(measurement.Давление));
                }

                var lineSeries = new LineSeries
                {
                    Title = "Измерения",
                    Values = new ChartValues<ObservableValue>(ChartValues)
                };

                SeriesCollection.Clear();
                SeriesCollection.Add(lineSeries);
            }
        }

        private List<Измерения> GetAllMeasurements()
        {
            return измеренияGrid.ItemsSource?.Cast<Измерения>().ToList();
        }

        private void сбросButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (_context = new AppDbContext())
                {
                    проектыGrid.ItemsSource = _context.Проектs.ToList();
                    площадиGrid.ItemsSource = _context.Площадьs.ToList();
                    профилиGrid.ItemsSource = _context.Профильs.ToList();
                    пунктыНаблюденияGrid.ItemsSource = _context.ПунктыНаблюдs.ToList();
                    измеренияGrid.ItemsSource = _context.Измеренияs.ToList();
                    кордыGrid.ItemsSource = null;
                    pictureBox.Source = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сбросе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
