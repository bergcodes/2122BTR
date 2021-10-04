using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2122BTR.Classes
{
    class CustomerController
    {
        dcBTRDataContext db;
        public CustomerController(dcBTRDataContext db)
        {
            this.db = db;
        }

        public List<customer> getAllCustomers()
        {
            return db.customers.ToList();
        }

        public bool createCustomer(string sFirstname, string sLastname, string sCity, string sPhonenumber, string sEmail)
        {
            try
            {
                customer myCustomer = new customer();
                myCustomer.firstname = sFirstname;
                myCustomer.lastname = sLastname;
                myCustomer.city = sCity;
                myCustomer.phonenumber = sPhonenumber;
                myCustomer.email = sEmail;
                db.customers.InsertOnSubmit(myCustomer);
                db.SubmitChanges();
                return true;
            }
            catch { 
                return false;
            }
        }

        public bool editCustomer(int iCustomerId, string sFirstname, string sLastname, string sCity, string sPhonenumber, string sEmail)
        {
            try
            {
                customer myCustomer = (from c in db.customers
                                       where c.customerID == iCustomerId
                                       select c).FirstOrDefault();
                myCustomer.firstname = sFirstname;
                myCustomer.lastname = sLastname;
                myCustomer.city = sCity;
                myCustomer.phonenumber = sPhonenumber;
                myCustomer.email = sEmail;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteCustomer(int iCustomerId)
        {
            try
            {
                customer myCustomer = (from c in db.customers
                                       where c.customerID == iCustomerId
                                       select c).FirstOrDefault();
                db.customers.DeleteOnSubmit(myCustomer);
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
