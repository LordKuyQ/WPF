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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void проектыGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void площадиGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void профилиGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void пунктыНаблюденияGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
