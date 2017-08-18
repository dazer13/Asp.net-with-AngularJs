
using Cobra_onboarding.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cobra_onboarding.Controllers
{
	public class OrderController : Controller
	{
		private Cobra db = new Cobra();
		// GET: /Order/
		public ActionResult Index()
		{
			return View();
		}
		//Get Orders
		public ActionResult Orders() {


			var data =
		from pd in db.OrderHeaders
		join p in db.OrderDetails on pd.OrderId equals p.OrderId
		join per in db.People on pd.PersonId equals per.Id
		join pro in db.Products on p.ProductId equals pro.Id

		select new { 

		  Id=pd.OrderId,
		  Name=per.Name,
		  OrderDate=pd.OrderDate,
		  ProductName=pro.ProductName,
		  Price=pro.Price,
		  cusId=pd.PersonId,
		  proId=p.ProductId,
		  productDetailsId=p.Id



		
		};

			var orders = data.ToList().Select(o=>new { 
			
			 Id=o.Id,
			 Name=o.Name,
			 OrderDate=o.OrderDate.ToString("yyyy-MM-dd"),
			 ProductName=o.ProductName,
			 Price=o.Price,
			 PersonId=o.cusId,
			 ProductId=o.proId,
			 productDetailsId=o.productDetailsId
			
			
			});


			return Json(orders,JsonRequestBehavior.AllowGet);
		
		
		}


		//Add Customers
		/*public string AddCustomer(OrderHeader Emp)
		{
			if (Emp != null)
			{
				
				  db.OrderHeaders.Add(Emp);
					db.SaveChanges();
					return "Customer Added";
				
			}
			else
			{
				return "errror";
			}
		}*/


		//Get Peoples
		public ActionResult People()
		{

			var people = db.People.Select(p => new { p.Id, p.Name, p.Address1, p.Address2, p.City }).ToList();
			return Json(people, JsonRequestBehavior.AllowGet);

		}

	   
		//Get Products
		public ActionResult Products()
		{

			var products = db.Products.Select(p => new { p.Id, p.ProductName,p.Price }).ToList();
			return Json(products, JsonRequestBehavior.AllowGet);

		}
		//Delete Order 

		public Boolean DeleteOrder(OrderViewModel ord)
		{
			
				using (Cobra db = new Cobra())
				{

					var model2 = db.OrderDetails.SingleOrDefault(x => x.Id == ord.productDetailsId);

					model2.OrderId = ord.Id;
					model2.ProductId = ord.ProductId;
						db.Entry(model2).State = System.Data.Entity.EntityState.Detached;
						db.OrderDetails.Attach(model2);
						db.OrderDetails.Remove(model2);
						db.SaveChanges();

						try
						{
							var model = db.OrderHeaders.SingleOrDefault(x => x.OrderId == ord.Id);
							model.OrderDate = ord.OrderDate;
							model.PersonId = ord.PersonId;
							db.Entry(model).State = System.Data.Entity.EntityState.Detached;
							db.OrderHeaders.Attach(model);
							db.OrderHeaders.Remove(model);
							db.SaveChanges();
						}catch(Exception e){
							return false;
						
						}

				}

						  return true;
			
			
		}

		
		//Update Order
		public Boolean upOrder(OrderViewModel ord)
		{
			
				using (Cobra Obj = new Cobra())
				{



					var model = Obj.OrderHeaders.SingleOrDefault(x => x.OrderId == ord.OrderId);
					model.OrderDate = ord.OrderDate;
					model.PersonId = ord.PersonId;
						
					Obj.Entry(model).State = EntityState.Modified;

						Obj.SaveChanges();

						var model2 = Obj.OrderDetails.SingleOrDefault(x => x.Id == ord.Id);
						model2.OrderId = ord.OrderId;
						model2.ProductId = ord.ProductId;
						Obj.Entry(model2).State = EntityState.Modified;
						Obj.SaveChanges();
					
					   return true;

					
				}

				
			
		}
		
		//Add Order
		public Boolean AddOrderDetails(OrderViewModel ord)
		{	
	
			using(var db = new Cobra()){


				try
				{
					var orderHeader = new OrderHeader
					{

						OrderDate = ord.OrderDate,
						PersonId = ord.PersonId,

					};
					db.OrderHeaders.Add(orderHeader);
					db.SaveChanges();

					var orderDetail = new OrderDetail
					{

						OrderId = orderHeader.OrderId,
						ProductId = ord.ProductId

					};

					db.OrderDetails.Add(orderDetail);
					db.SaveChanges();


				}
				catch (Exception) {
					return false;
				}

				
			}
			
			return true;
		}



	}
}