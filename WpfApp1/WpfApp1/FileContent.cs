using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

    public class FileContent : INotifyPropertyChanged
    {
        private string _content;
        public string Path { get; set; }
        public string Content
        {
            get { return _content; }
            set
            {
                if (_content != value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
