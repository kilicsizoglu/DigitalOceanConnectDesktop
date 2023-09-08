using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for DropletCreate.xaml
    /// </summary>
    public partial class DropletCreate : Window
    {
        DropletManager? dropletManager;

        public DropletCreate(string key)
        {
            InitializeComponent();
            dropletManager = new DropletManager(key);
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            if (dropletManager != null)
            {
                dropletManager.CreateDroplet(name.Text, region.Text, size.Text, image.Text);
            }
            this.Close();
        }
    }
}
