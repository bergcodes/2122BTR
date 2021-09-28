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
    }
}
