using WebApplication2.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;
//using Microsoft.Extensions.Configuration;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class customersRepository : IcustomersRepository
    {
        private SqlConnection con;

        //Constructor
        public customersRepository()
        {
            con = new SqlConnection(@"data source=TITMIT-PC\SQLEXPRESS;initial catalog=apox;user id=sa;password=1234;MultipleActiveResultSets=True;");
        }

        public void DeleteCustomer(int id)
        {
            con.Execute("DELETE FROM apox.Customers WHERE Id = @Id", new { id });
        }

        public List<customersModel> GetAllCustomers()
        {
            return con.Query<customersModel>("SELECT * FROM apox.Customers").ToList();
        }

        public customersModel GetCustomer(int id)
        {
            return con.Query<customersModel>("SELECT * FROM apox.Customers WHERE Id = @Id", new { id }).SingleOrDefault();
        }

        public customersModel GetFullCustomer(int id)
        {
            var sql =
            "SELECT * FROM apox.Customers WHERE Id = @Id; " +
            "SELECT * FROM apox.Orders WHERE CustomerId = @Id;";

    
            using (var multipleResults = this.con.QueryMultiple(sql, new { Id = id }))
            {
                var customers = multipleResults.Read<customersModel>().SingleOrDefault();

                var orders = multipleResults.Read<ordersModel>().ToList();

                if (customers != null && orders != null)
                {
                    customers.Orders.AddRange(orders);

                }
                return customers;
            }
        }

        public CustomerDropdownsModel GetCustomerDropdowns()
        {
            var sql =

            "SELECT * FROM apox.customerStatus; " +
            "SELECT * FROM apox.customerRating;";


            using (var multipleResults = this.con.QueryMultiple(sql))
            {

                var customerDropdown = new CustomerDropdownsModel();

                var status = multipleResults.Read<CustomerStatusModel>().ToList();
                var ratings = multipleResults.Read<CustomerRatingModel>().ToList();

                if (status != null && ratings != null)
                {
                    customerDropdown.CustomerRating.AddRange(ratings);
                    customerDropdown.CustomerStatus.AddRange(status);

                }
                return customerDropdown;
            }
        }

        public customersModel InsertCustomer(customersModel Customers)
        {
            var sql =
               "INSERT INTO apox.Customers (Vat,Email,FirstName,LastName,Phone,Address,StatusId,RatingId) VALUES(@Vat, @Email, @FirstName, @LastName,@Phone,@Address,@StatusId,@RatingId); " +
               "SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = con.Query<int>(sql, Customers).Single();
            Customers.Id = id;
            return Customers;
        }


        public customersModel UpdateCustomer(customersModel Customers)
        {
            var sql =
             "UPDATE apox.Customers " +
             "SET Vat = @Vat, " +
             "    Email     = @Email, " +
             "    FirstName = @FirstName, " +
             "    LastName  = @LastName, " +
             "    Phone     = @Phone, " +
             "    Address   = @Address, " +
             "    StatusId  = @StatusId, " +
             "    RatingId  = @RatingId "+         
             "WHERE Id = @Id";
            con.Execute(sql, Customers);
            return Customers;
        }
    }
}
