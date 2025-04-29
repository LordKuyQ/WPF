using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;
using SEP_Age.Models;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using SEP_Age.Auto;
using Microsoft.EntityFrameworkCore;
using LiveCharts.Configurations;
using System.Windows.Controls;
using System.Windows.Data;

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

            ПроектыBtn.Click += (s, e) => new AddProjectWindow().ShowDialog();
            ПлощадиBtn.Click += (s, e) => new AddAreaWindow().ShowDialog();
            ПрофилиBtn.Click += (s, e) => new AddProfileWindow().ShowDialog();
            ПунктыНаблюденияBtn.Click += (s, e) => new AddObservationPointWindow().ShowDialog();
            ИзмеренияBtn.Click += (s, e) => new AddMeasurementWindow().ShowDialog();

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
            MeasurementsChart.Visibility = Visibility.Hidden;
            CoordinatesChart.Visibility = Visibility.Visible;

            SeriesCollection.Clear();

            if (координаты == null || координаты.Count == 0)
            {
                return;
            }

            var points = new ChartValues<ObservablePoint>();
            foreach (var coord in координаты)
            {
                points.Add(new ObservablePoint(coord.X, coord.Y));
            }
            if (координаты.Count > 0)
            {
                points.Add(new ObservablePoint(координаты[0].X, координаты[0].Y));
            }

            var polygonSeries = new LineSeries
            {
                Title = "Площадь",
                Values = points,
                Stroke = System.Windows.Media.Brushes.Black,
                Fill = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(100, 0, 128, 255)), 
                LineSmoothness = 0,
                StrokeThickness = 2
            };

            var pointsSeries = new ScatterSeries
            {
                Title = "Точки площади",
                Values = new ChartValues<ObservablePoint>(координаты.Select(c => new ObservablePoint(c.X, c.Y))),
                Stroke = System.Windows.Media.Brushes.Red, 
                Fill = System.Windows.Media.Brushes.Red, 
                StrokeThickness = 8 
            };

            SeriesCollection.Add(polygonSeries);
            SeriesCollection.Add(pointsSeries);

            if (координаты.Any())
            {
                CoordinatesChart.AxisX[0].MinValue = координаты.Min(c => c.X) - 10;
                CoordinatesChart.AxisX[0].MaxValue = координаты.Max(c => c.X) + 10;
                CoordinatesChart.AxisY[0].MinValue = координаты.Min(c => c.Y) - 10;
                CoordinatesChart.AxisY[0].MaxValue = координаты.Max(c => c.Y) + 10;
            }

            CoordinatesChart.Series = SeriesCollection;
        }

        private void DrawПрофили(List<КоординатыПрофиля> координаты)
        {
            MeasurementsChart.Visibility = Visibility.Hidden;
            CoordinatesChart.Visibility = Visibility.Visible;

            SeriesCollection.Clear();

            if (координаты == null || координаты.Count == 0)
            {
                return;
            }

            var points = new ChartValues<ObservablePoint>();
            foreach (var coord in координаты)
            {
                points.Add(new ObservablePoint(coord.X, coord.Y));
            }

            var lineSeries = new LineSeries
            {
                Title = "Профиль",
                Values = points,
                Stroke = System.Windows.Media.Brushes.Blue,
                Fill = System.Windows.Media.Brushes.Transparent,
                LineSmoothness = 0, 
                StrokeThickness = 2
            };

            var pointsSeries = new ScatterSeries
            {
                Title = "Точки профиля",
                Values = new ChartValues<ObservablePoint>(координаты.Select(c => new ObservablePoint(c.X, c.Y))),
                Stroke = System.Windows.Media.Brushes.Red,
                Fill = System.Windows.Media.Brushes.Red,
                StrokeThickness = 8 
            };

            SeriesCollection.Add(lineSeries);
            SeriesCollection.Add(pointsSeries);

            if (координаты.Any())
            {
                CoordinatesChart.AxisX[0].MinValue = координаты.Min(c => c.X) - 10;
                CoordinatesChart.AxisX[0].MaxValue = координаты.Max(c => c.X) + 10;
                CoordinatesChart.AxisY[0].MinValue = координаты.Min(c => c.Y) - 10;
                CoordinatesChart.AxisY[0].MaxValue = координаты.Max(c => c.Y) + 10;
            }

            CoordinatesChart.Series = SeriesCollection;
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
            CoordinatesChart.Visibility = Visibility.Hidden;
            MeasurementsChart.Visibility = Visibility.Hidden;

            SeriesCollection.Clear();

            var selectedMeasurement = измеренияGrid.SelectedItem as Измерения;
            if (selectedMeasurement == null)
            {
                MessageBox.Show("Выберите измерение для отображения графика.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var allMeasurements = GetAllMeasurements();
            if (allMeasurements == null || !allMeasurements.Any())
            {
                MessageBox.Show("Нет данных для построения графика.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var context = new AppDbContext())
            {
                var profileIds = (from m in allMeasurements
                                  join si in context.СписокИзмеренийs on m.Id equals si.IdИзмерения
                                  join sp in context.СписокПунктовs on si.IdПункта equals sp.IdПункта
                                  select sp.IdПрофиля).Distinct().ToList();

                if (profileIds.Count > 1)
                {
                    MessageBox.Show("Измерения принадлежат разным профилям. Выберите измерения одного профиля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            try
            {
                var chartValues = new ChartValues<ObservablePoint>();
                foreach (var measurement in allMeasurements)
                {
                    chartValues.Add(new ObservablePoint(measurement.Расстояние, measurement.Давление));
                }

                var columnSeries = new ColumnSeries
                {
                    Title = "Давление",
                    Values = chartValues,
                    Fill = System.Windows.Media.Brushes.Blue,
                    Stroke = System.Windows.Media.Brushes.Black,
                    StrokeThickness = 1,
                    DataLabels = true,
                    LabelPoint = point => $"{point.Y} ОМ",
                    MaxColumnWidth = 20
                };

                SeriesCollection.Add(columnSeries);

                MeasurementsChart.AxisX.Clear();
                MeasurementsChart.AxisX.Add(new Axis
                {
                    Title = "Расстояние по профилю (м)",
                    Labels = allMeasurements.Select(m => $"{m.Расстояние} м").ToArray(),
                    MinValue = allMeasurements.Min(m => m.Расстояние) - 10,
                    MaxValue = allMeasurements.Max(m => m.Расстояние) + 10
                });

                MeasurementsChart.AxisY.Clear();
                MeasurementsChart.AxisY.Add(new Axis
                {
                    Title = "Давление (ОМ)",
                    MinValue = allMeasurements.Min(m => m.Давление) - 10,
                    MaxValue = allMeasurements.Max(m => m.Давление) + 10,
                    LabelFormatter = value => $"{value} ОМ"
                });

                MeasurementsChart.Series = SeriesCollection;
                MeasurementsChart.Visibility = Visibility.Visible; 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при построении графика: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private List<Измерения> GetAllMeasurements()
        {
            var selectedПункт = пунктыНаблюденияGrid.SelectedItem as ПунктыНаблюд;
            if (selectedПункт != null)
            {
                using (var context = new AppDbContext())
                {
                    return context.СписокИзмеренийs
                        .Where(si => si.IdПункта == selectedПункт.Id)
                        .Select(si => si.IdИзмеренияNavigation)
                        .ToList();
                }
            }
            return измеренияGrid.ItemsSource?.Cast<Измерения>().ToList() ?? new List<Измерения>();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сбросе данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            CoordinatesChart.Visibility = Visibility.Hidden;
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
                        Название = "Синтетический проект",
                        ДатаНачала = DateOnly.FromDateTime(DateTime.Today),
                        ДатаКонца = DateOnly.FromDateTime(DateTime.Today.AddDays(30)),
                        Цена = random.Next(10000, 10000000)
                    };

                    var новаяПлощадь = new Площадь
                    {
                        Площадь1 = random.Next(10, 1000)
                    };

                    var координатаПлощади = new КоординатыПлощади
                    {
                        X = random.Next(0, 100),
                        Y = random.Next(0, 100),
                        IdПлощадиNavigation = новаяПлощадь
                    };
                    новаяПлощадь.КоординатыПлощадиs = new List<КоординатыПлощади> { координатаПлощади };

                    context.Проектs.Add(новыйПроект);
                    context.Площадьs.Add(новаяПлощадь);

                    context.СписокПлощадейs.Add(new СписокПлощадей
                    {
                        IdПроектаNavigation = новыйПроект,
                        IdПлощадиNavigation = новаяПлощадь
                    });

                    var профиль = new Профиль
                    {
                        Длина = random.Next(10, 1000),
                        Высота = random.Next(10, 100),
                        Описание = "Профиль 1"
                    };
                    context.Профильs.Add(профиль);

                    context.СписокПрофилейs.Add(new СписокПрофилей
                    {
                        IdПлощадиNavigation = новаяПлощадь,
                        IdПрофиляNavigation = профиль
                    });

                    var координатаПрофиля = new КоординатыПрофиля
                    {
                        X = random.Next(0, 100),
                        Y = random.Next(0, 100),
                        IdПлощадиNavigation = новаяПлощадь
                    };
                    context.КоординатыПрофиляs.Add(координатаПрофиля);

                    var измерение = new Измерения
                    {
                        Давление = random.Next(10, 1000),
                        Описание = "Измерение 1",
                        АбсолютнаяВысота = random.Next(100, 1000), 
                        Расстояние = random.Next(1, 100) 
                    };
                    context.Измеренияs.Add(измерение);

                    var пункт = new ПунктыНаблюд
                    {
                        X = random.Next(1, 100),
                        Y = random.Next(1, 100)
                    };
                    context.ПунктыНаблюдs.Add(пункт);

                    context.СписокИзмеренийs.Add(new СписокИзмерений
                    {
                        IdИзмеренияNavigation = измерение,
                        IdПунктаNavigation = пункт
                    });

                    context.СписокПунктовs.Add(new СписокПунктов
                    {
                        IdПрофиляNavigation = профиль,
                        IdПунктаNavigation = пункт
                    });

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании проекта: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }







    }


}

