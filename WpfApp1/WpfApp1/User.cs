using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class User :INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        private int _points;
        
        public int Points
        {
            get { return _points; }
            set
            {
                if (_points != value)
                {
                    _points = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Points"));
                }
            }
        }
        


        public User(int id,string login,string password, int points)
        {
            Id = id;
            Login = login;
            Password = password;
            Points = points;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
