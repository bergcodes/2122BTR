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

namespace _2122BTR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dcBTRDataContext db = new dcBTRDataContext();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new UserControls.ucCustomers(db);
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new UserControls.ucProducts(db);
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new UserControls.ucOrders(db);
        }
    }
}
