using Cobra_onboarding.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cobra_onboarding.Controllers
{
	public class PersonController : Controller
	{
		private Cobra _context = new Cobra();
		// GET: /Person/
		public ActionResult Index()
		{
			return View();
		}

		//Get People
		public ActionResult person()
		{
			
				var people = _context.People.Select(p => new {p.Id, p.Name, p.Address1, p.Address2, p.City }).ToList();
				return Json(people,JsonRequestBehavior.AllowGet);
			
		}


		//Add people
		public Boolean InsertPeople(PersonViewModel person)
		{


			var people = new Person { 
			  
			  Name=person.Name,
			  Address1=person.Address1,
			  Address2=person.Address2,
			  City=person.City
			 
			
			};
			if (people != null)
			{

				_context.People.Add(people);
				_context.SaveChanges();
					return true;
				
			}
			else
			{
				return false;
			}
		}

		//Update People
		public Boolean UpdatePerson(PersonViewModel person)
		{
			var people = new Person
			{
				Id=person.Id,
				Name = person.Name,
				Address1 = person.Address1,
				Address2 = person.Address2,
				City = person.City

			};


			if (people != null)
			{
				using (Cobra Obj = new Cobra())
				{
					var emp = Obj.Entry(people);
					var result = Obj.People.Where(x => x.Id == person.Id).FirstOrDefault();
					result.Name = person.Name;
					result.Address1 = person.Address1;
					result.Address2 = person.Address2;
					result.City = person.City;
					Obj.SaveChanges();
					return true;
				}
			}
			else
			{
				return false;
			}
		}

		//Delete People
		public Boolean DeletePerson(PersonViewModel person)
		{

			var people = new Person
			{
				Id = person.Id,
				Name = person.Name,
				Address1 = person.Address1,
				Address2 = person.Address2,
				City = person.City


			};

			try
			{
				if (person != null)
				{

					var emp = _context.Entry(people);
					if (emp.State == System.Data.Entity.EntityState.Detached)
					{
						_context.People.Attach(people);
						_context.People.Remove(people);
						_context.SaveChanges();
					}

					return true;

				}
				else
				{
					return false;
				}

			}
			catch (Exception e)
			{
				return false;
			}
		}



		/*public string DeletePerson(OrderViewModel o,PersonViewModel p) {

			using (Cobra db = new Cobra())
			{

				var model2 = db.OrderDetails.SingleOrDefault(x => x.Id == o.productDetailsId);

				model2.OrderId = o.Id;
				model2.ProductId = o.ProductId;
				db.Entry(model2).State = System.Data.Entity.EntityState.Detached;
				db.OrderDetails.Attach(model2);
				db.OrderDetails.Remove(model2);
				db.SaveChanges();

				try
				{
					var model = db.OrderHeaders.SingleOrDefault(x => x.OrderId == o.Id);
					model.OrderDate = o.OrderDate;
					model.PersonId = o.PersonId;
					db.Entry(model).State = System.Data.Entity.EntityState.Detached;
					db.OrderHeaders.Attach(model);
					db.OrderHeaders.Remove(model);
					db.SaveChanges();


					var model3=db.People.SingleOrDefault(x=>x.Id==p.Id);
					model3.Name = p.Name;
					model3.Address1 = p.Address1;
					model3.Address2 = p.Address2;
					model3.City = p.City;
					db.Entry(model3).State = System.Data.Entity.EntityState.Detached;
					db.People.Attach(model3);
					db.People.Remove(model3);
					db.SaveChanges();
				}
				catch (Exception e)
				{
					return "Order Details Deleted Successfully!";

				}

			}




			return "";
		
		}*/
	}
}