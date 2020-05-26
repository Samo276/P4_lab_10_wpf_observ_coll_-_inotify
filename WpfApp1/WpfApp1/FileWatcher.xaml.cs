using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private FileContent _fileContent = new FileContent();
        private FileSystemWatcher _watcher = new FileSystemWatcher();
        
        public Window1()
        {
            InitializeComponent();
            fileContentTextBox.DataContext = _fileContent;
            _watcher.NotifyFilter = NotifyFilters.LastWrite;
            _watcher.Changed += _watcher_Changed; //<<<<<tu pojawia się blad którego nie umiem rozwiazac
        }
        private void _watcher_Changed(object sender, FileSystemEventArgs e)
        {
            LoadFile();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "wybierz plik do obserwowawania",
                Filter = "Textfile|*.txt"
            };
            var result = openFileDialog.ShowDialog(this);
            if (!result.HasValue || !result.Value) // =>!(result.HasValue && result.Value) // to jest zamienne
            {
                return;
            }
            //var path = openFileDialog.FileName;
            //var text = File.ReadAllText(path);
            //FileContentTextBox.SetBinding(TextBox.TextProperty, new Binding("Content"));

            _fileContent.Path = openFileDialog.FileName;
            _watcher.Path = openFileDialog.FileName.Replace(openFileDialog.SafeFileName, string.Empty);
            _watcher.EnableRaisingEvents = true;
            LoadFile();
        }
        private void LoadFile()
        {
            var text = File.ReadAllText(_fileContent.Path);
            _fileContent.Content = text;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadFile();
        }
    }
}
