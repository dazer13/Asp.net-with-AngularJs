//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cobra_onboarding
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderHeader
    {
        public OrderHeader()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }
    
        public int OrderId { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int PersonId { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Person Person { get; set; }
    }
}
