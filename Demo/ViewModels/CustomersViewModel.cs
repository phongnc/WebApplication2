using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class CustomersViewModel
    {
  
        public int Id { get; set; }
        public string Vat { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int StatusId { get; set; }
        public int RatingId { get; set; }


    }
}
