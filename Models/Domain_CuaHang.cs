namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Domain_CuaHang
    {
        [Key]
        public int DomainCuaHangID { get; set; }

        public int DomainID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Description1 { get; set; }

        [StringLength(50)]
        public string Description2 { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        public int? Tinh { get; set; }

        public int? Huyen { get; set; }

        public int? Xa { get; set; }

        public int? Duong { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        public bool IsDelete { get; set; }
    }
}
