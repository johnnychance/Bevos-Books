using fa18Team28_FinalProject.Models;
using fa18Team28_FinalProject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace fa18Team28_FinalProject.Seeding
{
    public static class SeedingBooks
    {
        public static void SeedAllBooks(AppDbContext db)
        {
            if (db.Books.Count() == 300)
            {
                throw new NotSupportedException("The database already contains all 300 Books");
            }

            Int32 intBooksAdded = 0;
            String bookName = "Begin";
            List<Book> Books = new List<Book>();

            try
            {
                Book b1 = new Book();
                b1.PublishedDate = new DateTime(2008, 5, 24);
                b1.UniqueID = 789001;
                b1.Title = "The Art Of Racing In The Rain";
                b1.Author = "Garth Stein";
                b1.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Contemporary Fiction");
                b1.Description = "A Lab-terrier mix with great insight into the human condition helps his owner, a struggling race car driver.";
                b1.Price = 23.95m;
                b1.Cost = 10.30m;
                b1.Reordered = 1;
                b1.CopiesOnHand = 2;
                b1.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b1);

                Book b2 = new Book();
                b2.PublishedDate = new DateTime(2008, 5, 24);
                b2.UniqueID = 789002;
                b2.Title = "The Host";
                b2.Author = "Stephenie Meyer";
                b2.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Science Fiction");
                b2.Description = "Aliens have taken control of the minds and bodies of most humans, but one woman won’t surrender.";
                b2.Price = 25.99m;
                b2.Cost = 13.25m;
                b2.Reordered = 7;
                b2.CopiesOnHand = 8;
                b2.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b2);

                Book b3 = new Book();
                b3.PublishedDate = new DateTime(2008, 7, 5);
                b3.UniqueID = 789003;
                b3.Title = "Chasing Darkness";
                b3.Author = "Robert Crais";
                b3.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b3.Description = "The Los Angeles private eye Elvis Cole responsible for the release of a serial killer?";
                b3.Price = 25.95m;
                b3.Cost = 9.08m;
<<<<<<< HEAD
                b3.Reordered = 7;
                b3.CopiesOnHand = 10;
=======
                b3.Reordered = "7";
                b3.CopiesOnHand = "10";
>>>>>>> d5efbb6cdc0bd8f1c12a33149c4cb91a79e132a4
                b3.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b3);

                Book b4 = new Book();
                b4.PublishedDate = new DateTime(2008, 7, 19);
                b4.UniqueID = 789004;
                b4.Title = "Say Goodbye";
                b4.Author = "Lisa Gardner";
                b4.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Suspense");
                b4.Description = "An F.B.I. agent tracks a serial killer who uses spiders as a weapon.";
                b4.Price = 25.00m;
                b4.Cost = 11.25m;
                b4.Reordered = 2;
                b4.CopiesOnHand = 5;
                b4.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b4);

                Book b5 = new Book();
                b5.PublishedDate = new DateTime(2008, 8, 9);
                b5.UniqueID = 789005;
                b5.Title = "The Gargoyle";
                b5.Author = "Andrew Davidson";
                b5.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b5.Description = "A hideously burned man is cared for by a sculptress who claims they were lovers seven centuries ago.";
                b5.Price = 25.95m;
                b5.Cost = 16.09m;
                b5.Reordered = 3;
                b5.CopiesOnHand = 5;
                b5.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b5);

                Book b6 = new Book();
                b6.PublishedDate = new DateTime(2008, 8, 9);
                b6.UniqueID = 789006;
                b6.Title = "Foreign Body";
                b6.Author = "Robin Cook";
                b6.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Thriller");
                b6.Description = "A medical student investigates a rising number of deaths among medical tourists at foreign hospitals.";
                b6.Price = 25.95m;
                b6.Cost = 24.65m;
                b6.Reordered = 6;
                b6.CopiesOnHand = 11;
                b6.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b6);

                Book b7 = new Book();
                b7.PublishedDate = new DateTime(2008, 8, 9);
                b7.UniqueID = 789007;
                b7.Title = "Acheron";
                b7.Author = "Sherrilyn Kenyon";
                b7.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b7.Description = "Book 12 of the Dark-Hunter paranormal series.";
                b7.Price = 24.95m;
                b7.Cost = 13.72m;
                b7.Reordered = 2;
                b7.CopiesOnHand = 2;
                b7.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b7);

                Book b8 = new Book();
                b8.PublishedDate = new DateTime(2008, 8, 23);
                b8.UniqueID = 789008;
                b8.Title = "Being Elizabeth";
                b8.Author = "Barbara Taylor Bradford";
                b8.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Contemporary Fiction");
                b8.Description = "A 25-year-old newly in control of her family’s corporate empire faces tough choices in business and in love.";
                b8.Price = 27.95m;
                b8.Cost = 21.80m;
                b8.Reordered = 5;
                b8.CopiesOnHand = 9;
                b8.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b8);

                Book b9 = new Book();
                b9.PublishedDate = new DateTime(2008, 8, 30);
                b9.UniqueID = 789009;
                b9.Title = "Just Breathe";
                b9.Author = "Susan Wiggs";
                b9.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b9.Description = "Her marriage broken, the author of a syndicated comic strip flees to California, where romance and surprise await.";
                b9.Price = 25.95m;
                b9.Cost = 5.45m;
                b9.Reordered = 8;
                b9.CopiesOnHand = 8;
                b9.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b9);

                Book b10 = new Book();
                b10.PublishedDate = new DateTime(2008, 8, 30);
                b10.UniqueID = 789010;
                b10.Title = "The Gypsy Morph";
                b10.Author = "Terry Brooks";
                b10.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b10.Description = "In the third volume of the Genesis of Shannara series, champions of the Word and the Void clash.";
                b10.Price = 27.00m;
                b10.Cost = 6.75m;
                b10.Reordered = 6;
                b10.CopiesOnHand = 6;
                b10.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b10);

                Book b11 = new Book();
                b11.PublishedDate = new DateTime(2008, 9, 20);
                b11.UniqueID = 789011;
                b11.Title = "The Other Queen";
                b11.Author = "Philippa Gregory";
                b11.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Historical Fiction");
                b11.Description = "The story of Mary, Queen of Scots, in captivity under Queen Elizabeth.";
                b11.Price = 25.95m;
                b11.Cost = 23.61m;
                b11.Reordered = 3;
                b11.CopiesOnHand = 8;
                b11.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b11);

                Book b12 = new Book();
                b12.PublishedDate = new DateTime(2008, 9, 27);
                b12.UniqueID = 789012;
                b12.Title = "One Fifth Avenue";
                b12.Author = "Candace Bushnell";
                b12.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b12.Description = "The worlds of gossip, theater and hedge funds have one address in common.";
                b12.Price = 25.95m;
                b12.Cost = 17.65m;
                b12.Reordered = 1;
                b12.CopiesOnHand = 2;
                b12.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b12);

                Book b13 = new Book();
                b13.PublishedDate = new DateTime(2008, 9, 27);
                b13.UniqueID = 789013;
                b13.Title = "The Given Day";
                b13.Author = "Dennis Lehane";
                b13.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Historical Fiction");
                b13.Description = "A policman, a fugitive and their families persevere in the turbulence of Boston at the end of World War I.";
                b13.Price = 27.95m;
                b13.Cost = 6.99m;
                b13.Reordered = 6;
                b13.CopiesOnHand = 11;
                b13.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b13);

                Book b14 = new Book();
                b14.PublishedDate = new DateTime(2008, 10, 4);
                b14.UniqueID = 789014;
                b14.Title = "A Cedar Cove Christmas";
                b14.Author = "Debbie Macomber";
                b14.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b14.Description = "A pregnant woman shows up in Cedar Cove on Christmas Eve and goes into labor in a room above a stable.";
                b14.Price = 16.95m;
                b14.Cost = 4.75m;
                b14.Reordered = 4;
                b14.CopiesOnHand = 6;
                b14.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b14);

                Book b15 = new Book();
                b15.PublishedDate = new DateTime(2008, 10, 11);
                b15.UniqueID = 789015;
                b15.Title = "The Pirate King";
                b15.Author = "R A Salvatore";
                b15.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b15.Description = "In Book 2 of the Transitions fantasy series, Drizzt returns to Luskan, a city dominated by dangerous pirates.";
                b15.Price = 27.95m;
                b15.Cost = 14.25m;
                b15.Reordered = 5;
                b15.CopiesOnHand = 6;
                b15.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b15);

                Book b16 = new Book();
                b16.PublishedDate = new DateTime(2008, 10, 25);
