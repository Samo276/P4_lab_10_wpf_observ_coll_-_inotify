using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> _users = new ObservableCollection<User>();
        //
        //
        public MainWindow()
        {
            InitializeComponent();
            UserList.ItemsSource = _users;
            new Window1().Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var counter = 1;
            if(_users.Any())
                counter = _users.Max(x => x?.Id + 1 ?? 1);
            
   

            _users.Add(new User(
                counter,
                $"login{counter}",
                $"password{counter}",
                0
                ));
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_users.Any())
            {
                var user = _users[0];
                user.Points += 100;
            }
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_users.Any())
            {
                _users.RemoveAt(0);
            }
        }
    }
}
