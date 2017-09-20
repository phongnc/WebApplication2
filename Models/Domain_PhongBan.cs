namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Domain_PhongBan
    {
        [Key]
        public int DomainPhongBanID { get; set; }

        public int DomainID { get; set; }

        public int ParentID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(1024)]
        public string LienHe { get; set; }

        public bool IsDelete { get; set; }

        [StringLength(10)]
        public string PhongBanCode { get; set; }

        [StringLength(250)]
        public string PhongBanDescription { get; set; }
    }
}
