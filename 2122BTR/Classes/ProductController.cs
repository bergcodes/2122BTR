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

        public List<product> getAllProducts()
        {
            return db.products.ToList();
        }

        public bool createProduct(string sName, decimal dPrice, producttype myPT)
        {
            try
            {
                product myProduct = new product();
                myProduct.productName = sName;
                myProduct.price = dPrice;
                myProduct.producttypeid = myPT.producttypeID;
                db.products.InsertOnSubmit(myProduct);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editProduct(product myProduct, string sName, decimal dPrice, producttype myPT)
        {
            try
            {
                myProduct.productName = sName;
                myProduct.price = dPrice;
                myProduct.producttypeid = myPT.producttypeID;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteProduct(product myProduct)
        {
            try
            {
                db.products.DeleteOnSubmit(myProduct);
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
