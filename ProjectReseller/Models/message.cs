//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectReseller.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public message()
        {
            this.message_recipient = new HashSet<message_recipient>();
        }
    
        public int id { get; set; }
        public int users_id { get; set; }
        public string content { get; set; }
        public Nullable<System.DateTime> time { get; set; }
    
        public virtual users users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<message_recipient> message_recipient { get; set; }
    }
}
