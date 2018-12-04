using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fa18Team28_FinalProject.DAL;

namespace fa18Team28_FinalProject.Utilities
{
    public static class GenerateCartID
    {
        public static Int32 GetNextCartID(AppDbContext db)
        {
            string MaxCartID; 
            Int32 intMaxCartID; //the maximum book id number
            Int32 intNextCartID; //the id number for the next book

            if (db.CartItems.Count() == 0) //there are no books in the database yet
            {
                MaxCartID = "100"; //cart id numbers start at 5001
                intMaxCartID = Convert.ToInt32(MaxCartID);
            }
            else
            {
                intMaxCartID = Convert.ToInt32(db.CartItems.Max(c => c.CartID)); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextCartID = intMaxCartID + 1;

            //return the value
            return intNextCartID;
        }

    }
}

