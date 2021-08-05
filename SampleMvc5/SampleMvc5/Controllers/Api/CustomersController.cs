using AutoMapper;
using SampleMvc5.App_Start;
using SampleMvc5.Dtos;
using SampleMvc5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SampleMvc5.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper mapper;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
            mapper = AutoMapperConfig.Mapper;
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _dbContext.Customers.ToList();
            //var customers = new List<CustomerDto>
            //{
            //    new CustomerDto{Id=1,Name = "John Rambo"},
            //    new CustomerDto{Id=2,Name = "Robert Downey" },
            //    new CustomerDto{Id=3,Name = "Tom Cruise" },
            //};
            return mapper.Map<List<CustomerDto>>(customers);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // TODO: use Mapping
            var customer = new Customer
            {
                Name = customerDto.Name,
                BirthDate = customerDto.BirthDate,
                MembershipTypeId = customerDto.MembershipTypeId,
                IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter
            };
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var existingCustomer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if (existingCustomer == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }
            // validate customerDto

            // TODO :use Mapping
            existingCustomer.Name = customerDto.Name;
            //
            _dbContext.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var existingCustomer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if (existingCustomer == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            _dbContext.Customers.Remove(existingCustomer);
            _dbContext.SaveChanges();
        }
    }
}