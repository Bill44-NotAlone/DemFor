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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new Demo1303_2Entities())
            {
                var users = db.User.ToList().Where(u => u.Username == username.Text && u.Password == password.Password);
                if(users.Count() == 0)
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
                else
                {
                    Hide();
                    Window2 window2 = new Window2();
                    window2.ShowDialog();
                    Show();
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new Demo1303_2Entities())
            {
                User user = new User { Password = password.Password, Username = username.Text };
                db.User.Add(user);
                db.SaveChanges();
            }
        }
    }
}
