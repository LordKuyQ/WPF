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
using SEP_Age.Auto;
using Microsoft.EntityFrameworkCore;

namespace SEP_Age
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ObservableValue> ChartValues { get; set; }
        public SeriesCollection SeriesCollection { get; set; }

        private AppDbContext _context;

        public MainWindow()
        {

            SeriesCollection = new SeriesCollection();
            ChartValues = new ObservableCollection<ObservableValue>();
            DataContext = this;

            AutUser autUser = new AutUser();

            autUser.ShowDialog();

            if (autUser.DialogResult == false)
            {
                Close();
            }

            InitializeComponent();
            LoadData();
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
            pictureBox.Visibility = Visibility.Visible;
            MeasurementsChart.Visibility = Visibility.Hidden;
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

        private void DrawПрофили(List<КоординатыПрофиля> координаты)
        {
            pictureBox.Visibility = Visibility.Visible;
            MeasurementsChart.Visibility = Visibility.Hidden;
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
            pictureBox.Visibility = Visibility.Hidden;
            MeasurementsChart.Visibility = Visibility.Visible;
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
            pictureBox.Visibility = Visibility.Hidden;
            MeasurementsChart.Visibility = Visibility.Hidden;
        }

        private void синтButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new AppDbContext())
                {
                    var random = new Random();

                    var новыйПроект = new Проект
                    {
                        Id = context.Проектs.Max(p => p.Id) + 1,
                        ДатаНачала = DateTime.Now,
                        ДатаКонца = DateTime.Now.AddDays(30),
                        Цена = random.Next(10000, 10000000)
                    };
                    context.Проектs.Add(новыйПроект);
                    context.SaveChanges(); 

                    var новаяПлощадь = new Площадь
                    {
                        Id = context.Площадьs.Max(p => p.Id) + 1,
                        Площадь1 = random.Next(10, 1000),
                        Координаты = random.Next(100, 1000)
                    };
                    context.Площадьs.Add(новаяПлощадь);
                    context.SaveChanges();

                    context.Database.ExecuteSqlRaw(
                        "INSERT INTO список_площадей (id_проекта, id_площади) VALUES ({0}, {1})",
                        новыйПроект.Id, новаяПлощадь.Id);

                    for (int k = 0; k < 3; k++)
                    {
                        context.Database.ExecuteSqlRaw(
                            "INSERT INTO координаты_площади (id_площади, x, y) VALUES ({0}, {1}, {2})",
                            новаяПлощадь.Id, random.Next(0, 100), random.Next(0, 100));
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        var новыйПрофиль = new Профиль
                        {
                            Id = context.Профильs.Max(p => p.Id) + 1,
                            Длина = random.Next(10, 1000),
                            Высота = random.Next(10, 100),
                            Описание = $"Профиль {i + 1}"
                        };
                        context.Профильs.Add(новыйПрофиль);
                        context.SaveChanges();

                        context.Database.ExecuteSqlRaw(
                            "INSERT INTO список_профилей (id_площади, id_профиля) VALUES ({0}, {1})",
                            новаяПлощадь.Id, новыйПрофиль.Id);

                        for (int k = 0; k < 3; k++)
                        {
                            context.Database.ExecuteSqlRaw(
                                "INSERT INTO координаты_профиля (id_площади, x, y) VALUES ({0}, {1}, {2})",
                                новыйПрофиль.Id, random.Next(0, 100), random.Next(0, 100));
                        }

                        for (int j = 0; j < 3; j++)
                        {
                            var новоеИзмерение = new Измерения
                            {
                                Id = context.Измеренияs.Max(p => p.Id) + 1,
                                Давление = random.Next(10, 1000) + j,
                                Описание = $"Измерение {j + 1}"
                            };
                            context.Измеренияs.Add(новоеИзмерение);
                            context.SaveChanges();

                            var новыйПункт = new ПунктыНаблюд
                            {
                                Id = context.ПунктыНаблюдs.Max(p => p.Id) + 1,
                                X = j * random.Next(1, 100),
                                Y = j * random.Next(1, 100)
                            };
                            context.ПунктыНаблюдs.Add(новыйПункт);
                            context.SaveChanges();

                            context.Database.ExecuteSqlRaw(
                                "INSERT INTO список_измерений (id_пункта, id_измерения) VALUES ({0}, {1})",
                                новыйПункт.Id, новоеИзмерение.Id);

                            context.Database.ExecuteSqlRaw(
                                "INSERT INTO список_пунктов (id_профиля, id_пункта) VALUES ({0}, {1})",
                                новыйПрофиль.Id, новыйПункт.Id);
                        }
                    }
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании проекта: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }


}

