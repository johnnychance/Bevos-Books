/*using fa18Team28_FinalProject.Models;
using fa18Team28_FinalProject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace fa18Team28_FinalProject.Seeding
{
	public static class SeedCustomers
	{
		public static void SeedAllCustomers(AppDbContext db)
		{
			if (db.Customers.Count() == 300) //change this number
			{
				throw new NotSupportedException("The database already contains all 300 customers!"); //change error text
			}

			Int32 intCustomersAdded = 0;
			String customerName = "Begin"; //helps to keep track of error on repos
			List<Customer> Customers = new List<Customer>();

			try
			{
				Customer c1 = new Customer();
				c1.CustomerID = 9010;
				c1.Password = "bookworm";
				c1.LastName = "Baker";
				c1.FirstName = "Christopher";
				c1.MiddleInitial = "L.";
				c1.Birthday = 18225;
				c1.Street = "1898 Schurz Alley";
				c1.City = "Austin";
				c1.State = "TX";
				c1.ZipCode = 78705;
				c1.SSN = "477-44-9589";
				c1.EmailAddress = "cbaker@example.com";
				c1.PhoneNumber = 5725458641;
				Customers.Add(c1);

				Customer c2 = new Customer();
				c2.CustomerID = 9011;
				c2.Password = "potato";
				c2.LastName = "Banks";
				c2.FirstName = "Michelle";
				c2.MiddleInitial = "";
				c2.Birthday = 22977;
				c2.Street = "97 Elmside Pass";
				c2.City = "Austin";
				c2.State = "TX";
				c2.ZipCode = 78712;
				c2.SSN = "247-31-0787";
				c2.EmailAddress = "banker@longhorn.net";
				c2.PhoneNumber = 9867048435;
				Customers.Add(c2);

				Customer c3 = new Customer();
				c3.CustomerID = 9012;
				c3.Password = "painting";
				c3.LastName = "Broccolo";
				c3.FirstName = "Franco";
				c3.MiddleInitial = "V";
				c3.Birthday = 33888;
				c3.Street = "88 Crowley Circle";
				c3.City = "Austin";
				c3.State = "TX";
				c3.ZipCode = 78786;
				c3.SSN = "486-47-8748";
				c3.EmailAddress = "franco@example.com";
				c3.PhoneNumber = 6836109514;
				Customers.Add(c3);

				Customer c4 = new Customer();
				c4.CustomerID = 9013;
				c4.Password = "texas1";
				c4.LastName = "Chang";
				c4.FirstName = "Wendy";
				c4.MiddleInitial = "L";
				c4.Birthday = 35566;
				c4.Street = "56560 Sage Junction";
				c4.City = "Eagle Pass";
				c4.State = "TX";
				c4.ZipCode = 78852;
				c4.SSN = "182-52-9193";
				c4.EmailAddress = "wchang@example.com";
				c4.PhoneNumber = 7070911071;
				Customers.Add(c4);

				Customer c5 = new Customer();
				c5.CustomerID = 9014;
				c5.Password = "Anchorage";
				c5.LastName = "Chou";
				c5.FirstName = "Lim";
				c5.MiddleInitial = "";
				c5.Birthday = 25664;
				c5.Street = "60 Lunder Point";
				c5.City = "Austin";
				c5.State = "TX";
				c5.ZipCode = 78729;
				c5.SSN = "679-75-0653";
				c5.EmailAddress = "limchou@gogle.com";
				c5.PhoneNumber = 1488907687;
				Customers.Add(c5);

				Customer c6 = new Customer();
				c6.CustomerID = 9015;
				c6.Password = "aggies";
				c6.LastName = "Dixon";
				c6.FirstName = "Shan";
				c6.MiddleInitial = "D";
				c6.Birthday = 30693;
				c6.Street = "9448 Pleasure Avenue";
				c6.City = "Georgetown";
				c6.State = "TX";
				c6.ZipCode = 78628;
				c6.SSN = "593-06-9800";
				c6.EmailAddress = "shdixon@aoll.com";
				c6.PhoneNumber = 6899701824;
				Customers.Add(c6);

				Customer c7 = new Customer();
				c7.CustomerID = 9016;
				c7.Password = "hampton1";
				c7.LastName = "Evans";
				c7.FirstName = "Jim Bob";
				c7.MiddleInitial = "";
				c7.Birthday = 21802;
				c7.Street = "51 Emmet Parkway";
				c7.City = "Austin";
				c7.State = "TX";
				c7.ZipCode = 78705;
				c7.SSN = "647-72-4711";
				c7.EmailAddress = "j.b.evans@aheca.org";
				c7.PhoneNumber = 9986825917;
				Customers.Add(c7);

				Customer c8 = new Customer();
				c8.CustomerID = 9017;
				c8.Password = "longhorns";
				c8.LastName = "Feeley";
				c8.FirstName = "Lou Ann";
				c8.MiddleInitial = "K";
				c8.Birthday = 36903;
				c8.Street = "65 Darwin Crossing";
				c8.City = "Austin";
				c8.State = "TX";
				c8.ZipCode = 78704;
				c8.SSN = "577-89-2279";
				c8.EmailAddress = "feeley@penguin.org";
				c8.PhoneNumber = 3464121966;
				Customers.Add(c8);

				Customer c9 = new Customer();
				c9.CustomerID = 9018;
				c9.Password = "mustangs";
				c9.LastName = "Freeley";
				c9.FirstName = "Tesa";
				c9.MiddleInitial = "P";
				c9.Birthday = 33273;
				c9.Street = "7352 Loftsgordon Court";
				c9.City = "College Station";
				c9.State = "TX";
				c9.ZipCode = 77840;
				c9.SSN = "853-72-9538";
				c9.EmailAddress = "tfreeley@minnetonka.ci.us";
				c9.PhoneNumber = 6581357270;
				Customers.Add(c9);

				Customer c10 = new Customer();
				c10.CustomerID = 9019;
				c10.Password = "onetime";
				c10.LastName = "Garcia";
				c10.FirstName = "Margaret";
				c10.MiddleInitial = "L";
				c10.Birthday = 33513;
				c10.Street = "7 International Road";
				c10.City = "Austin";
				c10.State = "TX";
				c10.ZipCode = 78756;
				c10.SSN = "887-12-0229";
				c10.EmailAddress = "mgarcia@gogle.com";
				c10.PhoneNumber = 3767347949;
				Customers.Add(c10);

				Customer c11 = new Customer();
				c11.CustomerID = 9020;
				c11.Password = "pepperoni";
				c11.LastName = "Haley";
				c11.FirstName = "Charles";
				c11.MiddleInitial = "E";
				c11.Birthday = 27220;
				c11.Street = "8 Warrior Trail";
				c11.City = "Austin";
				c11.State = "TX";
				c11.ZipCode = 78746;
				c11.SSN = "528-58-6911";
				c11.EmailAddress = "chaley@thug.com";
				c11.PhoneNumber = 2198604221;
				Customers.Add(c11);

				Customer c12 = new Customer();
				c12.CustomerID = 9021;
				c12.Password = "raiders";
				c12.LastName = "Hampton";
				c12.FirstName = "Jeffrey";
				c12.MiddleInitial = "T.";
				c12.Birthday = 38056;
				c12.Street = "9107 Lighthouse Bay Road";
				c12.City = "Austin";
				c12.State = "TX";
				c12.ZipCode = 78756;
				c12.SSN = "658-45-9102";
				c12.EmailAddress = "jeffh@sonic.com";
				c12.PhoneNumber = 1222185888;
				Customers.Add(c12);

				Customer c13 = new Customer();
				c13.CustomerID = 9022;
				c13.Password = "jhearn22";
				c13.LastName = "Hearn";
				c13.FirstName = "John";
				c13.MiddleInitial = "B";
				c13.Birthday = 18480;
				c13.Street = "59784 Pierstorff Center";
				c13.City = "Liberty";
				c13.State = "TX";
				c13.ZipCode = 77575;
				c13.SSN = "712-69-1666";
				c13.EmailAddress = "wjhearniii@umich.org";
				c13.PhoneNumber = 5123071976;
				Customers.Add(c13);

				Customer c14 = new Customer();
				c14.CustomerID = 9023;
				c14.Password = "hickhickup";
				c14.LastName = "Hicks";
				c14.FirstName = "Anthony";
				c14.MiddleInitial = "J";
				c14.Birthday = 38329;
				c14.Street = "932 Monica Way";
				c14.City = "San Antonio";
				c14.State = "TX";
				c14.ZipCode = 78203;
				c14.SSN = "179-94-2233";
				c14.EmailAddress = "ahick@yaho.com";
				c14.PhoneNumber = 1211949601;
				Customers.Add(c14);

				Customer c15 = new Customer();
				c15.CustomerID = 9024;
				c15.Password = "ingram2015";
				c15.LastName = "Ingram";
				c15.FirstName = "Brad";
				c15.MiddleInitial = "S.";
				c15.Birthday = 37139;
				c15.Street = "4 Lukken Court";
				c15.City = "New Braunfels";
				c15.State = "TX";
				c15.ZipCode = 78132;
				c15.SSN = "126-14-4287";
				c15.EmailAddress = "ingram@jack.com";
				c15.PhoneNumber = 1372121569;
				Customers.Add(c15);

				Customer c16 = new Customer();
				c16.CustomerID = 9025;
				c16.Password = "toddy25";
				c16.LastName = "Jacobs";
				c16.FirstName = "Todd";
				c16.MiddleInitial = "L.";
				c16.Birthday = 36180;
				c16.Street = "7 Susan Junction";
				c16.City = "New York";
				c16.State = "NY";
				c16.ZipCode = 10101;
				c16.SSN = "355-61-0890";
				c16.EmailAddress = "toddj@yourmom.com";
				c16.PhoneNumber = 8543163836;
				Customers.Add(c16);

				Customer c17 = new Customer();
				c17.CustomerID = 9026;
				c17.Password = "something";
				c17.LastName = "Lawrence";
				c17.FirstName = "Victoria";
				c17.MiddleInitial = "M.";
				c17.Birthday = 36630;
				c17.Street = "669 Oak Junction";
				c17.City = "Lockhart";
				c17.State = "TX";
				c17.ZipCode = 78644;
				c17.SSN = "840-91-4997";
				c17.EmailAddress = "thequeen@aska.net";
				c17.PhoneNumber = 3214163359;
				Customers.Add(c17);

				Customer c18 = new Customer();
				c18.CustomerID = 9027;
				c18.Password = "Password1";
				c18.LastName = "Lineback";
				c18.FirstName = "Erik";
				c18.MiddleInitial = "W";
				c18.Birthday = 37957;
				c18.Street = "099 Luster Point";
				c18.City = "Kingwood";
				c18.State = "TX";
				c18.ZipCode = 77325;
				c18.SSN = "303-25-5592";
				c18.EmailAddress = "linebacker@gogle.com";
				c18.PhoneNumber = 2505265350;
				Customers.Add(c18);

				Customer c19 = new Customer();
				c19.CustomerID = 9028;
				c19.Password = "aclfest2017";
				c19.LastName = "Lowe";
				c19.FirstName = "Ernest";
				c19.MiddleInitial = "S";
				c19.Birthday = 28466;
				c19.Street = "35473 Hansons Hill";
				c19.City = "Beverly Hills";
				c19.State = "CA";
				c19.ZipCode = 90210;
				c19.SSN = "547-72-1592";
				c19.EmailAddress = "elowe@netscare.net";
				c19.PhoneNumber = 4070619503;
				Customers.Add(c19);

				Customer c20 = new Customer();
				c20.CustomerID = 9029;
				c20.Password = "nothinggood";
				c20.LastName = "Luce";
				c20.FirstName = "Chuck";
				c20.MiddleInitial = "B";
				c20.Birthday = 17973;
				c20.Street = "4 Emmet Junction";
				c20.City = "Navasota";
				c20.State = "TX";
				c20.ZipCode = 77868;
				c20.SSN = "434-46-8800";
				c20.EmailAddress = "cluce@gogle.com";
				c20.PhoneNumber = 7358436110;
				Customers.Add(c20);

				Customer c21 = new Customer();
				c21.CustomerID = 9030;
				c21.Password = "whatever";
				c21.LastName = "MacLeod";
				c21.FirstName = "Jennifer";
				c21.MiddleInitial = "D.";
				c21.Birthday = 17219;
				c21.Street = "3 Orin Road";
				c21.City = "Austin";
				c21.State = "TX";
				c21.ZipCode = 78712;
				c21.SSN = "219-58-3683";
				c21.EmailAddress = "mackcloud@george.com";
				c21.PhoneNumber = 7240178229;
				Customers.Add(c21);

				Customer c22 = new Customer();
				c22.CustomerID = 9031;
				c22.Password = "snowsnow";
				c22.LastName = "Markham";
				c22.FirstName = "Elizabeth";
				c22.MiddleInitial = "P.";
				c22.Birthday = 26378;
				c22.Street = "8171 Commercial Crossing";
				c22.City = "Austin";
				c22.State = "TX";
				c22.ZipCode = 78712;
				c22.SSN = "116-38-6529";
				c22.EmailAddress = "cmartin@beets.com";
				c22.PhoneNumber = 2495200223;
				Customers.Add(c22);

				Customer c23 = new Customer();
				c23.CustomerID = 9032;
				c23.Password = "whocares";
				c23.LastName = "Martin";
				c23.FirstName = "Clarence";
				c23.MiddleInitial = "A";
				c23.Birthday = 33804;
				c23.Street = "96 Anthes Place";
				c23.City = "Schenectady";
				c23.State = "NY";
				c23.ZipCode = 12345;
				c23.SSN = "220-24-4049";
				c23.EmailAddress = "clarence@yoho.com";
				c23.PhoneNumber = 4086179161;
				Customers.Add(c23);

				Customer c24 = new Customer();
				c24.CustomerID = 9033;
				c24.Password = "xcellent";
				c24.LastName = "Martinez";
				c24.FirstName = "Gregory";
				c24.MiddleInitial = "R.";
				c24.Birthday = 17315;
				c24.Street = "10 Northridge Plaza";
				c24.City = "Austin";
				c24.State = "TX";
				c24.ZipCode = 78717;
				c24.SSN = "559-67-5740";
				c24.EmailAddress = "gregmartinez@drdre.com";
				c24.PhoneNumber = 9371927523;
				Customers.Add(c24);

				Customer c25 = new Customer();
				c25.CustomerID = 9034;
				c25.Password = "mydogspot";
				c25.LastName = "Miller";
				c25.FirstName = "Charles";
				c25.MiddleInitial = "R.";
				c25.Birthday = 33161;
				c25.Street = "87683 Schmedeman Circle";
				c25.City = "Austin";
				c25.State = "TX";
				c25.ZipCode = 78727;
				c25.SSN = "209-79-0473";
				c25.EmailAddress = "cmiller@bob.com";
				c25.PhoneNumber = 5954063857;
				Customers.Add(c25);

				Customer c26 = new Customer();
				c26.CustomerID = 9035;
				c26.Password = "spotmydog";
				c26.LastName = "Nelson";
				c26.FirstName = "Kelly";
				c26.MiddleInitial = "T";
				c26.Birthday = 26127;
				c26.Street = "3244 Ludington Court";
				c26.City = "Beaumont";
				c26.State = "TX";
				c26.ZipCode = 77720;
				c26.SSN = "227-64-1445";
				c26.EmailAddress = "knelson@aoll.com";
				c26.PhoneNumber = 8929209512;
				Customers.Add(c26);

				Customer c27 = new Customer();
				c27.CustomerID = 9036;
				c27.Password = "joejoejoe";
				c27.LastName = "Nguyen";
				c27.FirstName = "Joe";
				c27.MiddleInitial = "C";
				c27.Birthday = 30758;
				c27.Street = "4780 Talisman Court";
				c27.City = "San Marcos";
				c27.State = "TX";
				c27.ZipCode = 78667;
				c27.SSN = "480-18-2513";
				c27.EmailAddress = "joewin@xfactor.com";
				c27.PhoneNumber = 9226301774;
				Customers.Add(c27);

				Customer c28 = new Customer();
				c28.CustomerID = 9037;
				c28.Password = "billyboy";
				c28.LastName = "O'Reilly";
				c28.FirstName = "Bill";
				c28.MiddleInitial = "T";
				c28.Birthday = 21739;
				c28.Street = "4154 Delladonna Plaza";
				c28.City = "Bergheim";
				c28.State = "TX";
				c28.ZipCode = 78004;
				c28.SSN = "505-04-1746";
				c28.EmailAddress = "orielly@foxnews.cnn";
				c28.PhoneNumber = 2537646912;
				Customers.Add(c28);

				Customer c29 = new Customer();
				c29.CustomerID = 9038;
				c29.Password = "radgirl";
				c29.LastName = "Radkovich";
				c29.FirstName = "Anka";
				c29.MiddleInitial = "L";
				c29.Birthday = 24246;
				c29.Street = "72361 Bayside Drive";
				c29.City = "Austin";
				c29.State = "TX";
				c29.ZipCode = 78789;
				c29.SSN = "772-85-3188";
				c29.EmailAddress = "ankaisrad@gogle.com";
				c29.PhoneNumber = 2182889379;
				Customers.Add(c29);

				Customer c30 = new Customer();
				c30.CustomerID = 9039;
				c30.Password = "meganr34";
				c30.LastName = "Rhodes";
				c30.FirstName = "Megan";
				c30.MiddleInitial = "C.";
				c30.Birthday = 23813;
				c30.Street = "76875 Hoffman Point";
				c30.City = "Orlando";
				c30.State = "FL";
				c30.ZipCode = 32830;
				c30.SSN = "855-90-6552";
				c30.EmailAddress = "megrhodes@freserve.co.uk";
				c30.PhoneNumber = 9532396075;
				Customers.Add(c30);

				Customer c31 = new Customer();
				c31.CustomerID = 9040;
				c31.Password = "ricearoni";
				c31.LastName = "Rice";
				c31.FirstName = "Eryn";
				c31.MiddleInitial = "M.";
				c31.Birthday = 27512;
				c31.Street = "048 Elmside Park";
				c31.City = "South Padre Island";
				c31.State = "TX";
				c31.ZipCode = 78597;
				c31.SSN = "208-34-2385";
				c31.EmailAddress = "erynrice@aoll.com";
				c31.PhoneNumber = 7303815953;
				Customers.Add(c31);

				Customer c32 = new Customer();
				c32.CustomerID = 9041;
				c32.Password = "alaskaboy";
				c32.LastName = "Rodriguez";
				c32.FirstName = "Jorge";
				c32.MiddleInitial = "";
				c32.Birthday = 19701;
				c32.Street = "01 Browning Pass";
				c32.City = "Austin";
				c32.State = "TX";
				c32.ZipCode = 78744;
				c32.SSN = "391-71-4611";
				c32.EmailAddress = "jorge@noclue.com";
				c32.PhoneNumber = 3677322422;
				Customers.Add(c32);

				Customer c33 = new Customer();
				c33.CustomerID = 9042;
				c33.Password = "bunnyhop";
				c33.LastName = "Rogers";
				c33.FirstName = "Allen";
				c33.MiddleInitial = "B.";
				c33.Birthday = 26776;
				c33.Street = "844 Anderson Alley";
				c33.City = "Canyon Lake";
				c33.State = "TX";
				c33.ZipCode = 78133;
				c33.SSN = "308-74-1186";
				c33.EmailAddress = "mrrogers@lovelyday.com";
				c33.PhoneNumber = 3911705385;
				Customers.Add(c33);

				Customer c34 = new Customer();
				c34.CustomerID = 9043;
				c34.Password = "dustydusty";
				c34.LastName = "Saint-Jean";
				c34.FirstName = "Olivier";
				c34.MiddleInitial = "M";
				c34.Birthday = 34749;
				c34.Street = "1891 Docker Point";
				c34.City = "Austin";
				c34.State = "TX";
				c34.ZipCode = 78779;
				c34.SSN = "832-08-8657";
				c34.EmailAddress = "stjean@athome.com";
				c34.PhoneNumber = 7351610920;
				Customers.Add(c34);

				Customer c35 = new Customer();
				c35.CustomerID = 9044;
				c35.Password = "jrod2017";
				c35.LastName = "Saunders";
				c35.FirstName = "Sarah";
				c35.MiddleInitial = "J.";
				c35.Birthday = 28540;
				c35.Street = "1469 Upham Road";
				c35.City = "Austin";
				c35.State = "TX";
				c35.ZipCode = 78720;
				c35.SSN = "485-81-2960";
				c35.EmailAddress = "saunders@pen.com";
				c35.PhoneNumber = 5269661692;
				Customers.Add(c35);

				Customer c36 = new Customer();
				c36.CustomerID = 9045;
				c36.Password = "martin1234";
				c36.LastName = "Sewell";
				c36.FirstName = "William";
				c36.MiddleInitial = "T.";
				c36.Birthday = 38344;
				c36.Street = "1672 Oak Valley Circle";
				c36.City = "Austin";
				c36.State = "TX";
				c36.ZipCode = 78705;
				c36.SSN = "845-76-6886";
				c36.EmailAddress = "willsheff@email.com";
				c36.PhoneNumber = 1875727246;
				Customers.Add(c36);

				Customer c37 = new Customer();
				c37.CustomerID = 9046;
				c37.Password = "penguin12";
				c37.LastName = "Sheffield";
				c37.FirstName = "Martin";
				c37.MiddleInitial = "J.";
				c37.Birthday = 22044;
				c37.Street = "816 Kennedy Place";
				c37.City = "Round Rock";
				c37.State = "TX";
				c37.ZipCode = 78680;
				c37.SSN = "786-58-8427";
				c37.EmailAddress = "sheffiled@gogle.com";
				c37.PhoneNumber = 1394323615;
				Customers.Add(c37);

				Customer c38 = new Customer();
				c38.CustomerID = 9047;
				c38.Password = "rogerthat";
				c38.LastName = "Smith";
				c38.FirstName = "John";
				c38.MiddleInitial = "A";
				c38.Birthday = 20265;
				c38.Street = "0745 Golf Road";
				c38.City = "Austin";
				c38.State = "TX";
				c38.ZipCode = 78760;
				c38.SSN = "833-36-3857";
				c38.EmailAddress = "johnsmith187@aoll.com";
				c38.PhoneNumber = 6645937874;
				Customers.Add(c38);

				Customer c39 = new Customer();
				c39.CustomerID = 9048;
				c39.Password = "smitty444";
				c39.LastName = "Stroud";
				c39.FirstName = "Dustin";
				c39.MiddleInitial = "P";
				c39.Birthday = 24679;
				c39.Street = "505 Dexter Plaza";
				c39.City = "Sweet Home";
				c39.State = "TX";
				c39.ZipCode = 77987;
				c39.SSN = "862-95-5935";
				c39.EmailAddress = "dustroud@mail.com";
				c39.PhoneNumber = 6470254680;
				Customers.Add(c39);

				Customer c40 = new Customer();
				c40.CustomerID = 9049;
				c40.Password = "stewball";
				c40.LastName = "Stuart";
				c40.FirstName = "Eric";
				c40.MiddleInitial = "D.";
				c40.Birthday = 17505;
				c40.Street = "585 Claremont Drive";
				c40.City = "Corpus Christi";
				c40.State = "TX";
				c40.ZipCode = 78412;
				c40.SSN = "401-87-6781";
				c40.EmailAddress = "estuart@anchor.net";
				c40.PhoneNumber = 7701621022;
				Customers.Add(c40);

				Customer c41 = new Customer();
				c41.CustomerID = 9050;
				c41.Password = "slowwind";
				c41.LastName = "Stump";
				c41.FirstName = "Peter";
				c41.MiddleInitial = "L";
				c41.Birthday = 27220;
				c41.Street = "89035 Welch Circle";
				c41.City = "Pflugerville";
				c41.State = "TX";
				c41.ZipCode = 78660;
				c41.SSN = "414-55-9948";
				c41.EmailAddress = "peterstump@noclue.com";
				c41.PhoneNumber = 2181960061;
				Customers.Add(c41);

				Customer c42 = new Customer();
				c42.CustomerID = 9051;
				c42.Password = "tanner5454";
				c42.LastName = "Tanner";
				c42.FirstName = "Jeremy";
				c42.MiddleInitial = "S.";
				c42.Birthday = 16082;
				c42.Street = "4 Stang Trail";
				c42.City = "Austin";
				c42.State = "TX";
				c42.ZipCode = 78702;
				c42.SSN = "215-59-9614";
				c42.EmailAddress = "jtanner@mustang.net";
				c42.PhoneNumber = 9908469499;
				Customers.Add(c42);

				Customer c43 = new Customer();
				c43.CustomerID = 9052;
				c43.Password = "allyrally";
				c43.LastName = "Taylor";
				c43.FirstName = "Allison";
				c43.MiddleInitial = "R.";
				c43.Birthday = 33191;
				c43.Street = "726 Twin Pines Avenue";
				c43.City = "Austin";
				c43.State = "TX";
				c43.ZipCode = 78713;
				c43.SSN = "263-91-7172";
				c43.EmailAddress = "taylordjay@aoll.com";
				c43.PhoneNumber = 7011918647;
				Customers.Add(c43);

				Customer c44 = new Customer();
				c44.CustomerID = 9053;
				c44.Password = "taylorbaylor";
				c44.LastName = "Taylor";
				c44.FirstName = "Rachel";
				c44.MiddleInitial = "K.";
				c44.Birthday = 27777;
				c44.Street = "06605 Sugar Drive";
				c44.City = "Austin";
				c44.State = "TX";
				c44.ZipCode = 78712;
				c44.SSN = "774-06-1511";
				c44.EmailAddress = "rtaylor@gogle.com";
				c44.PhoneNumber = 8937910053;
				Customers.Add(c44);

				Customer c45 = new Customer();
				c45.CustomerID = 9054;
				c45.Password = "teeoff22";
				c45.LastName = "Tee";
				c45.FirstName = "Frank";
				c45.MiddleInitial = "J";
				c45.Birthday = 36044;
				c45.Street = "3567 Dawn Plaza";
				c45.City = "Austin";
				c45.State = "TX";
				c45.ZipCode = 78786;
				c45.SSN = "522-65-3064";
				c45.EmailAddress = "teefrank@noclue.com";
				c45.PhoneNumber = 6394568913;
				Customers.Add(c45);

				Customer c46 = new Customer();
				c46.CustomerID = 9055;
				c46.Password = "tucksack1";
				c46.LastName = "Tucker";
				c46.FirstName = "Clent";
				c46.MiddleInitial = "J";
				c46.Birthday = 15762;
				c46.Street = "704 Northland Alley";
				c46.City = "San Antonio";
				c46.State = "TX";
				c46.ZipCode = 78279;
				c46.SSN = "876-29-4912";
				c46.EmailAddress = "ctucker@alphabet.co.uk";
				c46.PhoneNumber = 2676838676;
				Customers.Add(c46);

				Customer c47 = new Customer();
				c47.CustomerID = 9056;
				c47.Password = "meow88";
				c47.LastName = "Velasco";
				c47.FirstName = "Allen";
				c47.MiddleInitial = "G";
				c47.Birthday = 31300;
				c47.Street = "72 Harbort Point";
				c47.City = "Navasota";
				c47.State = "TX";
				c47.ZipCode = 77868;
				c47.SSN = "216-67-9243";
				c47.EmailAddress = "avelasco@yoho.com";
				c47.PhoneNumber = 3452909754;
				Customers.Add(c47);

				Customer c48 = new Customer();
				c48.CustomerID = 9057;
				c48.Password = "vinovino";
				c48.LastName = "Vino";
				c48.FirstName = "Janet";
				c48.MiddleInitial = "E";
				c48.Birthday = 31085;
				c48.Street = "1 Oak Valley Place";
				c48.City = "Boston";
				c48.State = "MA";
				c48.ZipCode = 02114;
				c48.SSN = "565-57-4107";
				c48.EmailAddress = "vinovino@grapes.com";
				c48.PhoneNumber = 8567089194;
				Customers.Add(c48);

				Customer c49 = new Customer();
				c49.CustomerID = 9058;
				c49.Password = "gowest";
				c49.LastName = "West";
				c49.FirstName = "Jake";
				c49.MiddleInitial = "T";
				c49.Birthday = 27768;
				c49.Street = "48743 Banding Parkway";
				c49.City = "Marble Falls";
				c49.State = "TX";
				c49.ZipCode = 78654;
				c49.SSN = "390-37-6155";
				c49.EmailAddress = "westj@pioneer.net";
				c49.PhoneNumber = 6260784394;
				Customers.Add(c49);

				Customer c50 = new Customer();
				c50.CustomerID = 9059;
				c50.Password = "louielouie";
				c50.LastName = "Winthorpe";
				c50.FirstName = "Louis";
				c50.MiddleInitial = "L";
				c50.Birthday = 19468;
				c50.Street = "96850 Summit Crossing";
				c50.City = "Austin";
				c50.State = "TX";
				c50.ZipCode = 78730;
				c50.SSN = "445-77-2754";
				c50.EmailAddress = "winner@hootmail.com";
				c50.PhoneNumber = 3733971174;
				Customers.Add(c50);

				Customer c51 = new Customer();
				c51.CustomerID = 9060;
				c51.Password = "woodyman1";
				c51.LastName = "Wood";
				c51.FirstName = "Reagan";
				c51.MiddleInitial = "B.";
				c51.Birthday = 37618;
				c51.Street = "18354 Bluejay Street";
				c51.City = "Austin";
				c51.State = "TX";
				c51.ZipCode = 78712;
				c51.SSN = "805-38-7710";
				c51.EmailAddress = "rwood@voyager.net";
				c51.PhoneNumber = 8433359800;
				Customers.Add(c51);

				//loop through customers
				foreach (Customer cust in Customers)
				{
					//set name of customer to help debug
					customerID = customer.CustomerID;

					//see if customer exists in database
					Customer dbCustomer = db.Customers.FirstOrDefault(c => c.CustomerID == customer.CustomerID);

					if (dbCustomer == null) //customer does not exist in database
					{
						db.Customers.Add(customer);
						db.SaveChanges();
						intCustomersAdded += 1;
					}
					else
					{
						dbCustomer.LastName = customer.LastName;
						dbCustomer.CustomerID = customer.CustomerID;
						dbCustomer.FirstName = customer.FirstName;
						dbCustomer.MiddleInitial = customer.MiddleInitial;
						dbCustomer.Birthday = customer.Birthday;
						dbCustomer.Street = customer.Street;
						dbCustomer.City = customer.City;
						dbCustomer.State = customer.State;
						dbCustomer.ZipCode = customer.ZipCode;
						dbCustomer.SSN = customer.SSN;
						dbCustomer.EmailAddress = customer.EmailAddress;
						dbCustomer.PhoneNumber = customer.PhoneNumber;
						db.Update(dbCustomer);
						db.SaveChanges();
					}
				}
			}
			catch
			{
				String msg = "Customers added:" + intCustomersAdded + "; Error on " + customerName;
				throw new InvalidOperationException(msg);
			}
		}
	}
}*/
