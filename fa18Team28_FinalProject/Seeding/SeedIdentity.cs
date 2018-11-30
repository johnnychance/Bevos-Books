using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

//TODO: Make these using statements match your project
using fa18Team28_FinalProject.DAL;
using fa18Team28_FinalProject.Models;

//TODO: Change this namespace to match your project
namespace fa18Team28_FinalProject.Seeding
{
    //add identity data
    public static class SeedIdentity
    {
        public static async Task AddAdmin(IServiceProvider serviceProvider)
        {
            AppDbContext _db = serviceProvider.GetRequiredService<AppDbContext>();
            UserManager<AppUser> _userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> _roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //TODO: Add the needed roles
            //if role doesn't exist, add it
            if (await _roleManager.RoleExistsAsync("Manager") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Manager"));
            }
            if (await _roleManager.RoleExistsAsync("Employee") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Employee"));
            }
            if (await _roleManager.RoleExistsAsync("Customer") == false)
            {
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            //****Start here
            //check to see if the manager has been added
            //is there someone w this email add
            AppUser manager = _db.Users.FirstOrDefault(u => u.Email == "admin@example.com");

            //if no one with that email, add them 
            //if manager hasn't been created, then add them
            if (manager == null)
            {
                manager = new AppUser();
                manager.UserName = "admin@example.com";
                manager.Email = "admin@example.com";
                manager.PhoneNumber = "(512)555-5555";
                manager.FirstName = "Admin";

                //TODO: Add any other fields for your app user class here
                //manager.LastName = "Example";
                //manager.DateAdded = DateTime.Today;

                //NOTE: Ask the user manager to create the new user
                //The second parameter for .CreateAsync is the user's password
                var result = await _userManager.CreateAsync(manager, "Abc123!");
                if (result.Succeeded == false)
                {
                    throw new Exception("This user can't be added - " + result.ToString());
                }
                _db.SaveChanges();
                manager = _db.Users.FirstOrDefault(u => u.UserName == "admin@example.com");
            }

            //make sure user is in role
            if (await _userManager.IsInRoleAsync(manager, "Manager") == false)
            {
                await _userManager.AddToRoleAsync(manager, "Manager");
            }

            //save changes
            _db.SaveChanges();
        }
        //**end here 


    }
}