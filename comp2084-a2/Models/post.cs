//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace comp2084_a2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class post
    {
        public int id { get; set; }
        public string message { get; set; }
        public int user_id { get; set; }
        public int dislike_count { get; set; }
        public string post_by { get; set; }
    
        public virtual user user { get; set; }
    }
}
