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
    /// Interaction logic for wEditProduct.xaml
    /// </summary>
    public partial class wEditProduct : Window
    {
        dcBTRDataContext db;
        Classes.ProductController myPC;
        Classes.ProducttypeController myPTC;
        product myProduct;
        public wEditProduct(dcBTRDataContext db, product myProduct)
        {
            this.db = db;
            this.myPC = new Classes.ProductController(db);
            this.myPTC = new Classes.ProducttypeController(db);
            this.myProduct = myProduct;
            InitializeComponent();
            SetData();
        }

        void SetData()
        {
            cmbProducttype.ItemsSource = myPTC.getAllProducttypes();
            txtName.Text = myProduct.productName;
            txtPrice.Text = myProduct.price.ToString();
            cmbProducttype.SelectedItem = myProduct.producttype;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(myPC.editProduct(myProduct, txtName.Text, Convert.ToDecimal(txtPrice.Text), (producttype)cmbProducttype.SelectedItem))
            {
                MessageBox.Show("Product succesvol aangepast!");
                this.Close();
            } else
            {
                MessageBox.Show("Er is helaas iets misgegaan met het wijzigen van het product");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(myPC.deleteProduct(myProduct))
            {
                MessageBox.Show("Product succesvol verwijderd!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Er is helaas iets misgegaan met het verwijderen van het product");
            }
        }
    }
}
