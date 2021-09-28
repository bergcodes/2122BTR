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
            dgCustomers.ItemsSource = myCC.getAllCustomers();
        }
    }
}
