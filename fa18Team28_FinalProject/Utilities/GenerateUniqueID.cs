using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa18Team28_FinalProject.DAL;

namespace fa18Team28_FinalProject.Utilities
{
    public static class GenerateUniqueID
    {
        public static Int32 GetNextUniqueID(AppDbContext db)
        {
            Int32 intMaxUniqueID; //the current maximum course number
            Int32 intNextUniqueID; //the course number for the next class

            if (db.Books.Count() == 0) //there are no products in the database yet
            {
                intMaxUniqueID = 5000; //course numbers start at 3001
            }
            else
            {
                intMaxUniqueID = Convert.ToInt32(db.Books.Max(c => c.UniqueID)); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextUniqueID = intMaxUniqueID + 1;

            //return the value
            return intNextUniqueID;
        }

    }
}

