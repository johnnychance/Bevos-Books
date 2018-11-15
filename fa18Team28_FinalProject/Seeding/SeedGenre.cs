using System;
using System.Collections.Generic;
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;
using System.Linq;


namespace fa18Team28_FinalProject.Seeding
{
    public static class SeedGenres
    {
        public static void SeedAllGenres(AppDbContext db)
        {
            //check to see if all the languages have already been added
            if (db.Genres.Count() == 21)
            {
                //exit the program - we don't need to do any of this
                NotSupportedException ex = new NotSupportedException("Genre record count is already 21!");
                throw ex;
            }
            Int32 intGenresAdded = 0;
            try
            {
                //Create a list of languages
                List<Genre> Genres = new List<Genre>();

                Genre g1 = new Genre { Name = "Adventure" };
                Genres.Add(g1);

                Genre g2 = new Genre { Name = "Contemporary Fiction" };
                Genres.Add(g2);

                Genre g3 = new Genre { Name = "Fantasy" };
                Genres.Add(g3);

                Genre g4 = new Genre { Name = "Historical Fition" };
                Genres.Add(g4);

                Genre g5 = new Genre { Name = "Horror" };
                Genres.Add(g5);

                Genre g6 = new Genre { Name = "Humor" };
                Genres.Add(g6);

                Genre g7 = new Genre { Name = "Mystery" };
                Genres.Add(g7);

                Genre g8 = new Genre { Name = "Poetry" };
                Genres.Add(g8);

                Genre g9 = new Genre { Name = "Romance" };
                Genres.Add(g9);

                Genre g10 = new Genre { Name = "ScienceFiction" };
                Genres.Add(g10);

                Genre g11 = new Genre { Name = "Shakespeare" };
                Genres.Add(g11);

                Genre g12 = new Genre { Name = "Suspense" };
                Genres.Add(g12);

                Genre g13 = new Genre { Name = "Thriller" };
                Genres.Add(g13);

                Genre l;

                //loop through the list and see which (if any) need to be added
                foreach (Genre gen in Genres)
                {
                    //see if the language already exists in the database
                    l = db.Genres.FirstOrDefault(x => x.Name == gen.Name);

                    //language was not found
                    if (l == null)
                    {
                        //Add the language
                        db.Genres.Add(gen);
                        db.SaveChanges();
                        intGenresAdded += 1;
                    }

                }
            }
            catch
            {
                String msg = "Genres Added: " + intGenresAdded.ToString();
                throw new InvalidOperationException(msg);
            }

        }
    }
}
