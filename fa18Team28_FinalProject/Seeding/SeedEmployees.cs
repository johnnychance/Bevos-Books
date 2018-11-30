using fa18Team28_FinalProject.Models;
using fa18Team28_FinalProject.DAL;
using System.Collections.Generic;
using System;
using System.Linq;

namespace fa18Team28_FinalProject.Seeding
{
	public static class SeedEmployees
	{
		public static void SeedAllEmployees(AppDbContext db)
		{
			if (db.Employees.Count() == 28)
			{
				throw new NotSupportedException("The database already contains all 28 employees!");
			}

			Int32 intEmployeesAdded = 0;
			String employeeName = "Begin"; //helps to keep track of error on repos
			List<Employee> Employees = new List<Employee>();

			try
			{
				Employee e1 = new Employee();
				e1.LastName = "Baker";
				e1.FirstName = "Christopher";
				e1.MiddleIntitial = "E";
				e1.Password = "dewey4";
				e1.SSN = 401661146;
				e1.EmpType = "Manager";
				e1.Address = "1245 Lake Libris Dr.";
				e1.City = "Cedar Park";
				e1.State = "TX";
				e1.ZipCode = 78613;
				e1.PhoneNumeber = 3395325649;
				e1.EmailAddress = "c.baker@bevosbooks.com";
				Employees.Add(e1);

				Employee e2 = new Employee();
				e2.LastName = "Barnes";
				e2.FirstName = "Susan";
				e2.MiddleIntitial = "M";
				e2.Password = "smitty";
				e2.SSN = 1112221212;
				e2.EmpType = "Employee";
				e2.Address = "888 S. Main";
				e2.City = "Kyle";
				e2.State = "TX";
				e2.ZipCode = 78640;
				e2.PhoneNumeber = 9636389416;
				e2.EmailAddress = "s.barnes@bevosbooks.com";
				Employees.Add(e2);

				Employee e3 = new Employee();
				e3.LastName = "Garcia";
				e3.FirstName = "Hector";
				e3.MiddleIntitial = "W";
				e3.Password = "squirrel";
				e3.SSN = 4445554343;
				e3.EmpType = "Employee";
				e3.Address = "777 PBR Drive";
				e3.City = "Austin";
				e3.State = "TX";
				e3.ZipCode = 78712;
				e3.PhoneNumeber = 4547135738;
				e3.EmailAddress = "h.garcia@bevosbooks.com";
				Employees.Add(e3);

				Employee e4 = new Employee();
				e4.LastName = "Ingram";
				e4.FirstName = "Brad";
				e4.MiddleIntitial = "S";
				e4.Password = "changalang";
				e4.SSN = 797348821;
				e4.EmpType = "Employee";
				e4.Address = "6548 La Posada Ct.";
				e4.City = "Austin";
				e4.State = "TX";
				e4.ZipCode = 78705;
				e4.PhoneNumeber = 5817343315;
				e4.EmailAddress = "b.ingram@bevosbooks.com";
				Employees.Add(e4);

				Employee e5 = new Employee();
				e5.LastName = "Jackson";
				e5.FirstName = "Jack";
				e5.MiddleIntitial = "J";
				e5.Password = "rhythm";
				e5.SSN = 8889993434;
				e5.EmpType = "Employee";
				e5.Address = "222 Main";
				e5.City = "Austin";
				e5.State = "TX";
				e5.ZipCode = 78760;
				e5.PhoneNumeber = 8241915317;
				e5.EmailAddress = "j.jackson@bevosbooks.com";
				Employees.Add(e5);

				Employee e6 = new Employee();
				e6.LastName = "Jacobs";
				e6.FirstName = "Todd";
				e6.MiddleIntitial = "L";
				e6.Password = "approval";
				e6.SSN = 341553365;
				e6.EmpType = "Employee";
				e6.Address = "4564 Elm St.";
				e6.City = "Georgetown";
				e6.State = "TX";
				e6.ZipCode = 78628;
				e6.PhoneNumeber = 2477822475;
				e6.EmailAddress = "t.jacobs@bevosbooks.com";
				Employees.Add(e6);

				Employee e7 = new Employee();
				e7.LastName = "Jones";
				e7.FirstName = "Lester";
				e7.MiddleIntitial = "L";
				e7.Password = "society";
				e7.SSN = 9099099999;
				e7.EmpType = "Employee";
				e7.Address = "999 LeBlat";
				e7.City = "Austin";
				e7.State = "TX";
				e7.ZipCode = 78747;
				e7.PhoneNumeber = 4764966462;
				e7.EmailAddress = "l.jones@bevosbooks.com";
				Employees.Add(e7);

				Employee e8 = new Employee();
				e8.LastName = "Larson";
				e8.FirstName = "Bill";
				e8.MiddleIntitial = "B";
				e8.Password = "tanman";
				e8.SSN = 5554443333;
				e8.EmpType = "Employee";
				e8.Address = "1212 N. First Ave";
				e8.City = "Round Rock";
				e8.State = "TX";
				e8.ZipCode = 78665;
				e8.PhoneNumeber = 3355258855;
				e8.EmailAddress = "b.larson@bevosbooks.com";
				Employees.Add(e8);

				Employee e9 = new Employee();
				e9.LastName = "Lawrence";
				e9.FirstName = "Victoria";
				e9.MiddleIntitial = "Y";
				e9.Password = "longhorns";
				e9.SSN = 770097399;
				e9.EmpType = "Employee";
				e9.Address = "6639 Bookworm Ln.";
				e9.City = "Austin";
				e9.State = "TX";
				e9.ZipCode = 78712;
				e9.PhoneNumeber = 7511273054;
				e9.EmailAddress = "v.lawrence@bevosbooks.com";
				Employees.Add(e9);

				Employee e10 = new Employee();
				e10.LastName = "Lopez";
				e10.FirstName = "Marshall";
				e10.MiddleIntitial = "T";
				e10.Password = "swansong";
				e10.SSN = 2223332222;
				e10.EmpType = "Employee";
				e10.Address = "90 SW North St";
				e10.City = "Austin";
				e10.State = "TX";
				e10.ZipCode = 78729;
				e10.PhoneNumeber = 7477907070;
				e10.EmailAddress = "m.lopez@bevosbooks.com";
				Employees.Add(e10);

				Employee e11 = new Employee();
				e11.LastName = "MacLeod";
				e11.FirstName = "Jennifer";
				e11.MiddleIntitial = "D";
				e11.Password = "fungus";
				e11.SSN = 775908138;
				e11.EmpType = "Employee";
				e11.Address = "2504 Far West Blvd.";
				e11.City = "Austin";
				e11.State = "TX";
				e11.ZipCode = 78705;
				e11.PhoneNumeber = 2621216845;
				e11.EmailAddress = "j.macleod@bevosbooks.com";
				Employees.Add(e11);

				Employee e12 = new Employee();
				e12.LastName = "Markham";
				e12.FirstName = "Elizabeth";
				e12.MiddleIntitial = "K";
				e12.Password = "median";
				e12.SSN = 101529845;
				e12.EmpType = "Employee";
				e12.Address = "7861 Chevy Chase";
				e12.City = "Austin";
				e12.State = "TX";
				e12.ZipCode = 78785;
				e12.PhoneNumeber = 5028075807;
				e12.EmailAddress = "e.markham@bevosbooks.com";
				Employees.Add(e12);

				Employee e13 = new Employee();
				e13.LastName = "Martinez";
				e13.FirstName = "Gregory";
				e13.MiddleIntitial = "R";
				e13.Password = "decorate";
				e13.SSN = 463566718;
				e13.EmpType = "Employee";
				e13.Address = "8295 Sunset Blvd.";
				e13.City = "Austin";
				e13.State = "TX";
				e13.ZipCode = 78712;
				e13.PhoneNumeber = 1994708542;
				e13.EmailAddress = "g.martinez@bevosbooks.com";
				Employees.Add(e13);

				Employee e14 = new Employee();
				e14.LastName = "Mason";
				e14.FirstName = "Jack";
				e14.MiddleIntitial = "L";
				e14.Password = "rankmary";
				e14.SSN = 1112223232;
				e14.EmpType = "Employee";
				e14.Address = "444 45th St";
				e14.City = "Austin";
				e14.State = "TX";
				e14.ZipCode = 78701;
				e14.PhoneNumeber = 1748136441;
				e14.EmailAddress = "j.mason@bevosbooks.com";
				Employees.Add(e14);

				Employee e15 = new Employee();
				e15.LastName = "Miller";
				e15.FirstName = "Charles";
				e15.MiddleIntitial = "R";
				e15.Password = "kindly";
				e15.SSN = 353308615;
				e15.EmpType = "Employee";
				e15.Address = "8962 Main St.";
				e15.City = "Austin";
				e15.State = "TX";
				e15.ZipCode = 78709;
				e15.PhoneNumeber = 8999319585;
				e15.EmailAddress = "c.miller@bevosbooks.com";
				Employees.Add(e15);

				Employee e16 = new Employee();
				e16.LastName = "Nguyen";
				e16.FirstName = "Mary";
				e16.MiddleIntitial = "J";
				e16.Password = "ricearoni";
				e16.SSN = 7776665555;
				e16.EmpType = "Employee";
				e16.Address = "465 N. Bear Cub";
				e16.City = "Austin";
				e16.State = "TX";
				e16.ZipCode = 78734;
				e16.PhoneNumeber = 8716746381;
				e16.EmailAddress = "m.nguyen@bevosbooks.com";
				Employees.Add(e16);

				Employee e17 = new Employee();
				e17.LastName = "Rankin";
				e17.FirstName = "Suzie";
				e17.MiddleIntitial = "R";
				e17.Password = "walkamile";
				e17.SSN = 1911919111;
				e17.EmpType = "Employee";
				e17.Address = "23 Dewey Road";
				e17.City = "Austin";
				e17.State = "TX";
				e17.ZipCode = 78712;
				e17.PhoneNumeber = 5239029525;
				e17.EmailAddress = "s.rankin@bevosbooks.com";
				Employees.Add(e17);

				Employee e18 = new Employee();
				e18.LastName = "Rhodes";
				e18.FirstName = "Megan";
				e18.MiddleIntitial = "C";
				e18.Password = "ingram45";
				e18.SSN = 353904746;
				e18.EmpType = "Employee";
				e18.Address = "4587 Enfield Rd.";
				e18.City = "Austin";
				e18.State = "TX";
				e18.ZipCode = 78729;
				e18.PhoneNumeber = 1232139514;
				e18.EmailAddress = "m.rhodes@bevosbooks.com";
				Employees.Add(e18);

				Employee e19 = new Employee();
				e19.LastName = "Rice";
				e19.FirstName = "Eryn";
				e19.MiddleIntitial = "M";
				e19.Password = "arched";
				e19.SSN = 454776657;
				e19.EmpType = "Manager";
				e19.Address = "3405 Rio Grande";
				e19.City = "Austin";
				e19.State = "TX";
				e19.ZipCode = 78746;
				e19.PhoneNumeber = 2706602803;
				e19.EmailAddress = "e.rice@bevosbooks.com";
				Employees.Add(e19);

				Employee e20 = new Employee();
				e20.LastName = "Rogers";
				e20.FirstName = "Allen";
				e20.MiddleIntitial = "H";
				e20.Password = "lottery";
				e20.SSN = 700002943;
				e20.EmpType = "Manager";
				e20.Address = "4965 Oak Hill";
				e20.City = "Austin";
				e20.State = "TX";
				e20.ZipCode = 78705;
				e20.PhoneNumeber = 4139645586;
				e20.EmailAddress = "a.rogers@bevosbooks.com";
				Employees.Add(e20);

				Employee e21 = new Employee();
				e21.LastName = "Saunders";
				e21.FirstName = "Sarah";
				e21.MiddleIntitial = "M";
				e21.Password = "nostalgic";
				e21.SSN = 500987810;
				e21.EmpType = "Employee";
				e21.Address = "332 Avenue C";
				e21.City = "Austin";
				e21.State = "TX";
				e21.ZipCode = 78733;
				e21.PhoneNumeber = 9036349587;
				e21.EmailAddress = "s.saunders@bevosbooks.com";
				Employees.Add(e21);

				Employee e22 = new Employee();
				e22.LastName = "Sewell";
				e22.FirstName = "William";
				e22.MiddleIntitial = "G";
				e22.Password = "offbeat";
				e22.SSN = 500830084;
				e22.EmpType = "Manager";
				e22.Address = "2365 51st St.";
				e22.City = "Austin";
				e22.State = "TX";
				e22.ZipCode = 78755;
				e22.PhoneNumeber = 7224308314;
				e22.EmailAddress = "w.sewell@bevosbooks.com";
				Employees.Add(e22);

				Employee e23 = new Employee();
				e23.LastName = "Sheffield";
				e23.FirstName = "Martin";
				e23.MiddleIntitial = "J";
				e23.Password = "evanescent";
				e23.SSN = 223449167;
				e23.EmpType = "Employee";
				e23.Address = "3886 Avenue A";
				e23.City = "San Marcos";
				e23.State = "TX";
				e23.ZipCode = 78666;
				e23.PhoneNumeber = 9349192978;
				e23.EmailAddress = "m.sheffield@bevosbooks.com";
				Employees.Add(e23);

				Employee e24 = new Employee();
				e24.LastName = "Silva";
				e24.FirstName = "Cindy";
				e24.MiddleIntitial = "S";
				e24.Password = "stewboy";
				e24.SSN = 7776661111;
				e24.EmpType = "Employee";
				e24.Address = "900 4th St";
				e24.City = "Austin";
				e24.State = "TX";
				e24.ZipCode = 78758;
				e24.PhoneNumeber = 4874328170;
				e24.EmailAddress = "c.silva@bevosbooks.com";
				Employees.Add(e24);

				Employee e25 = new Employee();
				e25.LastName = "Stuart";
				e25.FirstName = "Eric";
				e25.MiddleIntitial = "F";
				e25.Password = "instrument";
				e25.SSN = 363998335;
				e25.EmpType = "Employee";
				e25.Address = "5576 Toro Ring";
				e25.City = "Austin";
				e25.State = "TX";
				e25.ZipCode = 78758;
				e25.PhoneNumeber = 1967846827;
				e25.EmailAddress = "e.stuart@bevosbooks.com";
				Employees.Add(e25);

				Employee e26 = new Employee();
				e26.LastName = "Tanner";
				e26.FirstName = "Jeremy";
				e26.MiddleIntitial = "S";
				e26.Password = "hecktour";
				e26.SSN = 904440929;
				e26.EmpType = "Employee";
				e26.Address = "4347 Almstead";
				e26.City = "Austin";
				e26.State = "TX";
				e26.ZipCode = 78712;
				e26.PhoneNumeber = 5923026779;
				e26.EmailAddress = "j.tanner@bevosbooks.com";
				Employees.Add(e26);

				Employee e27 = new Employee();
				e27.LastName = "Taylor";
				e27.FirstName = "Allison";
				e27.MiddleIntitial = "R";
				e27.Password = "countryrhodes";
				e27.SSN = 934778452;
				e27.EmpType = "Employee";
				e27.Address = "467 Nueces St.";
				e27.City = "Austin";
				e27.State = "TX";
				e27.ZipCode = 78727;
				e27.PhoneNumeber = 7246195827;
				e27.EmailAddress = "a.taylor@bevosbooks.com";
				Employees.Add(e27);

				Employee e28 = new Employee();
				e28.LastName = "Taylor";
				e28.FirstName = "Rachel";
				e28.MiddleIntitial = "O";
				e28.Password = "landus";
				e28.SSN = 393412631;
				e28.EmpType = "Manager";
				e28.Address = "345 Longview Dr.";
				e28.City = "Austin";
				e28.State = "TX";
				e28.ZipCode = 78746;
				e28.PhoneNumeber = 9071236087;
				e28.EmailAddress = "r.taylor@bevosbooks.com";
				Employees.Add(e28);

				//loop through employees
				foreach (Employee employee in Employees)
				{
					//set name of employee to help debug
					employeeSSN = employee.SSN;

					//see if employee exists in database
					Employee dbEmployee = db.Employees.FirstOrDefault(e => e.SSN == employee.SSN);

					if (dbEmployee == null) //employee does not exist in database
					{
						db.Employees.Add(employee);
						db.SaveChanges();
						intEmployeesAdded += 1;
					}
					else
					{
						dbEmployee.LastName = employee.LastName;
						dbEmployee.FirstName = employee.FirstName;
						dbEmployee.MiddleInitial = employee.MiddleInitial;
						dbEmployee.Password = employee.Password;
						dbEmployee.SSN = employee.SSN;
						dbEmployee.EmpType = employee.EmpType;
						dbEmployee.Address = employee.Address;
						dbEmployee.City = employee.City;
						dbEmployee.State = employee.State;
						dbEmployee.ZipCode = employee.ZipCode;
						dbEmployee.PhoneNumber = employee.PhoneNumber;
						dbEmployee.EmailAddress = employee.EmailAddress;
						db.Update(dbEmployee);
						db.SaveChanges();
					}
				}
			}
			catch
			{
				String msg = "Employees added:" + intEmployeesAdded + "; Error on " + employeeName;
				throw new InvalidOperationException(msg);
			}
		}
	}
}
