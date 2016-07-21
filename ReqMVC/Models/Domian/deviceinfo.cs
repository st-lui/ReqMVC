namespace ReqMVC.Models.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("deviceinfos")]
    public partial class deviceinfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public deviceinfo()
        {
            requests = new HashSet<request>();
            requests1 = new HashSet<request>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(512)]
        public string model { get; set; }

        [Required]
        [StringLength(128)]
        public string serial_number { get; set; }

        public int? ops_id { get; set; }

        public int? ops_idx { get; set; }

        [StringLength(128)]
        public string type { get; set; }

        [StringLength(128)]
        public string mfr { get; set; }

        [StringLength(128)]
        public string parent_active { get; set; }

        [StringLength(128)]
        public string active { get; set; }

        public bool? servicing { get; set; }

        public int? devicetype_id { get; set; }

        public virtual postoffice postoffice { get; set; }

        public virtual devicetype devicetype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests1 { get; set; }
    }
}
