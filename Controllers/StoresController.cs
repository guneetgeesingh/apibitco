using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BitCoINCLLC.Controllers
{
    [Route ("api/Stores")]
    public class StoresController : Controller
    {
        private readonly BitCoINCLLCContext _context;

        public StoresController (BitCoINCLLCContext context)
        {
            _context = context;

            if (_context.Stores.Count () == 0)
            { 
            _context.Stores.Add (new Store () { Id = 1, LocationNumber = 432, District = "NorthEast"});
            _context.Stores.Add (new Store () { Id = 2, LocationNumber = 244, District = "Southwest"});
            _context.Stores.Add (new Store () { Id = 3, LocationNumber = 743, District = "Pacific"});

            _context.SaveChanges ();
            }

           
        }
        // GET api/values
        [HttpGet]
        public List<Store> Get ()
        {
            return _context.Stores.ToList ();
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public Store Get (int id)
        {
            foreach (Store s in _context.Stores)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }return null;

        } 

        // POST api/values
        [HttpPost]
        public Store Post ([FromBody] Store s)
        {
            _context.Stores.Add (s);
            _context.SaveChanges ();
            return s;
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public Store Put (int id, [FromBody] Store Store)
        {

            foreach (Store s in _context.Stores)
            {
                if (s.Id == id)
                {
                    _context.Stores.Remove (s);
                    _context.SaveChanges ();
                    _context.Stores.Add (Store);
                    _context.SaveChanges ();
                    return Store;
                }
            }

            return null;
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public string Delete (int id)
        {
            foreach (Store s in _context.Stores)
            {
                if (s.Id == id)
                {
                    _context.Stores.Remove (s);
                    _context.SaveChanges ();
                    return "deleted";

                }
            }

            return "not found";
        }
    }
}