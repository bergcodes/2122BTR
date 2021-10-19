using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2122BTR.Classes
{
    class ItemPerOrderController
    {
        dcBTRDataContext db;
        public ItemPerOrderController(dcBTRDataContext db)
        {
            this.db = db;
        }

        public bool createItemPerOrder(int iAmount, int iOrderID, int iProductID)
        {
            try
            {
                itemperorder myIPO = new itemperorder();
                myIPO.amount = iAmount;
                myIPO.orderID = iOrderID;
                myIPO.productID = iProductID;
                db.itemperorders.InsertOnSubmit(myIPO);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool createItemPerOrders(List<itemperorder> myIPOs, order myOrder)
        {
           try
            {
                foreach (itemperorder myIPO in myIPOs)
                {
                    myIPO.orderID = myOrder.orderID;
                }
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
