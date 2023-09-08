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
using System.Windows.Shapes;

namespace DigitalOceanConnectDesktop
{
    /// <summary>
    /// Interaction logic for DropletWindow.xaml
    /// </summary>
    public partial class DropletWindow : Window
    {
        private string? key;
        DropletManager? dropletManager;
        public DropletWindow(String? key)
        {
            this.key = key;
            InitializeComponent();
            if (key != null)
            {
                dropletManager = new DropletManager(key);
            }
            refreshList();
        }

        private async void refreshList() 
        {
            if (dropletManager != null)
            {
                IReadOnlyList<DigitalOcean.API.Models.Responses.Droplet> droplets = await dropletManager.GetDroplets();
                foreach (DigitalOcean.API.Models.Responses.Droplet droplet in droplets)
                {
                    DropletList.Items.Add(droplet.Id);
                }
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            DropletCreate dropletCreate = new DropletCreate(key);
            dropletCreate.Show();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dropletManager != null)
            {
                dropletManager.DeleteDroplet(Convert.ToInt16(DropletList.SelectedItem.ToString()));
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            refreshList();
        }
    }
}
