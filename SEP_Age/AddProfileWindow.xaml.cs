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
    public partial class AddProfileWindow : Window
    {
        public AddProfileWindow()
        {
            InitializeComponent();
            using (var context = new AppDbContext())
            {
                AreaComboBox.ItemsSource = context.Площадьs.ToList();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LengthTextBox.Text) || string.IsNullOrWhiteSpace(HeightTextBox.Text) || string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (AreaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите площадь");
                return;
            }

            using (var context = new AppDbContext())
            {
                var profile = new Профиль
                {
                    Длина = int.Parse(LengthTextBox.Text),
                    Высота = int.Parse(HeightTextBox.Text),
                    Описание = DescriptionTextBox.Text
                };
                context.Профильs.Add(profile);
                context.SaveChanges();

                var areaProfile = new СписокПрофилей
                {
                    IdПлощади = (AreaComboBox.SelectedItem as Площадь).Id,
                    IdПрофиля = profile.Id
                };
                context.СписокПрофилейs.Add(areaProfile);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}
