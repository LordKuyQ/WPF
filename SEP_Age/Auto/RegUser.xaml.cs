using System.Windows;
using SEP_Age.Models;

namespace SEP_Age.Auto
{
    public partial class RegUser : Window
    {
        public Пользователь NewUser;
        public RegUser()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(BoxName.Text) && !string.IsNullOrEmpty(BoxPass.Text) && !string.IsNullOrEmpty(BoxEmail.Text))
            {
                int телефон;
                if (int.TryParse(BoxTelefon.Text, out телефон))
                {
                    NewUser = new Пользователь()
                    {
                        Фио = BoxName.Text,
                        Пароль = BoxPass.Text,
                        Емайл = BoxEmail.Text,
                        ТипПользователя = BoxType.Text,
                        Телефон = телефон,
                    };
                    DialogResult = true;
                    return;
                }
                else
                {
                    MessageBox.Show("Некорректный формат данных.");
                }
            }
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            return;
        }
    }
}
