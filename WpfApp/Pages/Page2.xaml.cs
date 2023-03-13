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

namespace WpfApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public User User;
        public Demo1303_2Entities Context;

        public Page2()
        {
            InitializeComponent();
        }

        private void saveAndClose_Click(object sender, RoutedEventArgs e)
        {
            User.Username = username.Text;
            User.Password = password.Password;
            Window2 window2 = Window.GetWindow(this) as Window2;
            window2.frame.NavigationService.GoBack();
            Context.SaveChanges();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            username.Text = User.Username;
            password.Password = User.Password;
        }
    }
}
