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
    
    public partial class AdviserCertificate
    {
        public System.Guid id { get; set; }
        public System.Guid adviserId { get; set; }
        public string certificateName { get; set; }
        public string certificateDescription { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<bool> activeFlag { get; set; }
    
        public virtual Adviser Adviser { get; set; }
    }
}
