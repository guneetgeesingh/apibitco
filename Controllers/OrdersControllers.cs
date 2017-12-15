using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BitCoINCLLC.Controllers
{
    [Route ("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly BitCoINCLLCContext _context;

        public OrdersController (BitCoINCLLCContext context)
        {
            _context = context;

            if (_context.Orders.Count () == 0)
            { 
            _context.Orders.Add (new Order () { Id = 1, Products = "The Orange Attack, Ocean Blue", InvoiceNumber = 7483928});
            _context.Orders.Add (new Order () { Id = 2, Products = "The Orange Attack, The Gold Rush", InvoiceNumber = 9040932});
            _context.Orders.Add (new Order () { Id = 3, Products = "The Gold Rush, Ocean Blue", InvoiceNumber = 8765490});

            _context.SaveChanges ();
            }

           
        }
        // GET api/values
        [HttpGet]
        public List<Order> Get ()
        {
            return _context.Orders.ToList ();
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public Order Get (int id)
        {
            foreach (Order s in _context.Orders)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }return null;

        } 

        // POST api/values
        [HttpPost]
        public Order Post ([FromBody] Order s)
        {
            _context.Orders.Add (s);
            _context.SaveChanges ();
            return s;
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public Order Put (int id, [FromBody] Order order)
        {

            foreach (Order s in _context.Orders)
            {
                if (s.Id == id)
                {
                    _context.Orders.Remove (s);
                    _context.SaveChanges ();
                    _context.Orders.Add (order);
                    _context.SaveChanges ();
                    return order;
                }
            }

            return null;
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public string Delete (int id)
        {
            foreach (Order s in _context.Orders)
            {
                if (s.Id == id)
                {
                    _context.Orders.Remove (s);
                    _context.SaveChanges ();
                    return "deleted";

                }
            }

            return "not found";
        }
    }
}