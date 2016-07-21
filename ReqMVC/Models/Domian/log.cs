namespace ReqMVC.Models.Domian
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class log
    {
        public int id { get; set; }

        public string txt { get; set; }

        public DateTime? insert_time { get; set; }
    }
}
