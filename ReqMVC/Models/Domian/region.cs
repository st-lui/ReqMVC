namespace ReqMVC.Models.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class region
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public region()
        {
            posts = new HashSet<post>();
        }

        public int id { get; set; }

        [StringLength(10)]
        public string number { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        public int timezone { get; set; }

        public double? region_coeff { get; set; }

        public double? equip_coeff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<post> posts { get; set; }
    }
}
