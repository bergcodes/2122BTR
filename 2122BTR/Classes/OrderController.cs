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

        public List<order> getAllOrders()
        {
            return db.orders.ToList();
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

        public bool editOrderCustomer(order myOrder, customer myCustomer)
        {
            try
            {
                myOrder.customer = myCustomer;
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteOrder(order myOrder)
        {
            try
            {
                db.itemperorders.DeleteAllOnSubmit(myOrder.itemperorders);
                db.orders.DeleteOnSubmit(myOrder);
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
