using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class CustomerDropdownsModel
    {

        public CustomerDropdownsModel()
        {
            CustomerRating = new List<CustomerRatingModel>();
            CustomerStatus = new List<CustomerStatusModel>();
        }


        public List<CustomerRatingModel> CustomerRating { get; set; }
        public List<CustomerStatusModel> CustomerStatus { get; set; }

    }
}
