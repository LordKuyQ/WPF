using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;
using SEP_Age.Models;

namespace SEP_Age
{
    public partial class MainWindow : Window
    {
        private AppDbContext _context;

        public MainWindow()
        {
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
                }
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
        }
    }
}
