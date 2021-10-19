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
    /// Interaction logic for ucCustomers.xaml
    /// </summary>
    public partial class ucCustomers : UserControl
    {
        dcBTRDataContext db;
        Classes.CustomerController myCC;
        public ucCustomers(dcBTRDataContext db)
        {
            this.db = db;
            this.myCC = new Classes.CustomerController(db);

            InitializeComponent();
            SetData();
        }

        void SetData()
        {
            List<customer> myCustomers = myCC.getAllCustomers();
            dgCustomers.ItemsSource = myCustomers;
            lblCustCount.Content = myCustomers.Count();
        }

        void EmptyInputs()
        {
            txtFirstname.Text = string.Empty;
            txtLastname.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPhonenumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        void SetNewCustomer()
        {
            lblSelCustId.Content = "Nieuwe klant";
            lblSelCustName.Content = string.Empty;
            btnDeleteCust.Visibility = Visibility.Hidden;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (lblSelCustId.Content.ToString() == "Nieuwe klant")
            {
                if (myCC.createCustomer(txtFirstname.Text, txtLastname.Text, txtCity.Text, txtPhonenumber.Text, txtEmail.Text))
                {
                    SetData();
                    MessageBox.Show("Klant is succesvol opgeslagen!");
                    EmptyInputs();
                }
                else
                {
                    MessageBox.Show("Er is helaas iets misgegaan met het opslaan van de klant!");
                }
            }
            else
            {
                if (myCC.editCustomer(Convert.ToInt32(lblSelCustId.Content), txtFirstname.Text, txtLastname.Text, txtCity.Text, txtPhonenumber.Text, txtEmail.Text))
                {
                    SetData();
                    MessageBox.Show("Klant is succesvol aangepast!");
                    EmptyInputs();
                    SetNewCustomer();
                }
                else
                {
                    MessageBox.Show("Er is helaas iets misgegaan met het wijzigen van de klant!");
                }
            }
        }

        private void dgCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgCustomers.SelectedItem != null)
            {
                customer selCustomer = (customer)dgCustomers.SelectedItem;
                txtFirstname.Text = selCustomer.firstname;
                txtLastname.Text = selCustomer.lastname;
                txtCity.Text = selCustomer.city;
                txtPhonenumber.Text = selCustomer.phonenumber;
                txtEmail.Text = selCustomer.email;
                lblSelCustId.Content = selCustomer.customerID;
                lblSelCustName.Content = selCustomer.lastname + ", " + selCustomer.firstname;
                btnDeleteCust.Visibility = Visibility.Visible;
            }
        }

        private void btnNewCust_Click(object sender, RoutedEventArgs e)
        {
            SetNewCustomer();
            EmptyInputs();
        }

        private void btnDeleteCust_Click(object sender, RoutedEventArgs e)
        {
            if(lblSelCustId.Content.ToString() != "Nieuwe klant")
            {
                if (myCC.deleteCustomer(Convert.ToInt32(lblSelCustId.Content)))
                {
                    SetData();
                    MessageBox.Show("Klant is succesvol verwijderd");
                    EmptyInputs();
                    SetNewCustomer();
                }
                else
                {
                    MessageBox.Show("Er is helaas iets misgegaan met het verwijderen van de klant!");
                }
            }
        }

        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
