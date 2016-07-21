namespace ReqMVC.Models.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public request()
        {
            deviceinfos = new HashSet<deviceinfo>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(4096)]
        public string text { get; set; }

        public DateTime datecreated { get; set; }

        [StringLength(128)]
        public string number { get; set; }

        public DateTime? datesolved { get; set; }

        public int author_id { get; set; }

        public int post_id { get; set; }

        public int? ops_id { get; set; }

        [StringLength(512)]
        public string contact { get; set; }

        [Required]
        [StringLength(1024)]
        public string shorttext { get; set; }

        public bool? solved { get; set; }

        public int? solver_id { get; set; }

        [StringLength(128)]
        public string BF_NUMBER { get; set; }

        public int? status_id { get; set; }

        [StringLength(1024)]
        public string bf_comment { get; set; }

        public int? deviceinfo_id { get; set; }

        [StringLength(100)]
        public string inner_number { get; set; }

        public DateTime? act_date { get; set; }

        public int? service_id { get; set; }

        public virtual deviceinfo deviceinfo { get; set; }

        public virtual postoffice postoffice { get; set; }

        public virtual post post { get; set; }

        public virtual user user { get; set; }

        public virtual status status { get; set; }

        public virtual service service { get; set; }

        public virtual user user1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deviceinfo> deviceinfos { get; set; }
    }
}
