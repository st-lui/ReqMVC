namespace ReqMVC.Models.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class postoffice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public postoffice()
        {
            deviceinfos = new HashSet<deviceinfo>();
            requests = new HashSet<request>();
        }

        public int? idx_au { get; set; }

        [StringLength(255)]
        public string name_au { get; set; }

        public int? idx_post { get; set; }

        [StringLength(255)]
        public string name_post { get; set; }

        public int idx { get; set; }

        [StringLength(255)]
        public string name_ops { get; set; }

        [StringLength(255)]
        public string closed { get; set; }

        public double? house_num { get; set; }

        public double? house_d { get; set; }

        public double? corpus { get; set; }

        [StringLength(255)]
        public string litera { get; set; }

        [StringLength(255)]
        public string street { get; set; }

        [StringLength(255)]
        public string house_name { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        public double? house { get; set; }

        [StringLength(255)]
        public string region { get; set; }

        [StringLength(255)]
        public string subj { get; set; }

        [StringLength(255)]
        public string type_city { get; set; }

        [StringLength(255)]
        public string street_type { get; set; }

        [StringLength(255)]
        public string code_city { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [StringLength(255)]
        public string script { get; set; }

        [StringLength(255)]
        public string location { get; set; }

        public int id { get; set; }

        [Column("class")]
        public int? _class { get; set; }

        public bool? channel { get; set; }

        [StringLength(128)]
        public string active_name { get; set; }

        [StringLength(50)]
        public string priority { get; set; }

        public int? cash_count { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deviceinfo> deviceinfos { get; set; }

        public virtual post post { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<request> requests { get; set; }
    }
}
