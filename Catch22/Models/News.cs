//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Catch22.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class News
    {
        public int NewsID { get; set; }
        public string NewsText { get; set; }
        public System.DateTime ExpirationDate { get; set; }
        public int UserID { get; set; }
    
        public virtual User User { get; set; }
    }
}
