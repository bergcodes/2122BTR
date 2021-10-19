using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2122BTR.Classes
{
    class OrderController
    {
        dcBTRDataContext db;

        public OrderController(dcBTRDataContext db)
        {
            this.db = db;
        }
        public order createOrder(customer selCustomer)
        {
            try
            {
                order myOrder = new order();
                myOrder.date = DateTime.Now;
                myOrder.customerID = selCustomer.customerID;
                db.orders.InsertOnSubmit(myOrder);
                db.SubmitChanges();
                return myOrder;
            }
            catch
            {
                return null;
            }
        }
    }
}
