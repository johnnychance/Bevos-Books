using fa18Team28_FinalProject.Models;
using fa18Team28_FinalProject.DAL;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace fa18Team28_FinalProject.Seeding
{
	public static class SeedEmployees
	{
        public static async Task AddAdmin(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (await _roleManager.RoleExistsAsync("Manager") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Manager"));
            }
            if (await _roleManager.RoleExistsAsync("Employee") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            }

            AppUser e1 = _db.Users.FirstOrDefault(u => u.Email == "c.baker@bevosbooks.com");
            if (e1 == null)
            {
                e1 = new AppUser();
                e1.LastName = "Baker";
                e1.FirstName = "Christopher";
                e1.MiddleInitial = "E";
                e1.SSN = "401661146";
                e1.StreetAddress = "1245 Lake Libris Dr.";
                e1.City = "Cedar Park";
                e1.State = "TX";
                e1.Zipcode = "78613";
                e1.PhoneNumber = "3395325649";
                e1.Email = "c.baker@bevosbooks.com";
                e1.UserName = "c.baker@bevosbooks.com";

                var result = await _userManager.CreateAsync(e1, "dewey4");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e1 = _db.Users.FirstOrDefault(u => u.UserName == "c.baker@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e1, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(e1, "Manager");
            }
            _db.SaveChanges();

            AppUser e2 = _db.Users.FirstOrDefault(u => u.Email == "s.barnes@bevosbooks.com");
            if (e2 == null)
            {
                e2 = new AppUser();
                e2.LastName = "Barnes";
                e2.FirstName = "Susan";
                e2.MiddleInitial = "M";
                e2.SSN = "1112221212";
                e2.StreetAddress = "888 S. Main";
                e2.City = "Kyle";
                e2.State = "TX";
                e2.Zipcode = "78640";
                e2.PhoneNumber = "9636389416";
                e2.Email = "s.barnes@bevosbooks.com";
                e2.UserName = "s.barnes@bevosbooks.com";

                var result = await _userManager.CreateAsync(e2, "smitty");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e2 = _db.Users.FirstOrDefault(u => u.UserName == "s.barnes@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e2, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e2, "Employee");
            }
            _db.SaveChanges();

            AppUser e3 = _db.Users.FirstOrDefault(u => u.Email == "h.garcia@bevosbooks.com");
            if (e3 == null)
            {
                e3 = new AppUser();
                e3.LastName = "Garcia";
                e3.FirstName = "Hector";
                e3.MiddleInitial = "W";
                e3.SSN = "4445554343";
                e3.StreetAddress = "777 PBR Drive";
                e3.City = "Austin";
                e3.State = "TX";
                e3.Zipcode = "78712";
                e3.PhoneNumber = "4547135738";
                e3.Email = "h.garcia@bevosbooks.com";
                e3.UserName = "h.garcia@bevosbooks.com";

                var result = await _userManager.CreateAsync(e3, "squirrel");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e3 = _db.Users.FirstOrDefault(u => u.UserName == "h.garcia@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e3, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e3, "Employee");
            }
            _db.SaveChanges();

            AppUser e4 = _db.Users.FirstOrDefault(u => u.Email == "b.ingram@bevosbooks.com");
            if (e4 == null)
            {
                e4 = new AppUser();
                e4.LastName = "Ingram";
                e4.FirstName = "Brad";
                e4.MiddleInitial = "S";
                e4.SSN = "797348821";
                e4.StreetAddress = "6548 La Posada Ct.";
                e4.City = "Austin";
                e4.State = "TX";
                e4.Zipcode = "78705";
                e4.PhoneNumber = "5817343315";
                e4.Email = "b.ingram@bevosbooks.com";
                e4.UserName = "b.ingram@bevosbooks.com";

                var result = await _userManager.CreateAsync(e4, "changalang");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e4 = _db.Users.FirstOrDefault(u => u.UserName == "b.ingram@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e4, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e4, "Employee");
            }
            _db.SaveChanges();

            AppUser e5 = _db.Users.FirstOrDefault(u => u.Email == "j.jackson@bevosbooks.com");
            if (e5 == null)
            {
                e5 = new AppUser();
                e5.LastName = "Jackson";
                e5.FirstName = "Jack";
                e5.MiddleInitial = "J";
                e5.SSN = "8889993434";
                e5.StreetAddress = "222 Main";
                e5.City = "Austin";
                e5.State = "TX";
                e5.Zipcode = "78760";
                e5.PhoneNumber = "8241915317";
                e5.Email = "j.jackson@bevosbooks.com";
                e5.UserName = "j.jackson@bevosbooks.com";

                var result = await _userManager.CreateAsync(e5, "rhythm");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e5 = _db.Users.FirstOrDefault(u => u.UserName == "j.jackson@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e5, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e5, "Employee");
            }
            _db.SaveChanges();

            AppUser e6 = _db.Users.FirstOrDefault(u => u.Email == "t.jacobs@bevosbooks.com");
            if (e6 == null)
            {
                e6 = new AppUser();
                e6.LastName = "Jacobs";
                e6.FirstName = "Todd";
                e6.MiddleInitial = "L";
                e6.SSN = "341553365";
                e6.StreetAddress = "4564 Elm St.";
                e6.City = "Georgetown";
                e6.State = "TX";
                e6.Zipcode = "78628";
                e6.PhoneNumber = "2477822475";
                e6.Email = "t.jacobs@bevosbooks.com";
                e6.UserName = "t.jacobs@bevosbooks.com";

                var result = await _userManager.CreateAsync(e6, "approval");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e6 = _db.Users.FirstOrDefault(u => u.UserName == "t.jacobs@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e6, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e6, "Employee");
            }
            _db.SaveChanges();

            AppUser e7 = _db.Users.FirstOrDefault(u => u.Email == "l.jones@bevosbooks.com");
            if (e7 == null)
            {
                e7 = new AppUser();
                e7.LastName = "Jones";
                e7.FirstName = "Lester";
                e7.MiddleInitial = "L";
                e7.SSN = "9099099999";
                e7.StreetAddress = "999 LeBlat";
                e7.City = "Austin";
                e7.State = "TX";
                e7.Zipcode = "78747";
                e7.PhoneNumber = "4764966462";
                e7.Email = "l.jones@bevosbooks.com";
                e7.UserName = "l.jones@bevosbooks.com";

                var result = await _userManager.CreateAsync(e7, "society");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e7 = _db.Users.FirstOrDefault(u => u.UserName == "l.jones@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e7, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e7, "Employee");
            }
            _db.SaveChanges();

            AppUser e8 = _db.Users.FirstOrDefault(u => u.Email == "b.larson@bevosbooks.com");
            if (e8 == null)
            {
                e8 = new AppUser();
                e8.LastName = "Larson";
                e8.FirstName = "Bill";
                e8.MiddleInitial = "B";
                e8.SSN = "5554443333";
                e8.StreetAddress = "1212 N. First Ave";
                e8.City = "Round Rock";
                e8.State = "TX";
                e8.Zipcode = "78665";
                e8.PhoneNumber = "3355258855";
                e8.Email = "b.larson@bevosbooks.com";
                e8.UserName = "b.larson@bevosbooks.com";

                var result = await _userManager.CreateAsync(e8, "tanman");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e8 = _db.Users.FirstOrDefault(u => u.UserName == "b.larson@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e8, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e8, "Employee");
            }
            _db.SaveChanges();

            AppUser e9 = _db.Users.FirstOrDefault(u => u.Email == "v.lawrence@bevosbooks.com");
            if (e9 == null)
            {
                e9 = new AppUser();
                e9.LastName = "Lawrence";
                e9.FirstName = "Victoria";
                e9.MiddleInitial = "Y";
                e9.SSN = "770097399";
                e9.StreetAddress = "6639 Bookworm Ln.";
                e9.City = "Austin";
                e9.State = "TX";
                e9.Zipcode = "78712";
                e9.PhoneNumber = "7511273054";
                e9.Email = "v.lawrence@bevosbooks.com";
                e9.UserName = "v.lawrence@bevosbooks.com";

                var result = await _userManager.CreateAsync(e9, "longhorns");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e9 = _db.Users.FirstOrDefault(u => u.UserName == "v.lawrence@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e9, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e9, "Employee");
            }
            _db.SaveChanges();

            AppUser e10 = _db.Users.FirstOrDefault(u => u.Email == "m.lopez@bevosbooks.com");
            if (e10 == null)
            {
                e10 = new AppUser();
                e10.LastName = "Lopez";
                e10.FirstName = "Marshall";
                e10.MiddleInitial = "T";
                e10.SSN = "2223332222";
                e10.StreetAddress = "90 SW North St";
                e10.City = "Austin";
                e10.State = "TX";
                e10.Zipcode = "78729";
                e10.PhoneNumber = "7477907070";
                e10.Email = "m.lopez@bevosbooks.com";
                e10.UserName = "m.lopez@bevosbooks.com";

                var result = await _userManager.CreateAsync(e10, "swansong");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e10 = _db.Users.FirstOrDefault(u => u.UserName == "m.lopez@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e10, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e10, "Employee");
            }
            _db.SaveChanges();

            AppUser e11 = _db.Users.FirstOrDefault(u => u.Email == "j.macleod@bevosbooks.com");
            if (e11 == null)
            {
                e11 = new AppUser();
                e11.LastName = "MacLeod";
                e11.FirstName = "Jennifer";
                e11.MiddleInitial = "D";
                e11.SSN = "775908138";
                e11.StreetAddress = "2504 Far West Blvd.";
                e11.City = "Austin";
                e11.State = "TX";
                e11.Zipcode = "78705";
                e11.PhoneNumber = "2621216845";
                e11.Email = "j.macleod@bevosbooks.com";
                e11.UserName = "j.macleod@bevosbooks.com";

                var result = await _userManager.CreateAsync(e11, "fungus");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e11 = _db.Users.FirstOrDefault(u => u.UserName == "j.macleod@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e11, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e11, "Employee");
            }
            _db.SaveChanges();

            AppUser e12 = _db.Users.FirstOrDefault(u => u.Email == "e.markham@bevosbooks.com");
            if (e12 == null)
            {
                e12 = new AppUser();
                e12.LastName = "Markham";
                e12.FirstName = "Elizabeth";
                e12.MiddleInitial = "K";
                e12.SSN = "101529845";
                e12.StreetAddress = "7861 Chevy Chase";
                e12.City = "Austin";
                e12.State = "TX";
                e12.Zipcode = "78785";
                e12.PhoneNumber = "5028075807";
                e12.Email = "e.markham@bevosbooks.com";
                e12.UserName = "e.markham@bevosbooks.com";

                var result = await _userManager.CreateAsync(e12, "median");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e12 = _db.Users.FirstOrDefault(u => u.UserName == "e.markham@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e12, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e12, "Employee");
            }
            _db.SaveChanges();

            AppUser e13 = _db.Users.FirstOrDefault(u => u.Email == "g.martinez@bevosbooks.com");
            if (e13 == null)
            {
                e13 = new AppUser();
                e13.LastName = "Martinez";
                e13.FirstName = "Gregory";
                e13.MiddleInitial = "R";
                e13.SSN = "463566718";
                e13.StreetAddress = "8295 Sunset Blvd.";
                e13.City = "Austin";
                e13.State = "TX";
                e13.Zipcode = "78712";
                e13.PhoneNumber = "1994708542";
                e13.Email = "g.martinez@bevosbooks.com";
                e13.UserName = "g.martinez@bevosbooks.com";

                var result = await _userManager.CreateAsync(e13, "decorate");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e13 = _db.Users.FirstOrDefault(u => u.UserName == "g.martinez@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e13, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e13, "Employee");
            }
            _db.SaveChanges();

            AppUser e14 = _db.Users.FirstOrDefault(u => u.Email == "j.mason@bevosbooks.com");
            if (e14 == null)
            {
                e14 = new AppUser();
                e14.LastName = "Mason";
                e14.FirstName = "Jack";
                e14.MiddleInitial = "L";
                e14.SSN = "1112223232";
                e14.StreetAddress = "444 45th St";
                e14.City = "Austin";
                e14.State = "TX";
                e14.Zipcode = "78701";
                e14.PhoneNumber = "1748136441";
                e14.Email = "j.mason@bevosbooks.com";
                e14.UserName = "j.mason@bevosbooks.com";

                var result = await _userManager.CreateAsync(e14, "rankmary");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e14 = _db.Users.FirstOrDefault(u => u.UserName == "j.mason@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e14, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e14, "Employee");
            }
            _db.SaveChanges();

            AppUser e15 = _db.Users.FirstOrDefault(u => u.Email == "c.miller@bevosbooks.com");
            if (e15 == null)
            {
                e15 = new AppUser();
                e15.LastName = "Miller";
                e15.FirstName = "Charles";
                e15.MiddleInitial = "R";
                e15.SSN = "353308615";
                e15.StreetAddress = "8962 Main St.";
                e15.City = "Austin";
                e15.State = "TX";
                e15.Zipcode = "78709";
                e15.PhoneNumber = "8999319585";
                e15.Email = "c.miller@bevosbooks.com";
                e15.UserName = "c.miller@bevosbooks.com";

                var result = await _userManager.CreateAsync(e15, "kindly");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e15 = _db.Users.FirstOrDefault(u => u.UserName == "c.miller@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e15, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e15, "Employee");
            }
            _db.SaveChanges();

            AppUser e16 = _db.Users.FirstOrDefault(u => u.Email == "m.nguyen@bevosbooks.com");
            if (e16 == null)
            {
                e16 = new AppUser();
                e16.LastName = "Nguyen";
                e16.FirstName = "Mary";
                e16.MiddleInitial = "J";
                e16.SSN = "7776665555";
                e16.StreetAddress = "465 N. Bear Cub";
                e16.City = "Austin";
                e16.State = "TX";
                e16.Zipcode = "78734";
                e16.PhoneNumber = "8716746381";
                e16.Email = "m.nguyen@bevosbooks.com";
                e16.UserName = "m.nguyen@bevosbooks.com";

                var result = await _userManager.CreateAsync(e16, "ricearoni");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e16 = _db.Users.FirstOrDefault(u => u.UserName == "m.nguyen@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e16, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e16, "Employee");
            }
            _db.SaveChanges();

            AppUser e17 = _db.Users.FirstOrDefault(u => u.Email == "s.rankin@bevosbooks.com");
            if (e17 == null)
            {
                e17 = new AppUser();
                e17.LastName = "Rankin";
                e17.FirstName = "Suzie";
                e17.MiddleInitial = "R";
                e17.SSN = "1911919111";
                e17.StreetAddress = "23 Dewey Road";
                e17.City = "Austin";
                e17.State = "TX";
                e17.Zipcode = "78712";
                e17.PhoneNumber = "5239029525";
                e17.Email = "s.rankin@bevosbooks.com";
                e17.UserName = "s.rankin@bevosbooks.com";

                var result = await _userManager.CreateAsync(e17, "walkamile");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e17 = _db.Users.FirstOrDefault(u => u.UserName == "s.rankin@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e17, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e17, "Employee");
            }
            _db.SaveChanges();

            AppUser e18 = _db.Users.FirstOrDefault(u => u.Email == "m.rhodes@bevosbooks.com");
            if (e18 == null)
            {
                e18 = new AppUser();
                e18.LastName = "Rhodes";
                e18.FirstName = "Megan";
                e18.MiddleInitial = "C";
                e18.SSN = "353904746";
                e18.StreetAddress = "4587 Enfield Rd.";
                e18.City = "Austin";
                e18.State = "TX";
                e18.Zipcode = "78729";
                e18.PhoneNumber = "1232139514";
                e18.Email = "m.rhodes@bevosbooks.com";
                e18.UserName = "m.rhodes@bevosbooks.com";

                var result = await _userManager.CreateAsync(e18, "ingram45");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e18 = _db.Users.FirstOrDefault(u => u.UserName == "m.rhodes@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e18, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e18, "Employee");
            }
            _db.SaveChanges();

            AppUser e19 = _db.Users.FirstOrDefault(u => u.Email == "e.rice@bevosbooks.com");
            if (e19 == null)
            {
                e19 = new AppUser();
                e19.LastName = "Rice";
                e19.FirstName = "Eryn";
                e19.MiddleInitial = "M";
                e19.SSN = "454776657";
                e19.StreetAddress = "3405 Rio Grande";
                e19.City = "Austin";
                e19.State = "TX";
                e19.Zipcode = "78746";
                e19.PhoneNumber = "2706602803";
                e19.Email = "e.rice@bevosbooks.com";
                e19.UserName = "e.rice@bevosbooks.com";

                var result = await _userManager.CreateAsync(e19, "arched");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e19 = _db.Users.FirstOrDefault(u => u.UserName == "e.rice@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e19, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(e19, "Manager");
            }
            _db.SaveChanges();

            AppUser e20 = _db.Users.FirstOrDefault(u => u.Email == "a.rogers@bevosbooks.com");
            if (e20 == null)
            {
                e20 = new AppUser();
                e20.LastName = "Rogers";
                e20.FirstName = "Allen";
                e20.MiddleInitial = "H";
                e20.SSN = "700002943";
                e20.StreetAddress = "4965 Oak Hill";
                e20.City = "Austin";
                e20.State = "TX";
                e20.Zipcode = "78705";
                e20.PhoneNumber = "4139645586";
                e20.Email = "a.rogers@bevosbooks.com";
                e20.UserName = "a.rogers@bevosbooks.com";

                var result = await _userManager.CreateAsync(e20, "lottery");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e20 = _db.Users.FirstOrDefault(u => u.UserName == "a.rogers@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e20, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(e20, "Manager");
            }
            _db.SaveChanges();

            AppUser e21 = _db.Users.FirstOrDefault(u => u.Email == "s.saunders@bevosbooks.com");
            if (e21 == null)
            {
                e21 = new AppUser();
                e21.LastName = "Saunders";
                e21.FirstName = "Sarah";
                e21.MiddleInitial = "M";
                e21.SSN = "500987810";
                e21.StreetAddress = "332 Avenue C";
                e21.City = "Austin";
                e21.State = "TX";
                e21.Zipcode = "78733";
                e21.PhoneNumber = "9036349587";
                e21.Email = "s.saunders@bevosbooks.com";
                e21.UserName = "s.saunders@bevosbooks.com";

                var result = await _userManager.CreateAsync(e21, "nostalgic");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e21 = _db.Users.FirstOrDefault(u => u.UserName == "s.saunders@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e21, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e21, "Employee");
            }
            _db.SaveChanges();

            AppUser e22 = _db.Users.FirstOrDefault(u => u.Email == "w.sewell@bevosbooks.com");
            if (e22 == null)
            {
                e22 = new AppUser();
                e22.LastName = "Sewell";
                e22.FirstName = "William";
                e22.MiddleInitial = "G";
                e22.SSN = "500830084";
                e22.StreetAddress = "2365 51st St.";
                e22.City = "Austin";
                e22.State = "TX";
                e22.Zipcode = "78755";
                e22.PhoneNumber = "7224308314";
                e22.Email = "w.sewell@bevosbooks.com";
                e22.UserName = "w.sewell@bevosbooks.com";

                var result = await _userManager.CreateAsync(e22, "offbeat");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e22 = _db.Users.FirstOrDefault(u => u.UserName == "w.sewell@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e22, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(e22, "Manager");
            }
            _db.SaveChanges();

            AppUser e23 = _db.Users.FirstOrDefault(u => u.Email == "m.sheffield@bevosbooks.com");
            if (e23 == null)
            {
                e23 = new AppUser();
                e23.LastName = "Sheffield";
                e23.FirstName = "Martin";
                e23.MiddleInitial = "J";
                e23.SSN = "223449167";
                e23.StreetAddress = "3886 Avenue A";
                e23.City = "San Marcos";
                e23.State = "TX";
                e23.Zipcode = "78666";
                e23.PhoneNumber = "9349192978";
                e23.Email = "m.sheffield@bevosbooks.com";
                e23.UserName = "m.sheffield@bevosbooks.com";

                var result = await _userManager.CreateAsync(e23, "evanescent");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e23 = _db.Users.FirstOrDefault(u => u.UserName == "m.sheffield@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e23, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e23, "Employee");
            }
            _db.SaveChanges();

            AppUser e24 = _db.Users.FirstOrDefault(u => u.Email == "c.silva@bevosbooks.com");
            if (e24 == null)
            {
                e24 = new AppUser();
                e24.LastName = "Silva";
                e24.FirstName = "Cindy";
                e24.MiddleInitial = "S";
                e24.SSN = "7776661111";
                e24.StreetAddress = "900 4th St";
                e24.City = "Austin";
                e24.State = "TX";
                e24.Zipcode = "78758";
                e24.PhoneNumber = "4874328170";
                e24.Email = "c.silva@bevosbooks.com";
                e24.UserName = "c.silva@bevosbooks.com";

                var result = await _userManager.CreateAsync(e24, "stewboy");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e24 = _db.Users.FirstOrDefault(u => u.UserName == "c.silva@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e24, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e24, "Employee");
            }
            _db.SaveChanges();

            AppUser e25 = _db.Users.FirstOrDefault(u => u.Email == "e.stuart@bevosbooks.com");
            if (e25 == null)
            {
                e25 = new AppUser();
                e25.LastName = "Stuart";
                e25.FirstName = "Eric";
                e25.MiddleInitial = "F";
                e25.SSN = "363998335";
                e25.StreetAddress = "5576 Toro Ring";
                e25.City = "Austin";
                e25.State = "TX";
                e25.Zipcode = "78758";
                e25.PhoneNumber = "1967846827";
                e25.Email = "e.stuart@bevosbooks.com";
                e25.UserName = "e.stuart@bevosbooks.com";

                var result = await _userManager.CreateAsync(e25, "instrument");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e25 = _db.Users.FirstOrDefault(u => u.UserName == "e.stuart@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e25, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e25, "Employee");
            }
            _db.SaveChanges();

            AppUser e26 = _db.Users.FirstOrDefault(u => u.Email == "j.tanner@bevosbooks.com");
            if (e26 == null)
            {
                e26 = new AppUser();
                e26.LastName = "Tanner";
                e26.FirstName = "Jeremy";
                e26.MiddleInitial = "S";
                e26.SSN = "904440929";
                e26.StreetAddress = "4347 Almstead";
                e26.City = "Austin";
                e26.State = "TX";
                e26.Zipcode = "78712";
                e26.PhoneNumber = "5923026779";
                e26.Email = "j.tanner@bevosbooks.com";
                e26.UserName = "j.tanner@bevosbooks.com";

                var result = await _userManager.CreateAsync(e26, "hecktour");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e26 = _db.Users.FirstOrDefault(u => u.UserName == "j.tanner@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e26, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e26, "Employee");
            }
            _db.SaveChanges();

            AppUser e27 = _db.Users.FirstOrDefault(u => u.Email == "a.taylor@bevosbooks.com");
            if (e27 == null)
            {
                e27 = new AppUser();
                e27.LastName = "Taylor";
                e27.FirstName = "Allison";
                e27.MiddleInitial = "R";
                e27.SSN = "934778452";
                e27.StreetAddress = "467 Nueces St.";
                e27.City = "Austin";
                e27.State = "TX";
                e27.Zipcode = "78727";
                e27.PhoneNumber = "7246195827";
                e27.Email = "a.taylor@bevosbooks.com";
                e27.UserName = "a.taylor@bevosbooks.com";

                var result = await _userManager.CreateAsync(e27, "countryrhodes");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e27 = _db.Users.FirstOrDefault(u => u.UserName == "a.taylor@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e27, "Employee") == false)
            {
                await _userManager.AddToRoleAsync(e27, "Employee");
            }
            _db.SaveChanges();

            AppUser e28 = _db.Users.FirstOrDefault(u => u.Email == "r.taylor@bevosbooks.com");
            if (e28 == null)
            {
                e28 = new AppUser();
                e28.LastName = "Taylor";
                e28.FirstName = "Rachel";
                e28.MiddleInitial = "O";
                e28.SSN = "393412631";
                e28.StreetAddress = "345 Longview Dr.";
                e28.City = "Austin";
                e28.State = "TX";
                e28.Zipcode = "78746";
                e28.PhoneNumber = "9071236087";
                e28.Email = "r.taylor@bevosbooks.com";
                e28.UserName = "r.taylor@bevosbooks.com";

                var result = await _userManager.CreateAsync(e28, "landus");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                e28 = _db.Users.FirstOrDefault(u => u.UserName == "r.taylor@bevosbooks.com");
            }
            if (await _userManager.IsInRoleAsync(e28, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(e28, "Manager");
            }
            _db.SaveChanges();

        }
    }
}
