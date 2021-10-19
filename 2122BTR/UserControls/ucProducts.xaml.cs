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
    /// Interaction logic for ucProducts.xaml
    /// </summary>
    public partial class ucProducts : UserControl
    {
        dcBTRDataContext db;
        Classes.ProductController myPC;
        Classes.ProducttypeController myPTC;
        public ucProducts(dcBTRDataContext db)
        {
            this.db = db;
            this.myPC = new Classes.ProductController(db);
            this.myPTC = new Classes.ProducttypeController(db);
            InitializeComponent();
            SetData();
        }

        void SetData()
        {
            dgProducts.ItemsSource = myPC.getAllProducts();
            cmbProducttype.ItemsSource = myPTC.getAllProducttypes();
        }

        void EmptyInputs()
        {
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            cmbProducttype.SelectedItem = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(myPC.createProduct(txtName.Text, Convert.ToDecimal(txtPrice.Text), (producttype)cmbProducttype.SelectedItem))
            {
                SetData();
                MessageBox.Show("Product is succesvol opgeslagen!");
                EmptyInputs();
            }
            else
            {
                MessageBox.Show("Er is helaas iets misgegaan met het opslaan!");
            }
        }

        private void dgProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dgProducts.SelectedItem != null)
            {
                product selProduct = (product)dgProducts.SelectedItem;
                Windows.wEditProduct myWindow = new Windows.wEditProduct(db, selProduct);
                myWindow.Closing += MyWindow_Closing;
                myWindow.Show();
            }
        }

        private void MyWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetData();
        }

        private void btnManagePT_Click(object sender, RoutedEventArgs e)
        {
            Windows.wManageProductType myWManageProductType = new Windows.wManageProductType(db);
            myWManageProductType.Closing += MyWManageProductType_Closing;
            myWManageProductType.Show();
        }

        private void MyWManageProductType_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SetData();
        }
    }
}
