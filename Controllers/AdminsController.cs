using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BitCoINCLLC.Controllers
{
    [Route ("api/Admins")]
    public class AdminsController : Controller
    {
        private readonly BitCoINCLLCContext _context;

        public AdminsController (BitCoINCLLCContext context)
        {
            _context = context;

            if (_context.Admins.Count () == 0)
            { 
            _context.Admins.Add (new Admin () { Id = 1, Name = "Harrison"});
            _context.Admins.Add (new Admin () { Id = 2, Name = "Billy"});
            _context.Admins.Add (new Admin () { Id = 3, Name = "Taylor"});

            _context.SaveChanges ();
            }

           
        }
        // GET api/values
        [HttpGet]
        public List<Admin> Get ()
        {
            return _context.Admins.ToList ();
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public Admin Get (int id)
        {
            foreach (Admin s in _context.Admins)
            {
                if (s.Id == id)
                {
                    return s;
                }
            }return null;

        } 

        // POST api/values
        [HttpPost]
        public Admin Post ([FromBody] Admin s)
        {
            _context.Admins.Add (s);
            _context.SaveChanges ();
            return s;
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public Admin Put (int id, [FromBody] Admin admin)
        {

            foreach (Admin s in _context.Admins)
            {
                if (s.Id == id)
                {
                    _context.Admins.Remove (s);
                    _context.SaveChanges ();
                    _context.Admins.Add (admin);
                    _context.SaveChanges ();
                    return admin;
                }
            }

            return null;
        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public string Delete (int id)
        {
            foreach (Admin s in _context.Admins)
            {
                if (s.Id == id)
                {
                    _context.Admins.Remove (s);
                    _context.SaveChanges ();
                    return "deleted";

                }
            }

            return "not found";
        }
    }
}