namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Domain_ChucDanh
    {
        [Key]
        public int DomainChucDanhID { get; set; }

        public int DomainPhongBanID { get; set; }

        public int DomainID { get; set; }

        public int ParentID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public bool IsDelete { get; set; }
    }
}
