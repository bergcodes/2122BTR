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

namespace _2122BTR.Windows
{
    /// <summary>
    /// Interaction logic for wEditOrder.xaml
    /// </summary>
    public partial class wEditOrder : Window
    {
        dcBTRDataContext db;
        order myOrder;
        Classes.CustomerController myCC;
        Classes.ItemPerOrderController myIPOC;
        Classes.OrderController myOC;
        public wEditOrder(dcBTRDataContext db, order myOrder)
        {
            this.db = db;
            this.myOrder = myOrder;
            this.myCC = new Classes.CustomerController(db);
            this.myIPOC = new Classes.ItemPerOrderController(db);
            this.myOC = new Classes.OrderController(db);
            InitializeComponent();
            SetData();
        }

        void SetData()
        {
            cmbCustomer.ItemsSource = myCC.getAllCustomers();
            cmbCustomer.SelectedItem = myOrder.customer;
            dgIPOs.ItemsSource = myOrder.itemperorders;
        }

        private void cmbCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbCustomer.SelectedItem != null)
            {
                customer selCustomer = (customer)cmbCustomer.SelectedItem;
                lblLastname.Content = selCustomer.lastname;
                lblFirstname.Content = selCustomer.firstname;
                lblCity.Content = selCustomer.city;
                lblPhonenumber.Content = selCustomer.phonenumber;
                lblEmail.Content = selCustomer.email;
            }
        }

        private void btnIPODelete_Click(object sender, RoutedEventArgs e)
        {
            if(dgIPOs.SelectedItem != null)
            {
                itemperorder myIPO = (itemperorder)dgIPOs.SelectedItem;
                if (myIPOC.deleteItemPerOrder(myIPO))
                {
                    SetData();
                    MessageBox.Show("Product succesvol uit bestelling verwijderd!");
                }
                else
                {
                    MessageBox.Show("Er is helaas iets misgegaan met het verwijderen van het product uit de bestelling!");
                }
            }
        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if(cmbCustomer.SelectedItem != null)
            {
                customer selCustomer = (customer)cmbCustomer.SelectedItem;
                if(myOC.editOrderCustomer(myOrder, selCustomer))
                {
                    MessageBox.Show("Klant succesvol aan bestelling gekoppeld!");
                } 
                else
                {
                    MessageBox.Show("Er is iets misgegaan met het koppelen van de bestelling aan de klant!");
                }
            }
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            if (myOC.deleteOrder(myOrder))
            {
                MessageBox.Show("Bestelling succesvol verwijderd!");
            } 
            else
            {
                MessageBox.Show("Er is iets misgegaan met het verwijderen van de bestelling!");
            }
        }
    }
}
