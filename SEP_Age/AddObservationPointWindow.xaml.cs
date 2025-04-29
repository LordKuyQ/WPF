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
    public partial class AddObservationPointWindow : Window
    {
        public AddObservationPointWindow()
        {
            InitializeComponent();
            using (var context = new AppDbContext())
            {
                ProfileComboBox.ItemsSource = context.Профильs.ToList();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(XTextBox.Text) || string.IsNullOrWhiteSpace(YTextBox.Text))
            {
                MessageBox.Show("Заполните координаты");
                return;
            }
            if (ProfileComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите профиль");
                return;
            }

            using (var context = new AppDbContext())
            {
                var point = new ПунктыНаблюд
                {
                    X = int.Parse(XTextBox.Text),
                    Y = int.Parse(YTextBox.Text)
                };
                context.ПунктыНаблюдs.Add(point);
                context.SaveChanges();

                var profilePoint = new СписокПунктов
                {
                    IdПрофиля = (ProfileComboBox.SelectedItem as Профиль).Id,
                    IdПункта = point.Id
                };
                context.СписокПунктовs.Add(profilePoint);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}
