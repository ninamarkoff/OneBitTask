//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserApp.DBModels.DBModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gender
    {
        public Gender()
        {
            this.Users = new HashSet<User>();
        }
    
        public int GenderId { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<User> Users { get; set; }
    }
}
