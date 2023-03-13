using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;

namespace WpfApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        Demo1303_2Entities context = new Demo1303_2Entities();
        public Page1()
        {
            InitializeComponent();
        }

        ~Page1()
        {
            this.context.Dispose();
        }


        public void RefreshData()
        {
            this.userDataGrid.Items.Refresh();
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            context.SaveChanges();
            RefreshData();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource userViewSource =
                ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
            context.User.Load();
            userViewSource.Source = context.User.Local;
        }

        private void userDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window2 window2 = Window2.GetWindow(this) as Window2;
            window2.frame.Navigate(new Page2 { 
                User = userDataGrid.SelectedItem as User,
                Context = context,
                Page1 = this
            });
        }
    }
}
