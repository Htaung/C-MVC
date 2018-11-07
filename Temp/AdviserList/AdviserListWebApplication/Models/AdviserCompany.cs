//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdviserListWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdviserCompany
    {
        public System.Guid id { get; set; }
        public System.Guid adviserId { get; set; }
        public System.Guid companyId { get; set; }
        public string designation { get; set; }
        public string contactNumber { get; set; }
        public string email { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> primaryFlag { get; set; }
        public Nullable<bool> activeFlag { get; set; }
    
        public virtual Adviser Adviser { get; set; }
        public virtual Company Company { get; set; }
    }
}