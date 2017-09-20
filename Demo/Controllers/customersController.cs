using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.Controllers
{
    public class customersController : ApiController

    {
  
        private IcustomersRepository _repository;

        //public customersController(IcustomersRepository CustomersRepository)
        //{
        //    _repository = CustomersRepository;
        //}
        public customersController()
        {
            _repository = new customersRepository();
        }


        [Route("api/customers/GetAll")]
        public IHttpActionResult GetAll()
        {
            List<CustomersViewModel> customersView;
            try
            {
                var customers = _repository.GetAllCustomers();
                customersView = Mapper.Map<List<CustomersViewModel>>(customers);

            }
            catch(Exception ex)
            {
                return BadRequest();
            }
            return Ok(customersView);

        }

        [Route("api/customers/GetFull/{id}")]
        public IHttpActionResult GetFull(int id)
        {
            customersModel customer;

            try
            {
                customer = _repository.GetFullCustomer(id);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok(customer);

        }


        [Route("api/customers/GetDropdowns")]
        public IHttpActionResult GetDropdowns()
        {
            CustomerDropdownsModel CustomerDropdowns;
            try
            {
                CustomerDropdowns = _repository.GetCustomerDropdowns();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok(CustomerDropdowns);

        }

        [HttpPost, Route("api/Customers/CreateCustomer")]
        public IHttpActionResult CreateCustomer([FromBody]customersModel customer)
        {
            try
            {
                _repository.InsertCustomer(customer);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok(customer);
        }


        [HttpPut, Route("api/Customers/UpdateCustomer")]
        public IHttpActionResult UpdateCustomer([FromBody]customersModel customer)
        {
            try
            {
                _repository.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok(customer);
        }

        [HttpDelete, Route("api/Customers/DeleteCustomer/{id}")]
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                _repository.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok("Deleted");
        }




    }
}
