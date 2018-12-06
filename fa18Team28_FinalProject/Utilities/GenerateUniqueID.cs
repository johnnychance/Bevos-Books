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
            Int32 intMaxUniqueID; //the maximum book id number
            Int32 intNextUniqueID; //the id number for the next book

            if (db.Books.Count() == 0) //there are no books in the database yet
            {
                intMaxUniqueID = 789000; //book id numbers start at 5001
            }
            else
            {
                intMaxUniqueID = db.Books.Max(c => c.UniqueID); //this is the highest number in the database right now
            }

            //add one to the current max to find the next one
            intNextUniqueID = intMaxUniqueID + 1;

            //return the value
            return intNextUniqueID;
        }

    }
}

