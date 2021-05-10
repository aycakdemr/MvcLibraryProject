//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookRecords
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookRecords()
        {
            this.LateFees = new HashSet<LateFees>();
        }
    
        public int Id { get; set; }
        public Nullable<int> BookId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> StaffId { get; set; }
        public Nullable<System.DateTime> BuyingDate { get; set; }
        public Nullable<System.DateTime> GivingDate { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Members Members { get; set; }
        public virtual Staffs Staffs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LateFees> LateFees { get; set; }
    }
}
