using System.Windows;
using SEP_Age.Models;
using System.Linq;

namespace SEP_Age
{
    public partial class AddProjectWindow : Window
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
            if (StartDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату начала");
                return;
            }
            if (EndDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату конца");
                return;
            }
            if (string.IsNullOrWhiteSpace(PriceTextBox.Text) || !int.TryParse(PriceTextBox.Text, out int price))
            {
                MessageBox.Show("Введите корректную цену");
                return;
            }

            using (var context = new AppDbContext())
            {
                var project = new Проект
                {
                    Название = NameTextBox.Text,
                    ДатаНачала = DateOnly.FromDateTime(StartDatePicker.SelectedDate.Value),
                    ДатаКонца = DateOnly.FromDateTime(EndDatePicker.SelectedDate.Value),
                    Цена = price
                };
                context.Проектs.Add(project);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}