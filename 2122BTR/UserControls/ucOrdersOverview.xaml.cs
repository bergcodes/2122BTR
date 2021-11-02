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

namespace _2122BTR.UserControls
{
    /// <summary>
    /// Interaction logic for ucOrdersOverview.xaml
    /// </summary>
    public partial class ucOrdersOverview : UserControl
    {
        dcBTRDataContext db;
        Classes.OrderController myOC;
        public ucOrdersOverview(dcBTRDataContext db)
        {
            this.db = db;
            this.myOC = new Classes.OrderController(db);
            InitializeComponent();
            SetData();
        }

        void SetData()
        {
            dgOrders.ItemsSource = myOC.getAllOrders();
            dgIPO.ItemsSource = null;
        }

        private void dgOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgOrders.SelectedItem != null)
            {
                order selOrder = (order)dgOrders.SelectedItem;
                dgIPO.ItemsSource = selOrder.itemperorders;
            }
        }

        private void btnEditOrder_Click(object sender, RoutedEventArgs e)
        {
            if(dgOrders.SelectedItem != null)
            {
                order selOrder = (order)dgOrders.SelectedItem;
                Windows.wEditOrder myWEditOrder = new Windows.wEditOrder(db, selOrder);
                myWEditOrder.Closing += MyWEditOrder_Closing;
                myWEditOrder.Show();
            }
        }

        private void MyWEditOrder_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db = new dcBTRDataContext();
            myOC = new Classes.OrderController(db);
            SetData();
        }
    }
}
