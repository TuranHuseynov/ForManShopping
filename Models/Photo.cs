//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YeniShoppingProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Photo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Photo()
        {
            this.Companies = new HashSet<Company>();
            this.OthBxoes = new HashSet<OthBxo>();
        }
    
        public int photo_id { get; set; }
        public string photo_name { get; set; }
        public Nullable<int> photo_product_id { get; set; }
        public Nullable<int> photo_color_id { get; set; }
        public Nullable<int> photo_type_id { get; set; }
    
        public virtual Color Color { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Companies { get; set; }
        public virtual Mallar Mallar { get; set; }
        public virtual PhotoType PhotoType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OthBxo> OthBxoes { get; set; }
    }
}
