using System.Windows;
using SEP_Age.Models;
using System.Linq;

namespace SEP_Age
{
    public partial class AddAreaWindow : Window
    {
        public AddAreaWindow()
        {
            InitializeComponent();
            using (var context = new AppDbContext())
            {
                ProjectComboBox.ItemsSource = context.Проектs.ToList();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SqrTextBox.Text))
            {
                MessageBox.Show("Введите значение площади");
                return;
            }
            if (ProjectComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите проект");
                return;
            }

            using (var context = new AppDbContext())
            {
                var area = new Площадь
                {
                    Площадь1 = int.Parse(SqrTextBox.Text),
                };
                context.Площадьs.Add(area);
                context.SaveChanges();

                var projectArea = new СписокПлощадей
                {
                    IdПроекта = (ProjectComboBox.SelectedItem as Проект).Id,
                    IdПлощади = area.Id
                };
                context.СписокПлощадейs.Add(projectArea);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}