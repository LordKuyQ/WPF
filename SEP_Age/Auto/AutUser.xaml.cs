using System.Net;
using System.Windows;
using SEP_Age.Models;

namespace SEP_Age.Auto
{
    public partial class AutUser : Window
    {
        private AppDbContext _context;
        public AutUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(BoxName.Text) && !string.IsNullOrEmpty(BoxPass.Text))
            {
                try
                {
                    using (_context = new AppDbContext())
                    {
                        var user = _context.Пользовательs.FirstOrDefault(q => q.Емайл == BoxName.Text && q.Пароль == BoxPass.Text);
                        if (user != null)
                        {
                            DialogResult = true;
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль не верны");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при попытке аутентификации: {ex.Message}");
                }
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            RegUser regUser = new RegUser();

            regUser.ShowDialog();

            if (regUser.DialogResult == true)
            {
                
                    using (_context = new AppDbContext())
                    {
                        _context.Пользовательs.Add(regUser.NewUser);
                        _context.SaveChanges();
                    }
                
                
            }
        }
    }
}
