namespace ReqMVC.Models.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            requests = new HashSet<request>();
            requests1 = new HashSet<request>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public int post_id { get; set; }

        [Required]
        [StringLength(50)]
        public string password { get; set; }

        public bool? supervisor { get; set; }

        [StringLength(256)]
        public string contact { get; set; }

        public bool? newsredirect { get; set; }

        public bool multirequest { get; set; }

        public bool? ops_supervisor { get; set; }

        public virtual post post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests1 { get; set; }
    }
}
