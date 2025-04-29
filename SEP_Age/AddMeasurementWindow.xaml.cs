using SEP_Age.Models;
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
using System.Windows.Shapes;

namespace SEP_Age
{
    public partial class AddMeasurementWindow : Window
    {
        public AddMeasurementWindow()
        {
            InitializeComponent();
            using (var context = new AppDbContext())
            {
                ObservationPointComboBox.ItemsSource = context.ПунктыНаблюдs.ToList();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PressureTextBox.Text) || string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ||
                string.IsNullOrWhiteSpace(AbsoluteHeightTextBox.Text) || string.IsNullOrWhiteSpace(DistanceTextBox.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (ObservationPointComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите пункт наблюдения");
                return;
            }

            using (var context = new AppDbContext())
            {
                var measurement = new Измерения
                {
                    Давление = int.Parse(PressureTextBox.Text),
                    Описание = DescriptionTextBox.Text,
                    АбсолютнаяВысота = int.Parse(AbsoluteHeightTextBox.Text),
                    Расстояние = int.Parse(DistanceTextBox.Text)
                };
                context.Измеренияs.Add(measurement);
                context.SaveChanges();

                var pointMeasurement = new СписокИзмерений
                {
                    IdПункта = (ObservationPointComboBox.SelectedItem as ПунктыНаблюд).Id,
                    IdИзмерения = measurement.Id
                };
                context.СписокИзмеренийs.Add(pointMeasurement);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}
