using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2122BTR.Classes
{
    class ProducttypeController
    {
        dcBTRDataContext db;
        public ProducttypeController(dcBTRDataContext db)
        {
            this.db = db;
        }

        public List<producttype> getAllProducttypes()
        {
            return db.producttypes.ToList();
        }

        public bool addProductType(string sDescription)
        {
            try
            {
                producttype myPT = new producttype();
                myPT.producttypeomschrijving = sDescription;
                db.producttypes.InsertOnSubmit(myPT);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editProductType(producttype myPT, string sDescription)
        {
            try
            {
                myPT.producttypeomschrijving = sDescription;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteProductType(producttype myPT)
        {
            try
            {
                db.producttypes.DeleteOnSubmit(myPT);
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
