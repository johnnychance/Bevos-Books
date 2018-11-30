using fa18Team28_FinalProject.Models;
using fa18Team28_FinalProject.DAL;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace fa18Team28_FinalProject.Seeding
{
    public static class SeedCustomers
    {
        public static async Task AddAdmin(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (await _roleManager.RoleExistsAsync("Customer") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            AppUser c1 = _db.Users.FirstOrDefault(u => u.Email == "cbaker@example.com");
			if ( c1 == null)
			{
				c1 = new AppUser();
				c1.CustomerNumber = "9010";
				c1.LastName = "Baker";
				c1.FirstName = "Christopher";
				c1.MiddleInitial = "L.";
				c1.Birthday = "18225";
				c1.StreetAddress = "1898 Schurz Alley";
				c1.City = "Austin";
				c1.State = "TX";
				c1.Zipcode = "78705";
				c1.SSN = "477-44-9589";
				c1.Email = "cbaker@example.com";
				c1.PhoneNumber = "5725458641";
				c1.UserName = "cbaker@example.com";

				var result = await _userManager.CreateAsync(c1, "bookworm");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c1 = _db.Users.FirstOrDefault(u => u.UserName == "cbaker@example.com");
			}
			 if (await _userManager.IsInRoleAsync(c1, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c1, "Customer");
			}
			_db.SaveChanges();

			AppUser c2 = _db.Users.FirstOrDefault(u => u.Email == "banker@longhorn.net");
			if ( c2 == null)
			{
				c2 = new AppUser();
				c2.CustomerNumber = "9011";
				c2.LastName = "Banks";
				c2.FirstName = "Michelle";
				c2.MiddleInitial = "";
				c2.Birthday = "22977";
				c2.StreetAddress = "97 Elmside Pass";
				c2.City = "Austin";
				c2.State = "TX";
				c2.Zipcode = "78712";
				c2.SSN = "247-31-0787";
				c2.Email = "banker@longhorn.net";
				c2.PhoneNumber = "9867048435";
				c2.UserName = "banker@longhorn.net";

				var result = await _userManager.CreateAsync(c2, "potato");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c2 = _db.Users.FirstOrDefault(u => u.UserName == "banker@longhorn.net");
			}
			 if (await _userManager.IsInRoleAsync(c2, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c2, "Customer");
			}
			_db.SaveChanges();

			AppUser c3 = _db.Users.FirstOrDefault(u => u.Email == "franco@example.com");
			if ( c3 == null)
			{
				c3 = new AppUser();
				c3.CustomerNumber = "9012";
				c3.LastName = "Broccolo";
				c3.FirstName = "Franco";
				c3.MiddleInitial = "V";
				c3.Birthday = "33888";
				c3.StreetAddress = "88 Crowley Circle";
				c3.City = "Austin";
				c3.State = "TX";
				c3.Zipcode = "78786";
				c3.SSN = "486-47-8748";
				c3.Email = "franco@example.com";
				c3.PhoneNumber = "6836109514";
				c3.UserName = "franco@example.com";

				var result = await _userManager.CreateAsync(c3, "painting");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c3 = _db.Users.FirstOrDefault(u => u.UserName == "franco@example.com");
			}
			 if (await _userManager.IsInRoleAsync(c3, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c3, "Customer");
			}
			_db.SaveChanges();

			AppUser c4 = _db.Users.FirstOrDefault(u => u.Email == "wchang@example.com");
			if ( c4 == null)
			{
				c4 = new AppUser();
				c4.CustomerNumber = "9013";
				c4.LastName = "Chang";
				c4.FirstName = "Wendy";
				c4.MiddleInitial = "L";
				c4.Birthday = "35566";
				c4.StreetAddress = "56560 Sage Junction";
				c4.City = "Eagle Pass";
				c4.State = "TX";
				c4.Zipcode = "78852";
				c4.SSN = "182-52-9193";
				c4.Email = "wchang@example.com";
				c4.PhoneNumber = "7070911071";
				c4.UserName = "wchang@example.com";

				var result = await _userManager.CreateAsync(c4, "texas1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c4 = _db.Users.FirstOrDefault(u => u.UserName == "wchang@example.com");
			}
			 if (await _userManager.IsInRoleAsync(c4, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c4, "Customer");
			}
			_db.SaveChanges();

			AppUser c5 = _db.Users.FirstOrDefault(u => u.Email == "limchou@gogle.com");
			if ( c5 == null)
			{
				c5 = new AppUser();
				c5.CustomerNumber = "9014";
				c5.LastName = "Chou";
				c5.FirstName = "Lim";
				c5.MiddleInitial = "";
				c5.Birthday = "25664";
				c5.StreetAddress = "60 Lunder Point";
				c5.City = "Austin";
				c5.State = "TX";
				c5.Zipcode = "78729";
				c5.SSN = "679-75-0653";
				c5.Email = "limchou@gogle.com";
				c5.PhoneNumber = "1488907687";
				c5.UserName = "limchou@gogle.com";

				var result = await _userManager.CreateAsync(c5, "Anchorage");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c5 = _db.Users.FirstOrDefault(u => u.UserName == "limchou@gogle.com");
			}
			 if (await _userManager.IsInRoleAsync(c5, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c5, "Customer");
			}
			_db.SaveChanges();

			AppUser c6 = _db.Users.FirstOrDefault(u => u.Email == "shdixon@aoll.com");
			if ( c6 == null)
			{
				c6 = new AppUser();
				c6.CustomerNumber = "9015";
				c6.LastName = "Dixon";
				c6.FirstName = "Shan";
				c6.MiddleInitial = "D";
				c6.Birthday = "30693";
				c6.StreetAddress = "9448 Pleasure Avenue";
				c6.City = "Georgetown";
				c6.State = "TX";
				c6.Zipcode = "78628";
				c6.SSN = "593-06-9800";
				c6.Email = "shdixon@aoll.com";
				c6.PhoneNumber = "6899701824";
				c6.UserName = "shdixon@aoll.com";

				var result = await _userManager.CreateAsync(c6, "aggies");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c6 = _db.Users.FirstOrDefault(u => u.UserName == "shdixon@aoll.com");
			}
			 if (await _userManager.IsInRoleAsync(c6, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c6, "Customer");
			}
			_db.SaveChanges();

			AppUser c7 = _db.Users.FirstOrDefault(u => u.Email == "j.b.evans@aheca.org");
			if ( c7 == null)
			{
				c7 = new AppUser();
				c7.CustomerNumber = "9016";
				c7.LastName = "Evans";
				c7.FirstName = "Jim Bob";
				c7.MiddleInitial = "";
				c7.Birthday = "21802";
				c7.StreetAddress = "51 Emmet Parkway";
				c7.City = "Austin";
				c7.State = "TX";
				c7.Zipcode = "78705";
				c7.SSN = "647-72-4711";
				c7.Email = "j.b.evans@aheca.org";
				c7.PhoneNumber = "9986825917";
				c7.UserName = "j.b.evans@aheca.org";

				var result = await _userManager.CreateAsync(c7, "hampton1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c7 = _db.Users.FirstOrDefault(u => u.UserName == "j.b.evans@aheca.org");
			}
			 if (await _userManager.IsInRoleAsync(c7, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c7, "Customer");
			}
			_db.SaveChanges();

			AppUser c8 = _db.Users.FirstOrDefault(u => u.Email == "feeley@penguin.org");
			if ( c8 == null)
			{
				c8 = new AppUser();
				c8.CustomerNumber = "9017";
				c8.LastName = "Feeley";
				c8.FirstName = "Lou Ann";
				c8.MiddleInitial = "K";
				c8.Birthday = "36903";
				c8.StreetAddress = "65 Darwin Crossing";
				c8.City = "Austin";
				c8.State = "TX";
				c8.Zipcode = "78704";
				c8.SSN = "577-89-2279";
				c8.Email = "feeley@penguin.org";
				c8.PhoneNumber = "3464121966";
				c8.UserName = "feeley@penguin.org";

				var result = await _userManager.CreateAsync(c8, "longhorns");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c8 = _db.Users.FirstOrDefault(u => u.UserName == "feeley@penguin.org");
			}
			 if (await _userManager.IsInRoleAsync(c8, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c8, "Customer");
			}
			_db.SaveChanges();

			AppUser c9 = _db.Users.FirstOrDefault(u => u.Email == "tfreeley@minnetonka.ci.us");
			if ( c9 == null)
			{
				c9 = new AppUser();
				c9.CustomerNumber = "9018";
				c9.LastName = "Freeley";
				c9.FirstName = "Tesa";
				c9.MiddleInitial = "P";
				c9.Birthday = "33273";
				c9.StreetAddress = "7352 Loftsgordon Court";
				c9.City = "College Station";
				c9.State = "TX";
				c9.Zipcode = "77840";
				c9.SSN = "853-72-9538";
				c9.Email = "tfreeley@minnetonka.ci.us";
				c9.PhoneNumber = "6581357270";
				c9.UserName = "tfreeley@minnetonka.ci.us";

				var result = await _userManager.CreateAsync(c9, "mustangs");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c9 = _db.Users.FirstOrDefault(u => u.UserName == "tfreeley@minnetonka.ci.us");
			}
			 if (await _userManager.IsInRoleAsync(c9, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c9, "Customer");
			}
			_db.SaveChanges();

			AppUser c10 = _db.Users.FirstOrDefault(u => u.Email == "mgarcia@gogle.com");
			if ( c10 == null)
			{
				c10 = new AppUser();
				c10.CustomerNumber = "9019";
				c10.LastName = "Garcia";
				c10.FirstName = "Margaret";
				c10.MiddleInitial = "L";
				c10.Birthday = "33513";
				c10.StreetAddress = "7 International Road";
				c10.City = "Austin";
				c10.State = "TX";
				c10.Zipcode = "78756";
				c10.SSN = "887-12-0229";
				c10.Email = "mgarcia@gogle.com";
				c10.PhoneNumber = "3767347949";
				c10.UserName = "mgarcia@gogle.com";

				var result = await _userManager.CreateAsync(c10, "onetime");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c10 = _db.Users.FirstOrDefault(u => u.UserName == "mgarcia@gogle.com");
			}
			 if (await _userManager.IsInRoleAsync(c10, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c10, "Customer");
			}
			_db.SaveChanges();

			AppUser c11 = _db.Users.FirstOrDefault(u => u.Email == "chaley@thug.com");
			if ( c11 == null)
			{
				c11 = new AppUser();
				c11.CustomerNumber = "9020";
				c11.LastName = "Haley";
				c11.FirstName = "Charles";
				c11.MiddleInitial = "E";
				c11.Birthday = "27220";
				c11.StreetAddress = "8 Warrior Trail";
				c11.City = "Austin";
				c11.State = "TX";
				c11.Zipcode = "78746";
				c11.SSN = "528-58-6911";
				c11.Email = "chaley@thug.com";
				c11.PhoneNumber = "2198604221";
				c11.UserName = "chaley@thug.com";

				var result = await _userManager.CreateAsync(c11, "pepperoni");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c11 = _db.Users.FirstOrDefault(u => u.UserName == "chaley@thug.com");
			}
			 if (await _userManager.IsInRoleAsync(c11, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c11, "Customer");
			}
			_db.SaveChanges();

			AppUser c12 = _db.Users.FirstOrDefault(u => u.Email == "jeffh@sonic.com");
			if ( c12 == null)
			{
				c12 = new AppUser();
				c12.CustomerNumber = "9021";
				c12.LastName = "Hampton";
				c12.FirstName = "Jeffrey";
				c12.MiddleInitial = "T.";
				c12.Birthday = "38056";
				c12.StreetAddress = "9107 Lighthouse Bay Road";
				c12.City = "Austin";
				c12.State = "TX";
				c12.Zipcode = "78756";
				c12.SSN = "658-45-9102";
				c12.Email = "jeffh@sonic.com";
				c12.PhoneNumber = "1222185888";
				c12.UserName = "jeffh@sonic.com";

				var result = await _userManager.CreateAsync(c12, "raiders");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c12 = _db.Users.FirstOrDefault(u => u.UserName == "jeffh@sonic.com");
			}
			 if (await _userManager.IsInRoleAsync(c12, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c12, "Customer");
			}
			_db.SaveChanges();

			AppUser c13 = _db.Users.FirstOrDefault(u => u.Email == "wjhearniii@umich.org");
			if ( c13 == null)
			{
				c13 = new AppUser();
				c13.CustomerNumber = "9022";
				c13.LastName = "Hearn";
				c13.FirstName = "John";
				c13.MiddleInitial = "B";
				c13.Birthday = "18480";
				c13.StreetAddress = "59784 Pierstorff Center";
				c13.City = "Liberty";
				c13.State = "TX";
				c13.Zipcode = "77575";
				c13.SSN = "712-69-1666";
				c13.Email = "wjhearniii@umich.org";
				c13.PhoneNumber = "5123071976";
				c13.UserName = "wjhearniii@umich.org";

				var result = await _userManager.CreateAsync(c13, "jhearn22");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c13 = _db.Users.FirstOrDefault(u => u.UserName == "wjhearniii@umich.org");
			}
			 if (await _userManager.IsInRoleAsync(c13, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c13, "Customer");
			}
			_db.SaveChanges();

			AppUser c14 = _db.Users.FirstOrDefault(u => u.Email == "ahick@yaho.com");
			if ( c14 == null)
			{
				c14 = new AppUser();
				c14.CustomerNumber = "9023";
				c14.LastName = "Hicks";
				c14.FirstName = "Anthony";
				c14.MiddleInitial = "J";
				c14.Birthday = "38329";
				c14.StreetAddress = "932 Monica Way";
				c14.City = "San Antonio";
				c14.State = "TX";
				c14.Zipcode = "78203";
				c14.SSN = "179-94-2233";
				c14.Email = "ahick@yaho.com";
				c14.PhoneNumber = "1211949601";
				c14.UserName = "ahick@yaho.com";

				var result = await _userManager.CreateAsync(c14, "hickhickup");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c14 = _db.Users.FirstOrDefault(u => u.UserName == "ahick@yaho.com");
			}
			 if (await _userManager.IsInRoleAsync(c14, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c14, "Customer");
			}
			_db.SaveChanges();

			AppUser c15 = _db.Users.FirstOrDefault(u => u.Email == "ingram@jack.com");
			if ( c15 == null)
			{
				c15 = new AppUser();
				c15.CustomerNumber = "9024";
				c15.LastName = "Ingram";
				c15.FirstName = "Brad";
				c15.MiddleInitial = "S.";
				c15.Birthday = "37139";
				c15.StreetAddress = "4 Lukken Court";
				c15.City = "New Braunfels";
				c15.State = "TX";
				c15.Zipcode = "78132";
				c15.SSN = "126-14-4287";
				c15.Email = "ingram@jack.com";
				c15.PhoneNumber = "1372121569";
				c15.UserName = "ingram@jack.com";

				var result = await _userManager.CreateAsync(c15, "ingram2015");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c15 = _db.Users.FirstOrDefault(u => u.UserName == "ingram@jack.com");
			}
			 if (await _userManager.IsInRoleAsync(c15, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c15, "Customer");
			}
			_db.SaveChanges();

			AppUser c16 = _db.Users.FirstOrDefault(u => u.Email == "toddj@yourmom.com");
			if ( c16 == null)
			{
				c16 = new AppUser();
				c16.CustomerNumber = "9025";
				c16.LastName = "Jacobs";
				c16.FirstName = "Todd";
				c16.MiddleInitial = "L.";
				c16.Birthday = "36180";
				c16.StreetAddress = "7 Susan Junction";
				c16.City = "New York";
				c16.State = "NY";
				c16.Zipcode = "10101";
				c16.SSN = "355-61-0890";
				c16.Email = "toddj@yourmom.com";
				c16.PhoneNumber = "8543163836";
				c16.UserName = "toddj@yourmom.com";

				var result = await _userManager.CreateAsync(c16, "toddy25");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c16 = _db.Users.FirstOrDefault(u => u.UserName == "toddj@yourmom.com");
			}
			 if (await _userManager.IsInRoleAsync(c16, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c16, "Customer");
			}
			_db.SaveChanges();

			AppUser c17 = _db.Users.FirstOrDefault(u => u.Email == "thequeen@aska.net");
			if ( c17 == null)
			{
				c17 = new AppUser();
				c17.CustomerNumber = "9026";
				c17.LastName = "Lawrence";
				c17.FirstName = "Victoria";
				c17.MiddleInitial = "M.";
				c17.Birthday = "36630";
				c17.StreetAddress = "669 Oak Junction";
				c17.City = "Lockhart";
				c17.State = "TX";
				c17.Zipcode = "78644";
				c17.SSN = "840-91-4997";
				c17.Email = "thequeen@aska.net";
				c17.PhoneNumber = "3214163359";
				c17.UserName = "thequeen@aska.net";

				var result = await _userManager.CreateAsync(c17, "something");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c17 = _db.Users.FirstOrDefault(u => u.UserName == "thequeen@aska.net");
			}
			 if (await _userManager.IsInRoleAsync(c17, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c17, "Customer");
			}
			_db.SaveChanges();

			AppUser c18 = _db.Users.FirstOrDefault(u => u.Email == "linebacker@gogle.com");
			if ( c18 == null)
			{
				c18 = new AppUser();
				c18.CustomerNumber = "9027";
				c18.LastName = "Lineback";
				c18.FirstName = "Erik";
				c18.MiddleInitial = "W";
				c18.Birthday = "37957";
				c18.StreetAddress = "099 Luster Point";
				c18.City = "Kingwood";
				c18.State = "TX";
				c18.Zipcode = "77325";
				c18.SSN = "303-25-5592";
				c18.Email = "linebacker@gogle.com";
				c18.PhoneNumber = "2505265350";
				c18.UserName = "linebacker@gogle.com";

				var result = await _userManager.CreateAsync(c18, "Password1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c18 = _db.Users.FirstOrDefault(u => u.UserName == "linebacker@gogle.com");
			}
			 if (await _userManager.IsInRoleAsync(c18, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c18, "Customer");
			}
			_db.SaveChanges();

			AppUser c19 = _db.Users.FirstOrDefault(u => u.Email == "elowe@netscare.net");
			if ( c19 == null)
			{
				c19 = new AppUser();
				c19.CustomerNumber = "9028";
				c19.LastName = "Lowe";
				c19.FirstName = "Ernest";
				c19.MiddleInitial = "S";
				c19.Birthday = "28466";
				c19.StreetAddress = "35473 Hansons Hill";
				c19.City = "Beverly Hills";
				c19.State = "CA";
				c19.Zipcode = "90210";
				c19.SSN = "547-72-1592";
				c19.Email = "elowe@netscare.net";
				c19.PhoneNumber = "4070619503";
				c19.UserName = "elowe@netscare.net";

				var result = await _userManager.CreateAsync(c19, "aclfest2017");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c19 = _db.Users.FirstOrDefault(u => u.UserName == "elowe@netscare.net");
			}
			 if (await _userManager.IsInRoleAsync(c19, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c19, "Customer");
			}
			_db.SaveChanges();

			AppUser c20 = _db.Users.FirstOrDefault(u => u.Email == "cluce@gogle.com");
			if ( c20 == null)
			{
				c20 = new AppUser();
				c20.CustomerNumber = "9029";
				c20.LastName = "Luce";
				c20.FirstName = "Chuck";
				c20.MiddleInitial = "B";
				c20.Birthday = "17973";
				c20.StreetAddress = "4 Emmet Junction";
				c20.City = "Navasota";
				c20.State = "TX";
				c20.Zipcode = "77868";
				c20.SSN = "434-46-8800";
				c20.Email = "cluce@gogle.com";
				c20.PhoneNumber = "7358436110";
				c20.UserName = "cluce@gogle.com";

				var result = await _userManager.CreateAsync(c20, "nothinggood");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c20 = _db.Users.FirstOrDefault(u => u.UserName == "cluce@gogle.com");
			}
			 if (await _userManager.IsInRoleAsync(c20, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c20, "Customer");
			}
			_db.SaveChanges();

			AppUser c21 = _db.Users.FirstOrDefault(u => u.Email == "mackcloud@george.com");
			if ( c21 == null)
			{
				c21 = new AppUser();
				c21.CustomerNumber = "9030";
				c21.LastName = "MacLeod";
				c21.FirstName = "Jennifer";
				c21.MiddleInitial = "D.";
				c21.Birthday = "17219";
				c21.StreetAddress = "3 Orin Road";
				c21.City = "Austin";
				c21.State = "TX";
				c21.Zipcode = "78712";
				c21.SSN = "219-58-3683";
				c21.Email = "mackcloud@george.com";
				c21.PhoneNumber = "7240178229";
				c21.UserName = "mackcloud@george.com";

				var result = await _userManager.CreateAsync(c21, "whatever");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c21 = _db.Users.FirstOrDefault(u => u.UserName == "mackcloud@george.com");
			}
			 if (await _userManager.IsInRoleAsync(c21, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c21, "Customer");
			}
			_db.SaveChanges();

			AppUser c22 = _db.Users.FirstOrDefault(u => u.Email == "cmartin@beets.com");
			if ( c22 == null)
			{
				c22 = new AppUser();
				c22.CustomerNumber = "9031";
				c22.LastName = "Markham";
				c22.FirstName = "Elizabeth";
				c22.MiddleInitial = "P.";
				c22.Birthday = "26378";
				c22.StreetAddress = "8171 Commercial Crossing";
				c22.City = "Austin";
				c22.State = "TX";
				c22.Zipcode = "78712";
				c22.SSN = "116-38-6529";
				c22.Email = "cmartin@beets.com";
				c22.PhoneNumber = "2495200223";
				c22.UserName = "cmartin@beets.com";

				var result = await _userManager.CreateAsync(c22, "snowsnow");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c22 = _db.Users.FirstOrDefault(u => u.UserName == "cmartin@beets.com");
			}
			 if (await _userManager.IsInRoleAsync(c22, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c22, "Customer");
			}
			_db.SaveChanges();

			AppUser c23 = _db.Users.FirstOrDefault(u => u.Email == "clarence@yoho.com");
			if ( c23 == null)
			{
				c23 = new AppUser();
				c23.CustomerNumber = "9032";
				c23.LastName = "Martin";
				c23.FirstName = "Clarence";
				c23.MiddleInitial = "A";
				c23.Birthday = "33804";
				c23.StreetAddress = "96 Anthes Place";
				c23.City = "Schenectady";
				c23.State = "NY";
				c23.Zipcode = "12345";
				c23.SSN = "220-24-4049";
				c23.Email = "clarence@yoho.com";
				c23.PhoneNumber = "4086179161";
				c23.UserName = "clarence@yoho.com";

				var result = await _userManager.CreateAsync(c23, "whocares");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c23 = _db.Users.FirstOrDefault(u => u.UserName == "clarence@yoho.com");
			}
			 if (await _userManager.IsInRoleAsync(c23, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c23, "Customer");
			}
			_db.SaveChanges();

			AppUser c24 = _db.Users.FirstOrDefault(u => u.Email == "gregmartinez@drdre.com");
			if ( c24 == null)
			{
				c24 = new AppUser();
				c24.CustomerNumber = "9033";
				c24.LastName = "Martinez";
				c24.FirstName = "Gregory";
				c24.MiddleInitial = "R.";
				c24.Birthday = "17315";
				c24.StreetAddress = "10 Northridge Plaza";
				c24.City = "Austin";
				c24.State = "TX";
				c24.Zipcode = "78717";
				c24.SSN = "559-67-5740";
				c24.Email = "gregmartinez@drdre.com";
				c24.PhoneNumber = "9371927523";
				c24.UserName = "gregmartinez@drdre.com";

				var result = await _userManager.CreateAsync(c24, "xcellent");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c24 = _db.Users.FirstOrDefault(u => u.UserName == "gregmartinez@drdre.com");
			}
			 if (await _userManager.IsInRoleAsync(c24, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c24, "Customer");
			}
			_db.SaveChanges();

			AppUser c25 = _db.Users.FirstOrDefault(u => u.Email == "cmiller@bob.com");
			if ( c25 == null)
			{
				c25 = new AppUser();
				c25.CustomerNumber = "9034";
				c25.LastName = "Miller";
				c25.FirstName = "Charles";
				c25.MiddleInitial = "R.";
				c25.Birthday = "33161";
				c25.StreetAddress = "87683 Schmedeman Circle";
				c25.City = "Austin";
				c25.State = "TX";
				c25.Zipcode = "78727";
				c25.SSN = "209-79-0473";
				c25.Email = "cmiller@bob.com";
				c25.PhoneNumber = "5954063857";
				c25.UserName = "cmiller@bob.com";

				var result = await _userManager.CreateAsync(c25, "mydogspot");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c25 = _db.Users.FirstOrDefault(u => u.UserName == "cmiller@bob.com");
			}
			 if (await _userManager.IsInRoleAsync(c25, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c25, "Customer");
			}
			_db.SaveChanges();

			AppUser c26 = _db.Users.FirstOrDefault(u => u.Email == "knelson@aoll.com");
			if ( c26 == null)
			{
				c26 = new AppUser();
				c26.CustomerNumber = "9035";
				c26.LastName = "Nelson";
				c26.FirstName = "Kelly";
				c26.MiddleInitial = "T";
				c26.Birthday = "26127";
				c26.StreetAddress = "3244 Ludington Court";
				c26.City = "Beaumont";
				c26.State = "TX";
				c26.Zipcode = "77720";
				c26.SSN = "227-64-1445";
				c26.Email = "knelson@aoll.com";
				c26.PhoneNumber = "8929209512";
				c26.UserName = "knelson@aoll.com";

				var result = await _userManager.CreateAsync(c26, "spotmydog");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c26 = _db.Users.FirstOrDefault(u => u.UserName == "knelson@aoll.com");
			}
			 if (await _userManager.IsInRoleAsync(c26, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c26, "Customer");
			}
			_db.SaveChanges();

			AppUser c27 = _db.Users.FirstOrDefault(u => u.Email == "joewin@xfactor.com");
			if ( c27 == null)
			{
				c27 = new AppUser();
				c27.CustomerNumber = "9036";
				c27.LastName = "Nguyen";
				c27.FirstName = "Joe";
				c27.MiddleInitial = "C";
				c27.Birthday = "30758";
				c27.StreetAddress = "4780 Talisman Court";
				c27.City = "San Marcos";
				c27.State = "TX";
				c27.Zipcode = "78667";
				c27.SSN = "480-18-2513";
				c27.Email = "joewin@xfactor.com";
				c27.PhoneNumber = "9226301774";
				c27.UserName = "joewin@xfactor.com";

				var result = await _userManager.CreateAsync(c27, "joejoejoe");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c27 = _db.Users.FirstOrDefault(u => u.UserName == "joewin@xfactor.com");
			}
			 if (await _userManager.IsInRoleAsync(c27, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c27, "Customer");
			}
			_db.SaveChanges();

			AppUser c28 = _db.Users.FirstOrDefault(u => u.Email == "orielly@foxnews.cnn");
			if ( c28 == null)
			{
				c28 = new AppUser();
				c28.CustomerNumber = "9037";
				c28.LastName = "O'Reilly";
				c28.FirstName = "Bill";
				c28.MiddleInitial = "T";
				c28.Birthday = "21739";
				c28.StreetAddress = "4154 Delladonna Plaza";
				c28.City = "Bergheim";
				c28.State = "TX";
				c28.Zipcode = "78004";
				c28.SSN = "505-04-1746";
				c28.Email = "orielly@foxnews.cnn";
				c28.PhoneNumber = "2537646912";
				c28.UserName = "orielly@foxnews.cnn";

				var result = await _userManager.CreateAsync(c28, "billyboy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c28 = _db.Users.FirstOrDefault(u => u.UserName == "orielly@foxnews.cnn");
			}
			 if (await _userManager.IsInRoleAsync(c28, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c28, "Customer");
			}
			_db.SaveChanges();

			AppUser c29 = _db.Users.FirstOrDefault(u => u.Email == "ankaisrad@gogle.com");
			if ( c29 == null)
			{
				c29 = new AppUser();
				c29.CustomerNumber = "9038";
				c29.LastName = "Radkovich";
				c29.FirstName = "Anka";
				c29.MiddleInitial = "L";
				c29.Birthday = "24246";
				c29.StreetAddress = "72361 Bayside Drive";
				c29.City = "Austin";
				c29.State = "TX";
				c29.Zipcode = "78789";
				c29.SSN = "772-85-3188";
				c29.Email = "ankaisrad@gogle.com";
				c29.PhoneNumber = "2182889379";
				c29.UserName = "ankaisrad@gogle.com";

				var result = await _userManager.CreateAsync(c29, "radgirl");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c29 = _db.Users.FirstOrDefault(u => u.UserName == "ankaisrad@gogle.com");
			}
			 if (await _userManager.IsInRoleAsync(c29, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c29, "Customer");
			}
			_db.SaveChanges();

			AppUser c30 = _db.Users.FirstOrDefault(u => u.Email == "megrhodes@freserve.co.uk");
			if ( c30 == null)
			{
				c30 = new AppUser();
				c30.CustomerNumber = "9039";
				c30.LastName = "Rhodes";
				c30.FirstName = "Megan";
				c30.MiddleInitial = "C.";
				c30.Birthday = "23813";
				c30.StreetAddress = "76875 Hoffman Point";
				c30.City = "Orlando";
				c30.State = "FL";
				c30.Zipcode = "32830";
				c30.SSN = "855-90-6552";
				c30.Email = "megrhodes@freserve.co.uk";
				c30.PhoneNumber = "9532396075";
				c30.UserName = "megrhodes@freserve.co.uk";

				var result = await _userManager.CreateAsync(c30, "meganr34");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c30 = _db.Users.FirstOrDefault(u => u.UserName == "megrhodes@freserve.co.uk");
			}
			 if (await _userManager.IsInRoleAsync(c30, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c30, "Customer");
			}
			_db.SaveChanges();

			AppUser c31 = _db.Users.FirstOrDefault(u => u.Email == "erynrice@aoll.com");
			if ( c31 == null)
			{
				c31 = new AppUser();
				c31.CustomerNumber = "9040";
				c31.LastName = "Rice";
				c31.FirstName = "Eryn";
				c31.MiddleInitial = "M.";
				c31.Birthday = "27512";
				c31.StreetAddress = "048 Elmside Park";
				c31.City = "South Padre Island";
				c31.State = "TX";
				c31.Zipcode = "78597";
				c31.SSN = "208-34-2385";
				c31.Email = "erynrice@aoll.com";
				c31.PhoneNumber = "7303815953";
				c31.UserName = "erynrice@aoll.com";

				var result = await _userManager.CreateAsync(c31, "ricearoni");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c31 = _db.Users.FirstOrDefault(u => u.UserName == "erynrice@aoll.com");
			}
			 if (await _userManager.IsInRoleAsync(c31, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c31, "Customer");
			}
			_db.SaveChanges();

			AppUser c32 = _db.Users.FirstOrDefault(u => u.Email == "jorge@noclue.com");
			if ( c32 == null)
			{
				c32 = new AppUser();
				c32.CustomerNumber = "9041";
				c32.LastName = "Rodriguez";
				c32.FirstName = "Jorge";
				c32.MiddleInitial = "";
				c32.Birthday = "19701";
				c32.StreetAddress = "01 Browning Pass";
				c32.City = "Austin";
				c32.State = "TX";
				c32.Zipcode = "78744";
				c32.SSN = "391-71-4611";
				c32.Email = "jorge@noclue.com";
				c32.PhoneNumber = "3677322422";
				c32.UserName = "jorge@noclue.com";

				var result = await _userManager.CreateAsync(c32, "alaskaboy");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c32 = _db.Users.FirstOrDefault(u => u.UserName == "jorge@noclue.com");
			}
			 if (await _userManager.IsInRoleAsync(c32, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c32, "Customer");
			}
			_db.SaveChanges();

			AppUser c33 = _db.Users.FirstOrDefault(u => u.Email == "mrrogers@lovelyday.com");
			if ( c33 == null)
			{
				c33 = new AppUser();
				c33.CustomerNumber = "9042";
				c33.LastName = "Rogers";
				c33.FirstName = "Allen";
				c33.MiddleInitial = "B.";
				c33.Birthday = "26776";
				c33.StreetAddress = "844 Anderson Alley";
				c33.City = "Canyon Lake";
				c33.State = "TX";
				c33.Zipcode = "78133";
				c33.SSN = "308-74-1186";
				c33.Email = "mrrogers@lovelyday.com";
				c33.PhoneNumber = "3911705385";
				c33.UserName = "mrrogers@lovelyday.com";

				var result = await _userManager.CreateAsync(c33, "bunnyhop");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c33 = _db.Users.FirstOrDefault(u => u.UserName == "mrrogers@lovelyday.com");
			}
			 if (await _userManager.IsInRoleAsync(c33, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c33, "Customer");
			}
			_db.SaveChanges();

			AppUser c34 = _db.Users.FirstOrDefault(u => u.Email == "stjean@athome.com");
			if ( c34 == null)
			{
				c34 = new AppUser();
				c34.CustomerNumber = "9043";
				c34.LastName = "Saint-Jean";
				c34.FirstName = "Olivier";
				c34.MiddleInitial = "M";
				c34.Birthday = "34749";
				c34.StreetAddress = "1891 Docker Point";
				c34.City = "Austin";
				c34.State = "TX";
				c34.Zipcode = "78779";
				c34.SSN = "832-08-8657";
				c34.Email = "stjean@athome.com";
				c34.PhoneNumber = "7351610920";
				c34.UserName = "stjean@athome.com";

				var result = await _userManager.CreateAsync(c34, "dustydusty");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c34 = _db.Users.FirstOrDefault(u => u.UserName == "stjean@athome.com");
			}
			 if (await _userManager.IsInRoleAsync(c34, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c34, "Customer");
			}
			_db.SaveChanges();

			AppUser c35 = _db.Users.FirstOrDefault(u => u.Email == "saunders@pen.com");
			if ( c35 == null)
			{
				c35 = new AppUser();
				c35.CustomerNumber = "9044";
				c35.LastName = "Saunders";
				c35.FirstName = "Sarah";
				c35.MiddleInitial = "J.";
				c35.Birthday = "28540";
				c35.StreetAddress = "1469 Upham Road";
				c35.City = "Austin";
				c35.State = "TX";
				c35.Zipcode = "78720";
				c35.SSN = "485-81-2960";
				c35.Email = "saunders@pen.com";
				c35.PhoneNumber = "5269661692";
				c35.UserName = "saunders@pen.com";

				var result = await _userManager.CreateAsync(c35, "jrod2017");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c35 = _db.Users.FirstOrDefault(u => u.UserName == "saunders@pen.com");
			}
			 if (await _userManager.IsInRoleAsync(c35, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c35, "Customer");
			}
			_db.SaveChanges();

			AppUser c36 = _db.Users.FirstOrDefault(u => u.Email == "willsheff@email.com");
			if ( c36 == null)
			{
				c36 = new AppUser();
				c36.CustomerNumber = "9045";
				c36.LastName = "Sewell";
				c36.FirstName = "William";
				c36.MiddleInitial = "T.";
				c36.Birthday = "38344";
				c36.StreetAddress = "1672 Oak Valley Circle";
				c36.City = "Austin";
				c36.State = "TX";
				c36.Zipcode = "78705";
				c36.SSN = "845-76-6886";
				c36.Email = "willsheff@email.com";
				c36.PhoneNumber = "1875727246";
				c36.UserName = "willsheff@email.com";

				var result = await _userManager.CreateAsync(c36, "martin1234");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c36 = _db.Users.FirstOrDefault(u => u.UserName == "willsheff@email.com");
			}
			 if (await _userManager.IsInRoleAsync(c36, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c36, "Customer");
			}
			_db.SaveChanges();

			AppUser c37 = _db.Users.FirstOrDefault(u => u.Email == "sheffiled@gogle.com");
			if ( c37 == null)
			{
				c37 = new AppUser();
				c37.CustomerNumber = "9046";
				c37.LastName = "Sheffield";
				c37.FirstName = "Martin";
				c37.MiddleInitial = "J.";
				c37.Birthday = "22044";
				c37.StreetAddress = "816 Kennedy Place";
				c37.City = "Round Rock";
				c37.State = "TX";
				c37.Zipcode = "78680";
				c37.SSN = "786-58-8427";
				c37.Email = "sheffiled@gogle.com";
				c37.PhoneNumber = "1394323615";
				c37.UserName = "sheffiled@gogle.com";

				var result = await _userManager.CreateAsync(c37, "penguin12");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c37 = _db.Users.FirstOrDefault(u => u.UserName == "sheffiled@gogle.com");
			}
			 if (await _userManager.IsInRoleAsync(c37, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c37, "Customer");
			}
			_db.SaveChanges();

			AppUser c38 = _db.Users.FirstOrDefault(u => u.Email == "johnsmith187@aoll.com");
			if ( c38 == null)
			{
				c38 = new AppUser();
				c38.CustomerNumber = "9047";
				c38.LastName = "Smith";
				c38.FirstName = "John";
				c38.MiddleInitial = "A";
				c38.Birthday = "20265";
				c38.StreetAddress = "0745 Golf Road";
				c38.City = "Austin";
				c38.State = "TX";
				c38.Zipcode = "78760";
				c38.SSN = "833-36-3857";
				c38.Email = "johnsmith187@aoll.com";
				c38.PhoneNumber = "6645937874";
				c38.UserName = "johnsmith187@aoll.com";

				var result = await _userManager.CreateAsync(c38, "rogerthat");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c38 = _db.Users.FirstOrDefault(u => u.UserName == "johnsmith187@aoll.com");
			}
			 if (await _userManager.IsInRoleAsync(c38, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c38, "Customer");
			}
			_db.SaveChanges();

			AppUser c39 = _db.Users.FirstOrDefault(u => u.Email == "dustroud@mail.com");
			if ( c39 == null)
			{
				c39 = new AppUser();
				c39.CustomerNumber = "9048";
				c39.LastName = "Stroud";
				c39.FirstName = "Dustin";
				c39.MiddleInitial = "P";
				c39.Birthday = "24679";
				c39.StreetAddress = "505 Dexter Plaza";
				c39.City = "Sweet Home";
				c39.State = "TX";
				c39.Zipcode = "77987";
				c39.SSN = "862-95-5935";
				c39.Email = "dustroud@mail.com";
				c39.PhoneNumber = "6470254680";
				c39.UserName = "dustroud@mail.com";

				var result = await _userManager.CreateAsync(c39, "smitty444");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c39 = _db.Users.FirstOrDefault(u => u.UserName == "dustroud@mail.com");
			}
			 if (await _userManager.IsInRoleAsync(c39, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c39, "Customer");
			}
			_db.SaveChanges();

			AppUser c40 = _db.Users.FirstOrDefault(u => u.Email == "estuart@anchor.net");
			if ( c40 == null)
			{
				c40 = new AppUser();
				c40.CustomerNumber = "9049";
				c40.LastName = "Stuart";
				c40.FirstName = "Eric";
				c40.MiddleInitial = "D.";
				c40.Birthday = "17505";
				c40.StreetAddress = "585 Claremont Drive";
				c40.City = "Corpus Christi";
				c40.State = "TX";
				c40.Zipcode = "78412";
				c40.SSN = "401-87-6781";
				c40.Email = "estuart@anchor.net";
				c40.PhoneNumber = "7701621022";
				c40.UserName = "estuart@anchor.net";

				var result = await _userManager.CreateAsync(c40, "stewball");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c40 = _db.Users.FirstOrDefault(u => u.UserName == "estuart@anchor.net");
			}
			 if (await _userManager.IsInRoleAsync(c40, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c40, "Customer");
			}
			_db.SaveChanges();

			AppUser c41 = _db.Users.FirstOrDefault(u => u.Email == "peterstump@noclue.com");
			if ( c41 == null)
			{
				c41 = new AppUser();
				c41.CustomerNumber = "9050";
				c41.LastName = "Stump";
				c41.FirstName = "Peter";
				c41.MiddleInitial = "L";
				c41.Birthday = "27220";
				c41.StreetAddress = "89035 Welch Circle";
				c41.City = "Pflugerville";
				c41.State = "TX";
				c41.Zipcode = "78660";
				c41.SSN = "414-55-9948";
				c41.Email = "peterstump@noclue.com";
				c41.PhoneNumber = "2181960061";
				c41.UserName = "peterstump@noclue.com";

				var result = await _userManager.CreateAsync(c41, "slowwind");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c41 = _db.Users.FirstOrDefault(u => u.UserName == "peterstump@noclue.com");
			}
			 if (await _userManager.IsInRoleAsync(c41, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c41, "Customer");
			}
			_db.SaveChanges();

			AppUser c42 = _db.Users.FirstOrDefault(u => u.Email == "jtanner@mustang.net");
			if ( c42 == null)
			{
				c42 = new AppUser();
				c42.CustomerNumber = "9051";
				c42.LastName = "Tanner";
				c42.FirstName = "Jeremy";
				c42.MiddleInitial = "S.";
				c42.Birthday = "16082";
				c42.StreetAddress = "4 Stang Trail";
				c42.City = "Austin";
				c42.State = "TX";
				c42.Zipcode = "78702";
				c42.SSN = "215-59-9614";
				c42.Email = "jtanner@mustang.net";
				c42.PhoneNumber = "9908469499";
				c42.UserName = "jtanner@mustang.net";

				var result = await _userManager.CreateAsync(c42, "tanner5454");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c42 = _db.Users.FirstOrDefault(u => u.UserName == "jtanner@mustang.net");
			}
			 if (await _userManager.IsInRoleAsync(c42, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c42, "Customer");
			}
			_db.SaveChanges();

			AppUser c43 = _db.Users.FirstOrDefault(u => u.Email == "taylordjay@aoll.com");
			if ( c43 == null)
			{
				c43 = new AppUser();
				c43.CustomerNumber = "9052";
				c43.LastName = "Taylor";
				c43.FirstName = "Allison";
				c43.MiddleInitial = "R.";
				c43.Birthday = "33191";
				c43.StreetAddress = "726 Twin Pines Avenue";
				c43.City = "Austin";
				c43.State = "TX";
				c43.Zipcode = "78713";
				c43.SSN = "263-91-7172";
				c43.Email = "taylordjay@aoll.com";
				c43.PhoneNumber = "7011918647";
				c43.UserName = "taylordjay@aoll.com";

				var result = await _userManager.CreateAsync(c43, "allyrally");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c43 = _db.Users.FirstOrDefault(u => u.UserName == "taylordjay@aoll.com");
			}
			 if (await _userManager.IsInRoleAsync(c43, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c43, "Customer");
			}
			_db.SaveChanges();

			AppUser c44 = _db.Users.FirstOrDefault(u => u.Email == "rtaylor@gogle.com");
			if ( c44 == null)
			{
				c44 = new AppUser();
				c44.CustomerNumber = "9053";
				c44.LastName = "Taylor";
				c44.FirstName = "Rachel";
				c44.MiddleInitial = "K.";
				c44.Birthday = "27777";
				c44.StreetAddress = "06605 Sugar Drive";
				c44.City = "Austin";
				c44.State = "TX";
				c44.Zipcode = "78712";
				c44.SSN = "774-06-1511";
				c44.Email = "rtaylor@gogle.com";
				c44.PhoneNumber = "8937910053";
				c44.UserName = "rtaylor@gogle.com";

				var result = await _userManager.CreateAsync(c44, "taylorbaylor");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c44 = _db.Users.FirstOrDefault(u => u.UserName == "rtaylor@gogle.com");
			}
			 if (await _userManager.IsInRoleAsync(c44, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c44, "Customer");
			}
			_db.SaveChanges();

			AppUser c45 = _db.Users.FirstOrDefault(u => u.Email == "teefrank@noclue.com");
			if ( c45 == null)
			{
				c45 = new AppUser();
				c45.CustomerNumber = "9054";
				c45.LastName = "Tee";
				c45.FirstName = "Frank";
				c45.MiddleInitial = "J";
				c45.Birthday = "36044";
				c45.StreetAddress = "3567 Dawn Plaza";
				c45.City = "Austin";
				c45.State = "TX";
				c45.Zipcode = "78786";
				c45.SSN = "522-65-3064";
				c45.Email = "teefrank@noclue.com";
				c45.PhoneNumber = "6394568913";
				c45.UserName = "teefrank@noclue.com";

				var result = await _userManager.CreateAsync(c45, "teeoff22");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c45 = _db.Users.FirstOrDefault(u => u.UserName == "teefrank@noclue.com");
			}
			 if (await _userManager.IsInRoleAsync(c45, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c45, "Customer");
			}
			_db.SaveChanges();

			AppUser c46 = _db.Users.FirstOrDefault(u => u.Email == "ctucker@alphabet.co.uk");
			if ( c46 == null)
			{
				c46 = new AppUser();
				c46.CustomerNumber = "9055";
				c46.LastName = "Tucker";
				c46.FirstName = "Clent";
				c46.MiddleInitial = "J";
				c46.Birthday = "15762";
				c46.StreetAddress = "704 Northland Alley";
				c46.City = "San Antonio";
				c46.State = "TX";
				c46.Zipcode = "78279";
				c46.SSN = "876-29-4912";
				c46.Email = "ctucker@alphabet.co.uk";
				c46.PhoneNumber = "2676838676";
				c46.UserName = "ctucker@alphabet.co.uk";

				var result = await _userManager.CreateAsync(c46, "tucksack1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c46 = _db.Users.FirstOrDefault(u => u.UserName == "ctucker@alphabet.co.uk");
			}
			 if (await _userManager.IsInRoleAsync(c46, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c46, "Customer");
			}
			_db.SaveChanges();

			AppUser c47 = _db.Users.FirstOrDefault(u => u.Email == "avelasco@yoho.com");
			if ( c47 == null)
			{
				c47 = new AppUser();
				c47.CustomerNumber = "9056";
				c47.LastName = "Velasco";
				c47.FirstName = "Allen";
				c47.MiddleInitial = "G";
				c47.Birthday = "31300";
				c47.StreetAddress = "72 Harbort Point";
				c47.City = "Navasota";
				c47.State = "TX";
				c47.Zipcode = "77868";
				c47.SSN = "216-67-9243";
				c47.Email = "avelasco@yoho.com";
				c47.PhoneNumber = "3452909754";
				c47.UserName = "avelasco@yoho.com";

				var result = await _userManager.CreateAsync(c47, "meow88");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c47 = _db.Users.FirstOrDefault(u => u.UserName == "avelasco@yoho.com");
			}
			 if (await _userManager.IsInRoleAsync(c47, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c47, "Customer");
			}
			_db.SaveChanges();

			AppUser c48 = _db.Users.FirstOrDefault(u => u.Email == "vinovino@grapes.com");
			if ( c48 == null)
			{
				c48 = new AppUser();
				c48.CustomerNumber = "9057";
				c48.LastName = "Vino";
				c48.FirstName = "Janet";
				c48.MiddleInitial = "E";
				c48.Birthday = "31085";
				c48.StreetAddress = "1 Oak Valley Place";
				c48.City = "Boston";
				c48.State = "MA";
				c48.Zipcode = "02114";
				c48.SSN = "565-57-4107";
				c48.Email = "vinovino@grapes.com";
				c48.PhoneNumber = "8567089194";
				c48.UserName = "vinovino@grapes.com";

				var result = await _userManager.CreateAsync(c48, "vinovino");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c48 = _db.Users.FirstOrDefault(u => u.UserName == "vinovino@grapes.com");
			}
			 if (await _userManager.IsInRoleAsync(c48, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c48, "Customer");
			}
			_db.SaveChanges();

			AppUser c49 = _db.Users.FirstOrDefault(u => u.Email == "westj@pioneer.net");
			if ( c49 == null)
			{
				c49 = new AppUser();
				c49.CustomerNumber = "9058";
				c49.LastName = "West";
				c49.FirstName = "Jake";
				c49.MiddleInitial = "T";
				c49.Birthday = "27768";
				c49.StreetAddress = "48743 Banding Parkway";
				c49.City = "Marble Falls";
				c49.State = "TX";
				c49.Zipcode = "78654";
				c49.SSN = "390-37-6155";
				c49.Email = "westj@pioneer.net";
				c49.PhoneNumber = "6260784394";
				c49.UserName = "westj@pioneer.net";

				var result = await _userManager.CreateAsync(c49, "gowest");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c49 = _db.Users.FirstOrDefault(u => u.UserName == "westj@pioneer.net");
			}
			 if (await _userManager.IsInRoleAsync(c49, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c49, "Customer");
			}
			_db.SaveChanges();

			AppUser c50 = _db.Users.FirstOrDefault(u => u.Email == "winner@hootmail.com");
			if ( c50 == null)
			{
				c50 = new AppUser();
				c50.CustomerNumber = "9059";
				c50.LastName = "Winthorpe";
				c50.FirstName = "Louis";
				c50.MiddleInitial = "L";
				c50.Birthday = "19468";
				c50.StreetAddress = "96850 Summit Crossing";
				c50.City = "Austin";
				c50.State = "TX";
				c50.Zipcode = "78730";
				c50.SSN = "445-77-2754";
				c50.Email = "winner@hootmail.com";
				c50.PhoneNumber = "3733971174";
				c50.UserName = "winner@hootmail.com";

				var result = await _userManager.CreateAsync(c50, "louielouie");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c50 = _db.Users.FirstOrDefault(u => u.UserName == "winner@hootmail.com");
			}
			 if (await _userManager.IsInRoleAsync(c50, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c50, "Customer");
			}
			_db.SaveChanges();

			AppUser c51 = _db.Users.FirstOrDefault(u => u.Email == "rwood@voyager.net");
			if ( c51 == null)
			{
				c51 = new AppUser();
				c51.CustomerNumber = "9060";
				c51.LastName = "Wood";
				c51.FirstName = "Reagan";
				c51.MiddleInitial = "B.";
				c51.Birthday = "37618";
				c51.StreetAddress = "18354 Bluejay Street";
				c51.City = "Austin";
				c51.State = "TX";
				c51.Zipcode = "78712";
				c51.SSN = "805-38-7710";
				c51.Email = "rwood@voyager.net";
				c51.PhoneNumber = "8433359800";
				c51.UserName = "rwood@voyager.net";

				var result = await _userManager.CreateAsync(c51, "woodyman1");
				if (result.Succeeded == false)
				{
					throw new Exception("This user can't be added - "  + result.ToString());
				}
				_db.SaveChanges();
				c51 = _db.Users.FirstOrDefault(u => u.UserName == "rwood@voyager.net");
			}
			 if (await _userManager.IsInRoleAsync(c51, "Customer") == false)
			{
				await _userManager.AddToRoleAsync(c51, "Customer");
			}
			_db.SaveChanges();

		}
	}
}