<<<<<<< HEAD
                b16.UniqueID = 789016;
=======
                b16.UniqueID = "789016";
>>>>>>> d5efbb6cdc0bd8f1c12a33149c4cb91a79e132a4
                b16.Title = "Bones";
                b16.Author = "Jonathan Kellerman";
                b16.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b16.Description = "The psychologist-detective Alex Delaware is called in when women’s bodies keep turning up in a Los Angeles marsh.";
                b16.Price = 27.00m;
                b16.Cost = 14.85m;
                b16.Reordered = 2;
                b16.CopiesOnHand = 7;
                b16.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b16);

                Book b17 = new Book();
                b17.PublishedDate = new DateTime(2008, 10, 25);
                b17.UniqueID = 789017;
                b17.Title = "Rough Weather";
                b17.Author = "Robert B Parker";
                b17.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b17.Description = "The Boston private eye Spenser gets involved when a gunman kidnaps the bride from her wedding on a private island.";
                b17.Price = 26.95m;
                b17.Cost = 20.75m;
                b17.Reordered = 8;
                b17.CopiesOnHand = 10;
                b17.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b17);

                Book b18 = new Book();
                b18.PublishedDate = new DateTime(2008, 10, 25);
                b18.UniqueID = 789018;
                b18.Title = "Extreme Measures";
                b18.Author = "Vince Flynn";
                b18.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Suspense");
                b18.Description = "Mitch Rapp teams up with a C.I.A. colleague to fight a terrorist cell — and the politicians who would rein them in.";
                b18.Price = 27.95m;
                b18.Cost = 15.09m;
                b18.Reordered = 2;
                b18.CopiesOnHand = 4;
                b18.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b18);

                Book b19 = new Book();
                b19.PublishedDate = new DateTime(2008, 11, 1);
                b19.UniqueID = 789019;
                b19.Title = "A Good Woman";
                b19.Author = "Danielle Steel";
                b19.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b19.Description = "An American society girl who made a new life as a doctor in World War I France returns to New York.";
                b19.Price = 27.00m;
                b19.Cost = 10.53m;
                b19.Reordered = 1;
                b19.CopiesOnHand = 6;
                b19.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b19);

                Book b20 = new Book();
                b20.PublishedDate = new DateTime(2008, 11, 8);
                b20.UniqueID = 789020;
                b20.Title = "Midnight";
                b20.Author = "Sister Souljah";
                b20.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Contemporary Fiction");
                b20.Description = "A boy from Sudan struggles to protect his mother and sister and remain true to his Islamic principles in a Brooklyn housing project.";
                b20.Price = 26.95m;
                b20.Cost = 21.29m;
                b20.Reordered = 3;
                b20.CopiesOnHand = 8;
                b20.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b20);

                Book b21 = new Book();
                b21.PublishedDate = new DateTime(2008, 12, 16);
                b21.UniqueID = 789021;
                b21.Title = "Scarpetta";
                b21.Author = "Patricia Cornwell";
                b21.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b21.Description = "The forensic pathologist Kay Scarpetta takes an assignment in New York City.";
                b21.Price = 27.95m;
                b21.Cost = 13.14m;
                b21.Reordered = 4;
                b21.CopiesOnHand = 9;
                b21.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b21);

                Book b22 = new Book();
                b22.PublishedDate = new DateTime(2009, 1, 31);
                b22.UniqueID = 789022;
                b22.Title = "A Darker Place";
                b22.Author = "Jack Higgins";
                b22.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Suspense");
                b22.Description = "A Russian defector becomes a counterspy.";
                b22.Price = 26.95m;
                b22.Cost = 11.86m;
                b22.Reordered = 7;
                b22.CopiesOnHand = 11;
                b22.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b22);

                Book b23 = new Book();
                b23.PublishedDate = new DateTime(2009, 4, 11);
                b23.UniqueID = 789023;
                b23.Title = "Fatally Flaky";
                b23.Author = "Diane Mott Davidson";
                b23.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b23.Description = "The caterer Goldy Schulz tries to outwit a killer on the grounds of an Aspen spa.";
                b23.Price = 25.99m;
                b23.Cost = 22.09m;
                b23.Reordered = 1;
                b23.CopiesOnHand = 5;
                b23.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b23);

                Book b24 = new Book();
                b24.PublishedDate = new DateTime(2009, 4, 11);
                b24.UniqueID = 789024;
                b24.Title = "Turn Coat";
                b24.Author = "Jim Butcher";
                b24.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b24.Description = "Book 11 of the Dresden Files series about a wizard detective in Chicago.";
                b24.Price = 25.95m;
                b24.Cost = 9.34m;
                b24.Reordered = 3;
                b24.CopiesOnHand = 6;
                b24.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b24);

                Book b25 = new Book();
                b25.PublishedDate = new DateTime(2009, 4, 11);
                b25.UniqueID = 789025;
                b25.Title = "Borderline";
                b25.Author = "Nevada Barr";
                b25.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Suspense");
                b25.Description = "Off duty and on vacation in Big Bend National Park, Anna Pigeon rescues a baby and is drawn into cross-border intrigue.";
                b25.Price = 25.95m;
                b25.Cost = 3.11m;
                b25.Reordered = 3;
                b25.CopiesOnHand = 8;
                b25.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b25);

                Book b26 = new Book();
                b26.PublishedDate = new DateTime(2009, 5, 2);
                b26.UniqueID = 789026;
                b26.Title = "Summer On Blossom Street";
                b26.Author = "Debbie Macomber";
                b26.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b26.Description = "More stories of life and love from a Seattle knitting class.";
                b26.Price = 24.95m;
                b26.Cost = 7.24m;
                b26.Reordered = 2;
                b26.CopiesOnHand = 7;
                b26.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b26);

                Book b27 = new Book();
                b27.PublishedDate = new DateTime(2009, 5, 9);
                b27.UniqueID = 789027;
                b27.Title = "Dead And Gone";
                b27.Author = "Charlaine Harris";
                b27.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b27.Description = "Sookie Stackhouse searches for the killer of a werepanther.";
                b27.Price = 25.95m;
                b27.Cost = 24.65m;
                b27.Reordered = 5;
                b27.CopiesOnHand = 10;
                b27.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b27);

                Book b28 = new Book();
                b28.PublishedDate = new DateTime(2009, 5, 9);
                b28.UniqueID = 789028;
                b28.Title = "Brooklyn";
                b28.Author = "Colm Toibin";
                b28.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Historical Fiction");
                b28.Description = "An unsophisticated young Irishwoman leaves her home for New York in the 1950s. Originally published in 2009 and the basis of the 2015 movie.";
                b28.Price = 18.95m;
                b28.Cost = 3.60m;
                b28.Reordered = 1;
                b28.CopiesOnHand = 1;
                b28.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b28);

                Book b29 = new Book();
                b29.PublishedDate = new DateTime(2009, 5, 16);
                b29.UniqueID = 789029;
                b29.Title = "The Last Child";
                b29.Author = "John Hart";
                b29.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b29.Description = "A teenager searches for his inexplicably vanished twin sister.";
                b29.Price = 24.95m;
                b29.Cost = 15.72m;
                b29.Reordered = 2;
                b29.CopiesOnHand = 5;
                b29.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b29);

                Book b30 = new Book();
                b30.PublishedDate = new DateTime(2009, 5, 30);
                b30.UniqueID = 789030;
                b30.Title = "Heartless";
                b30.Author = "Diana Palmer";
                b30.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Romance");
                b30.Description = "A woman‘s secret makes it hard for her to accept her stepbrother‘s love.";
                b30.Price = 24.95m;
                b30.Cost = 21.46m;
                b30.Reordered = 4;
                b30.CopiesOnHand = 4;
                b30.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b30);

                Book b31 = new Book();
                b31.PublishedDate = new DateTime(2009, 5, 30);
                b31.UniqueID = 789031;
                b31.Title = "Shanghai Girls";
                b31.Author = "Lisa See";
                b31.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Historical Fiction");
                b31.Description = "Two Chinese sisters in the 1930s are sold as wives to men from California, and leave their war-torn country to join them.";
                b31.Price = 25.00m;
                b31.Cost = 2.50m;
                b31.Reordered = 4;
                b31.CopiesOnHand = 4;
                b31.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b31);

                Book b32 = new Book();
                b32.PublishedDate = new DateTime(2009, 6, 6);
                b32.UniqueID = 789032;
                b32.Title = "Skin Trade";
                b32.Author = "Laurell K Hamilton";
                b32.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b32.Description = "Investigating some killings in Las Vegas, the vampire hunter Anita Blake must contend with the power of the weretigers.";
                b32.Price = 26.95m;
                b32.Cost = 2.70m;
                b32.Reordered = 8;
                b32.CopiesOnHand = 9;
                b32.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b32);

                Book b33 = new Book();
                b33.PublishedDate = new DateTime(2009, 6, 13);
                b33.UniqueID = 789033;
                b33.Title = "Roadside Crosses";
                b33.Author = "Jeffery Deaver";
                b33.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b33.Description = "A California kinesics expert pursues a killer who stalks victims using information they’ve posted online.";
                b33.Price = 26.95m;
                b33.Cost = 7.82m;
                b33.Reordered = 8;
                b33.CopiesOnHand = 13;
                b33.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b33);

                Book b34 = new Book();
                b34.PublishedDate = new DateTime(2009, 6, 27);
                b34.UniqueID = 789034;
                b34.Title = "Finger Lickin’ Fifteen";
                b34.Author = "Janet Evanovich";
                b34.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b34.Description = "The bounty hunter Stephanie Plum hunts a celebrity chef’s killer.";
                b34.Price = 27.95m;
                b34.Cost = 3.63m;
                b34.Reordered = 4;
                b34.CopiesOnHand = 7;
                b34.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b34);

                Book b35 = new Book();
                b35.PublishedDate = new DateTime(2009, 7, 4);
                b35.UniqueID = 789035;
                b35.Title = "Return To Sullivans Island";
                b35.Author = "Dorothea Benton Frank";
                b35.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Contemporary Fiction");
                b35.Description = "A recent college graduate returns to her family’s home on an island in the South Carolina Lowcountry and wrestles with tragedy and betrayal in the company of her appealing relatives.";
                b35.Price = 25.99m;
                b35.Cost = 13.25m;
                b35.Reordered = 8;
                b35.CopiesOnHand = 13;
                b35.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b35);

                Book b36 = new Book();
                b36.PublishedDate = new DateTime(2009, 7, 11);
                b36.UniqueID = 789036;
                b36.Title = "The Castaways";
                b36.Author = "Elin Hilderbrand";
                b36.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Contemporary Fiction");
                b36.Description = "A Nantucket couple drowns, raising questions and precipitating conflicts among their group of friends.";
                b36.Price = 24.99m;
                b36.Cost = 16.99m;
                b36.Reordered = 2;
                b36.CopiesOnHand = 7;
                b36.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b36);

                Book b37 = new Book();
                b37.PublishedDate = new DateTime(2009, 7, 18);
                b37.UniqueID = 789037;
                b37.Title = "Rain Gods";
                b37.Author = "James Lee Burke";
                b37.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Thriller");
                b37.Description = "A Texas sheriff investigates a mass murder of illegal aliens and tries to find the young Iraq war veteran who may have been involved — before the F.B.I. can.";
                b37.Price = 25.99m;
                b37.Cost = 21.05m;
                b37.Reordered = 2;
                b37.CopiesOnHand = 6;
                b37.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b37);

                Book b38 = new Book();
                b38.PublishedDate = new DateTime(2009, 7, 18);
                b38.UniqueID = 89038;
                b38.Title = "Undone";
                b38.Author = "Karin Slaughter";
                b38.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Suspense");
                b38.Description = "Dr. Sara Linton works with agents of the Georgia Bureau of Investigation to stop a killer who tortures his victims.";
                b38.Price = 26.00m;
                b38.Cost = 7.28m;
                b38.Reordered = 2;
                b38.CopiesOnHand = 4;
                b38.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b38);

                Book b39 = new Book();
                b39.PublishedDate = new DateTime(2009, 7, 18);
                b39.UniqueID = 789039;
                b39.Title = "Guardian Of Lies";
                b39.Author = "Steve Martini";
                b39.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b39.Description = "The lawyer Paul Madriani unravels a mystery involving gold coins, the C.I.A., and a weapon forgotten since the Cuban missile crisis.";
                b39.Price = 26.99m;
                b39.Cost = 18.62m;
                b39.Reordered = 2;
                b39.CopiesOnHand = 6;
                b39.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b39);

                Book b40 = new Book();
                b40.PublishedDate = new DateTime(2009, 8, 22);
                b40.UniqueID = 789040;
                b40.Title = "Dreamfever";
                b40.Author = "Karen Marie Moning";
                b40.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b40.Description = "MacKlaya finds herself under the erotic spell of a Fae master.";
                b40.Price = 26.00m;
                b40.Cost = 21.06m;
                b40.Reordered = 6;
                b40.CopiesOnHand = 10;
                b40.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b40);

                Book b41 = new Book();
                b41.PublishedDate = new DateTime(2009, 8, 29);
                b41.UniqueID = 789041;
                b41.Title = "Resurrecting Midnight";
                b41.Author = "Eric Jerome Dickey";
                b41.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Suspense");
                b41.Description = "Gideon, an international assassin, travels to Argentina in pursuit of a dangerous assignment.";
                b41.Price = 26.95m;
                b41.Cost = 14.55m;
                b41.Reordered = 3;
                b41.CopiesOnHand = 3;
                b41.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b41);

                Book b42 = new Book();
                b42.PublishedDate = new DateTime(2009, 9, 12);
                b42.UniqueID = 789042;
                b42.Title = "Dexter By Design";
                b42.Author = "Jeff Lindsay";
                b42.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b42.Description = "A serial killer who arranges victims in artful poses challenges the Miami Police Department and its blood splatter analyst, Dexter.";
                b42.Price = 25.00m;
                b42.Cost = 2.75m;
                b42.Reordered = 9;
                b42.CopiesOnHand = 13;
                b42.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b42);

                Book b43 = new Book();
                b43.PublishedDate = new DateTime(2009, 10, 10);
                b43.UniqueID = 789043;
                b43.Title = "The Professional";
                b43.Author = "Robert B Parker";
                b43.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b43.Description = "Rich women are turning up dead, and the Boston P.I. Spenser investigates.";
                b43.Price = 26.95m;
                b43.Cost = 7.01m;
                b43.Reordered = 8;
                b43.CopiesOnHand = 9;
                b43.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b43);

                Book b44 = new Book();
                b44.PublishedDate = new DateTime(2009, 10, 10);
                b44.UniqueID = 789044;
                b44.Title = "The Unseen Academicals";
                b44.Author = "Terry Pratchett";
                b44.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b44.Description = "In this Discworld fantasy, the benevolent tyrant of Ankh-Morpork suggests that Unseen University put together a football team.";
                b44.Price = 25.99m;
                b44.Cost = 3.12m;
                b44.Reordered = 9;
                b44.CopiesOnHand = 14;
                b44.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b44);

                Book b45 = new Book();
                b45.PublishedDate = new DateTime(2009, 10, 17);
                b45.UniqueID = 789045;
                b45.Title = "Pursuit Of Honor";
                b45.Author = "Vince Flynn";
                b45.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Suspense");
                b45.Description = "The counterterrorism operative Mitch Rapp must teach politicians about national security following a new Qaeda attack.";
                b45.Price = 27.99m;
                b45.Cost = 5.04m;
                b45.Reordered = 4;
                b45.CopiesOnHand = 4;
                b45.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b45);

                Book b46 = new Book();
                b46.PublishedDate = new DateTime(2009, 11, 7);
                b46.UniqueID = 789046;
                b46.Title = "No Less Than Victory";
                b46.Author = "Jeff Shaara";
                b46.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Historical Fiction");
                b46.Description = "The final volume of a trilogy of novels about World War II focuses on the final years of the war, including the Battle of the Bulge and the American sweep through Germany.";
                b46.Price = 28.00m;
                b46.Cost = 20.72m;
                b46.Reordered = 1;
                b46.CopiesOnHand = 3;
                b46.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b46);

                Book b47 = new Book();
                b47.PublishedDate = new DateTime(2009, 11, 7);
                b47.UniqueID = 789047;
                b47.Title = "Ford County";
                b47.Author = "John Grisham";
                b47.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Contemporary Fiction");
                b47.Description = "Stories set in rural Mississippi.";
                b47.Price = 24.00m;
                b47.Cost = 14.88m;
                b47.Reordered = 10;
                b47.CopiesOnHand = 12;
                b47.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b47);

                Book b48 = new Book();
                b48.PublishedDate = new DateTime(2009, 11, 14);
                b48.UniqueID = 789048;
                b48.Title = "Wishin' And Hopin'";
                b48.Author = "Wally Lamb";
                b48.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Humor");
                b48.Description = "A fifth-grader in 1964 gets ready for Christmas.";
                b48.Price = 15.00m;
                b48.Cost = 13.95m;
                b48.Reordered = 3;
                b48.CopiesOnHand = 3;
                b48.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b48);

                Book b49 = new Book();
                b49.PublishedDate = new DateTime(2009, 11, 28);
                b49.UniqueID = 789049;
                b49.Title = "First Lord’S Fury";
                b49.Author = "Jim Butcher";
                b49.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Fantasy");
                b49.Description = "With their survival at stake, Alerans prepare for a final battle in the sixth book of the Alera fantasy cycle.";
                b49.Price = 25.95m;
                b49.Cost = 13.23m;
                b49.Reordered = 1;
                b49.CopiesOnHand = 4;
                b49.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b49);

                Book b50 = new Book();
                b50.PublishedDate = new DateTime(2010, 1, 2);
                b50.UniqueID = 789050;
                b50.Title = "Altar Of Eden";
                b50.Author = "James Rollins";
                b50.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Thriller");
                b50.Description = "A Louisiana veterinarian discovers a wrecked fishing trawler filled with genetically altered animals.";
                b50.Price = 27.99m;
                b50.Cost = 25.75m;
                b50.Reordered = 1;
                b50.CopiesOnHand = 1;
                b50.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b50);

                Book b51 = new Book();
                b51.PublishedDate = new DateTime(2010, 1, 2);
                b51.UniqueID = 789051;
                b51.Title = "Deeper Than The Dead";
                b51.Author = "Tami Hoag";
                b51.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b51.Description = "An F.B.I. investigator and a teacher track a series of murders in California in 1985.";
                b51.Price = 26.95m;
                b51.Cost = 9.70m;
                b51.Reordered = 4;
                b51.CopiesOnHand = 9;
                b51.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b51);

                Book b52 = new Book();
                b52.PublishedDate = new DateTime(2010, 1, 16);
                b52.UniqueID = 789052;
                b52.Title = "Roses";
                b52.Author = "Leila Meacham";
                b52.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Historical Fiction");
                b52.Description = "Three generations in a small East Texas town.";
                b52.Price = 24.99m;
                b52.Cost = 20.99m;
                b52.Reordered = 8;
                b52.CopiesOnHand = 12;
                b52.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b52);

                Book b53 = new Book();
                b53.PublishedDate = new DateTime(2010, 1, 30);
                b53.UniqueID = 789053;
                b53.Title = "Blood Ties";
                b53.Author = "Kay Hooper";
                b53.Genre = db.Genres.FirstOrDefault(x => x.GenreName == "Mystery");
                b53.Description = "The F.B.I. agent Noah Bishop and his special crimes unit  pursue a brutal enemy.";
                b53.Price = 26.00m;
                b53.Cost = 5.20m;
                b53.Reordered = 7;
                b53.CopiesOnHand = 7;
                b53.LastOrdered = new DateTime(2018, 10, 1);
                Books.Add(b53);


                //loop through repos
                foreach (Book book in Books)
                {
                    //set name of repo to help debug
                    bookName = book.Title;

                    //see if repo exists in database
                    Book dbBook = db.Books.FirstOrDefault(b => b.Title == book.Title);

                    if (dbBook == null) //repository does not exist in database
                    {
                        db.Books.Add(book);
                        db.SaveChanges();
                        intBooksAdded += 1;
                    }
                    else
                    {
                        dbBook.PublishedDate = book.PublishedDate;
                        dbBook.UniqueID = book.UniqueID;
                        dbBook.Title = book.Title;
                        dbBook.Author = book.Author;
                        dbBook.Genre = db.Genres.FirstOrDefault(l => l.GenreID == book.Genre.GenreID);
                        dbBook.Description = book.Description;
                        dbBook.Price = book.Price;
                        dbBook.Cost = book.Cost;
                        dbBook.Reordered = book.Reordered;
                        dbBook.CopiesOnHand = book.CopiesOnHand;
                        dbBook.LastOrdered = book.LastOrdered;
                        db.Update(dbBook);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                String msg = "Books added:" + intBooksAdded + "; Error on " + bookName;
                throw new InvalidOperationException(msg);
            }
        }
    }
}