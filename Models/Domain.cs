namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Domain
    {
        public int DomainID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        public bool IsDelete { get; set; }
    }
}
