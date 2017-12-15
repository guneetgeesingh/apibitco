using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BitCoINCLLC.Controllers
{
    [Route ("api/Spinners")]
    public class SpinnersController : Controller
    {
        private readonly BitCoINCLLCContext _context;

        public SpinnersController (BitCoINCLLCContext context)
        {
            _context = context;

            if (_context.Spinners.Count () == 0)
            { 
            _context.Spinners.Add (new Spinner () { Id = 1, Name = "The Orange Attack", Color = "Blood Orange", Price = "$20.99" });
            _context.Spinners.Add (new Spinner () { Id = 2, Name = "The Gold Rush", Color = "Gold", Price = "$21.99" });
            _context.Spinners.Add (new Spinner () { Id = 3, Name = "Ocean Blue", Color = "Sky Blue", Price = "$15.99" });

            _context.SaveChanges ();
            }

           
        }
        // GET api/values
        [HttpGet]
        public List<Spinner> Get ()
        {
            return _context.Spinners.ToList ();
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public Spinner Get (int id)
        {
            foreach (Spinner s in _context.Spinners)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }return null;

        } 

        // POST api/values
        [HttpPost]
        public Spinner Post ([FromBody] Spinner s)
        {
            _context.Spinners.Add (s);
            _context.SaveChanges ();
            return s;
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public Spinner Put (int id, [FromBody] Spinner spinner)
        {

            foreach (Spinner s in _context.Spinners)
            {
                if (s.Id == id)
                {
                    _context.Spinners.Remove (s);
                    _context.SaveChanges ();
                    _context.Spinners.Add (spinner);
                    _context.SaveChanges ();
                    return spinner;
                }
            }

            return null;
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public string Delete (int id)
        {
            foreach (Spinner s in _context.Spinners)
            {
                if (s.Id == id)
                {
                    _context.Spinners.Remove (s);
                    _context.SaveChanges ();
                    return "deleted";

                }
            }

            return "not found";
        }
    }
}