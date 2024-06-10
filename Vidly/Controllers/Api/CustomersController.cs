using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;  
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        VidlyDbContext _context;

        public CustomersController()
        {
            _context = new VidlyDbContext();
        }

        // GET api/customers
        public IEnumerable<Customer> Get()
        {
            var customers = _context.Customers.ToList();

            return customers;
        }

        // GET api/customers/5
        public Customer Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return customer;
        }

        // POST api/customers
        public void Post([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        // PUT api/customers/5
        public void Put(int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.SaveChanges();
        }

        // DELETE api/customers/5
        public void Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}