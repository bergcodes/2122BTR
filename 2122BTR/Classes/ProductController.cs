using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2122BTR.Classes
{
    class ProductController
    {
        dcBTRDataContext db;
        public ProductController(dcBTRDataContext db)
        {
            this.db = db;
        }

        public List<producten> getAllProducts()
        {
            return db.productens.ToList();
        }

        public bool createProduct(string sName, decimal dPrice, producttype myPT)
        {
            try
            {
                producten myProduct = new producten();
                myProduct.productName = sName;
                myProduct.prijs = dPrice;
                myProduct.producttypeid = myPT.producttypeID;
                db.productens.InsertOnSubmit(myProduct);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editProduct(producten myProduct, string sName, decimal dPrice, producttype myPT)
        {
            try
            {
                myProduct.productName = sName;
                myProduct.prijs = dPrice;
                myProduct.producttypeid = myPT.producttypeID;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteProduct(producten myProduct)
        {
            try
            {
                db.productens.DeleteOnSubmit(myProduct);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
