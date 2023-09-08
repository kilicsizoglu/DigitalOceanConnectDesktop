using DigitalOcean.API;
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

namespace DigitalOceanConnectDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void loginTry()
        {
            DigitalOceanClient digitalOceanClient = new DigitalOceanClient(KeyText.Text.ToString());
            var account = await digitalOceanClient.Account.Get();
            if (account.Status.Equals("active"))
            {
                DropletWindow dropletWindow = new DropletWindow(KeyText.Text.ToString());
                dropletWindow.Show();
                this.Close();
            } 
            else
            {
                MessageBox.Show("Invalid API Key");
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            loginTry();
        }
    }
}
