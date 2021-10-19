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
    /// Interaction logic for ucOrders.xaml
    /// </summary>
    public partial class ucOrders : UserControl
    {
        dcBTRDataContext db;
        Classes.CustomerController myCC;
        Classes.ProducttypeController myPTC;
        Classes.OrderController myOC;
        Classes.ItemPerOrderController myIPOC;
        public ucOrders(dcBTRDataContext db)
        {
            this.db = db;
            this.myCC = new Classes.CustomerController(db);
            this.myPTC = new Classes.ProducttypeController(db);
            this.myOC = new Classes.OrderController(db);
            this.myIPOC = new Classes.ItemPerOrderController(db);
            InitializeComponent();
            SetData();
        }
        
        void SetData()
        {
            cmbCustomer.ItemsSource = myCC.getAllCustomers();
            cmbProducttype.ItemsSource = myPTC.getAllProducttypes();
        }

        private void cmbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbCustomer.SelectedItem != null)
            {
                customer selCustomer = (customer)cmbCustomer.SelectedItem;
                lblLastname.Content = selCustomer.lastname;
                lblFirstname.Content = selCustomer.firstname;
                lblCity.Content = selCustomer.city;
                lblPhonenumber.Content = selCustomer.phonenumber;
                lblEmail.Content = selCustomer.email;
            }
        }

        private void cmbProducttype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbProducttype.SelectedItem != null)
            {
                producttype selPT = (producttype)cmbProducttype.SelectedItem;
                cmbProduct.ItemsSource = selPT.products.ToList();
            }
        }

        private void btnAddToOrder_Click(object sender, RoutedEventArgs e)
        {
            if (cmbProduct.SelectedItem != null) {
                itemperorder myIPO = new itemperorder();
                myIPO.amount = Convert.ToInt32(txtAmount.Text);
                myIPO.product = (product)cmbProduct.SelectedItem;
                dgIPO.Items.Add(myIPO);
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            if(cmbCustomer.SelectedItem != null)
            {
                customer selCustomer = (customer)cmbCustomer.SelectedItem;
                order myOrder = myOC.createOrder(selCustomer);
                List<itemperorder> myIPOs = new List<itemperorder>();
                foreach(itemperorder myIPO in dgIPO.Items)
                {
                    myIPOs.Add(myIPO);
                }
                if(myIPOC.createItemPerOrders(myIPOs, myOrder))
                {
                    MessageBox.Show("Bestelling succesvol opgeslagen!");
                }
                else
                {
                    MessageBox.Show("Er is helaas iets misgegaan met het toevoegen van de bestelling!");
                }
            }
        }

        private void btnDeleteIPO_Click(object sender, RoutedEventArgs e)
        {
            if(dgIPO.SelectedItem != null)
            {
                dgIPO.Items.Remove(dgIPO.SelectedItem);
            }
        }
    }
}
