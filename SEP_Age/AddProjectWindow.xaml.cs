using System.Windows;
using SEP_Age.Models;
using System.Linq;

namespace SEP_Age
{
    public partial class : Window
    {
        public AddProjectWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Введите название проекта");
                return;
            }

            using (var context = new AppDbContext())
            {
                var project = new Проект
                {
                    Name = NameTextBox.Text,
                    Description = DescriptionTextBox.Text
                };
                context.Проектs.Add(project);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}