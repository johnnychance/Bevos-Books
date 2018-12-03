using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa18Team28_FinalProject.DAL;

namespace fa18Team28_FinalProject.Utilities
{
    public static class GenerateNextOrderNumber
    {
        public static Int32 GetNextOrderNumber(AppDbContext db)
        {
            Int32 intMaxOrderNumber; //the current maximum order number
            Int32 intNextOrderNumber; //the order number for the next class
            //bool custvalid = false; //customer placed an order
            //bool managervalid = false; //manager placed an order

            if (db.CustomerOrders.Count() == 0) //there are no orders in the database yet
            {
                intMaxOrderNumber = 10000; //customer order numbers start at 10001
                //custvalid = true;
                //managervalid = false;
            }
            /*else if (db.ManagerOrders.Count() == 0)
            {
                intMaxOrderNumber = 10000;
                custvalid = false;
                managervalid = true;
            }
            else
            {
                if (custvalid == false)
                {
                    intMaxOrderNumber = Convert.ToInt32(db.CustomerOrders.Max(c => c.CustomerOrderNumber)); //this is the highest number in the database right now
                }
                else if (managervalid == false)
                {
                    intMaxOrderNumber = Convert.ToInt32(db.ManagerOrders.Max(c => c.ManagerOrderNumber)); //this is the highest number in the database right now
                }
                else
                {
                    intMaxOrderNumber = 0;
                }
                
            }*/
            else
            {
                intMaxOrderNumber = db.CustomerOrders.Max(c => c.CustomerOrderNumber); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextOrderNumber = intMaxOrderNumber + 1;

            //return the value
            return intNextOrderNumber;
        }

    }
}


