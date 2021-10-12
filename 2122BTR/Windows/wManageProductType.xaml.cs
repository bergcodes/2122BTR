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
    /// Interaction logic for wManageProductType.xaml
    /// </summary>
    public partial class wManageProductType : Window
    {
        dcBTRDataContext db;
        Classes.ProducttypeController myPTC;
        public wManageProductType(dcBTRDataContext db)
        {
            this.db = db;
            this.myPTC = new Classes.ProducttypeController(db);
            InitializeComponent();
            SetData();
        }

        void SetData()
        {
            cmbPT.ItemsSource = myPTC.getAllProducttypes();
        }

        private void btnAddPT_Click(object sender, RoutedEventArgs e)
        {
            if (myPTC.addProductType(txtDescription.Text))
            {
                MessageBox.Show("Producttype succesvol toegevoegd!");
            }
            else
            {
                MessageBox.Show("Er is helaas iets misgegaan met het toevoegen van het product");
            }
        }

        private void cmbPT_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbPT.SelectedItem != null)
            {
                producttype selPT = (producttype)cmbPT.SelectedItem;
                txtDescriptionEdit.Text = selPT.producttypeomschrijving;
            }
        }

        private void btnEditPT_Click(object sender, RoutedEventArgs e)
        {
            if(cmbPT.SelectedItem != null)
            {
                producttype selPT = (producttype)cmbPT.SelectedItem;
                if (myPTC.editProductType(selPT, txtDescriptionEdit.Text))
                {
                    MessageBox.Show("Producttype succesvol aangepast!");
                }
                else
                {
                    MessageBox.Show("Er is helaas iets misgegaan met het verwijderen van het producttype");
                }
            }
        }

        private void btnDeletePT_Click(object sender, RoutedEventArgs e)
        {
            if(cmbPT.SelectedItem != null)
            {
                producttype selPT = (producttype)cmbPT.SelectedItem;
                if (myPTC.deleteProductType(selPT))
                {
                    MessageBox.Show("Producttype succesvol verwijderd!");
                }
                else
                {
                    MessageBox.Show("Er is helaas iets misgegaan met het verwijderen van het producttype");
                }
            }
        }
    }
}
