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
using System.Net;
using System.Web;
using unirest_net.http;
using System.IO;
using Newtonsoft.Json;

namespace ApplicationWithApi
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
            string numberText = textBox.Text;
            var data = Task.Run(() =>
            {
                int number = int.Parse(numberText);
                System.Net.WebClient client = new System.Net.WebClient();
                Stream stream = client.OpenRead("http://numbersapi.com/" + number);
                StreamReader sr = new StreamReader(stream);
                string txt = sr.ReadLine();
                return txt;
            }).Result;

            factTextBlock.Text = data;
        }
    }
}
