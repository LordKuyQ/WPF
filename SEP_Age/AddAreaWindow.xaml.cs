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
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите название площади");
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
                    Площадь1 = NameTextBox.Text надо в инт
                };
                context.Площадьs.Add(area);

                var projectArea = new СписокПлощадей
                {
                    ProjectId = (ProjectComboBox.SelectedItem as Project).Id,
                    AreaId = area.Id
                };
                context.СписокИзмеренийs.Add(projectArea);

                context.SaveChanges();
                this.Close();
            }
        }
    }
}