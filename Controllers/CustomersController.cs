using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BitCoINCLLC.Controllers
{
    [Route ("api/Customers")]
    public class CustomersController : Controller
    {
        private readonly BitCoINCLLCContext _context;

        public CustomersController (BitCoINCLLCContext context)
        {
            _context = context;

            if (_context.Customers.Count () == 0)
            { 
            _context.Customers.Add (new Customer () { Id = 1, Name = "Walmart", IsBulk = true});
            _context.Customers.Add (new Customer () { Id = 2, Name = "Bob's Liquor", IsBulk = false});
            _context.Customers.Add (new Customer () { Id = 3, Name = "SexyFidgetySpinners.com", IsBulk = true});

            _context.SaveChanges ();
            }

           
        }
        // GET api/values
        [HttpGet]
        public List<Customer> Get ()
        {
            return _context.Customers.ToList ();
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public Customer Get (int id)
        {
            foreach (Customer s in _context.Customers)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }return null;

        } 

        // POST api/values
        [HttpPost]
        public Customer Post ([FromBody] Customer s)
        {
            _context.Customers.Add (s);
            _context.SaveChanges ();
            return s;
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public Customer Put (int id, [FromBody] Customer customer)
        {

            foreach (Customer s in _context.Customers)
            {
                if (s.Id == id)
                {
                    _context.Customers.Remove (s);
                    _context.SaveChanges ();
                    _context.Customers.Add (customer);
                    _context.SaveChanges ();
                    return customer;
                }
            }

            return null;
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public string Delete (int id)
        {
            foreach (Customer s in _context.Customers)
            {
                if (s.Id == id)
                {
                    _context.Customers.Remove (s);
                    _context.SaveChanges ();
                    return "deleted";

                }
            }

            return "not found";
        }
    }
}