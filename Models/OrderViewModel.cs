using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cobra_onboarding.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate{ get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public int PersonId { get; set; }
        public int ProductId { get; set; }      
        public int productDetailsId { get; set; }
      
          
    }
}