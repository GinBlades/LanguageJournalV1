using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanguageJournal.Services;
using LanguageJournal.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LanguageJournal.Controllers {
    [Route("api/[controller]")]
    public class UsersController : Controller {
        private readonly PostgresDbContext _db;
        private Authenticator _auth;

        public UsersController(PostgresDbContext context) {
            _db = context;
            _auth = new Authenticator(_db);
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get() {
            var authUser = _auth.AuthenticateHeaders(HttpContext);
            if (authUser != null) {
                return _db.Users.ToList();
            } else {
                return null;
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id) {
            var authUser = _auth.AuthenticateHeaders(HttpContext);
            if (authUser != null) {
                return _db.Users.Where(u => u.UserId == id).FirstOrDefault();
            } else {
                return null;
            }
        }

        // POST api/users
        [HttpPost]
        public User Post([FromBody]User user) {
            var authUser = _auth.AuthenticateHeaders(HttpContext);
            if (authUser != null) {
                _db.Users.Add(user);
                _db.SaveChanges();
                return user;
            } else {
                return null;
            }

        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody]User updatedUser) {
            var authUser = _auth.AuthenticateHeaders(HttpContext);
            if (authUser != null) {
                updatedUser.UserId = id;
                _db.Entry(updatedUser).State = EntityState.Modified;
                _db.SaveChanges();
                return updatedUser;
            } else {
                return null;
            }
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            var authUser = _auth.AuthenticateHeaders(HttpContext);
            if (authUser == null) {
                return;
            }
            var user = _db.Users.Where(u => u.UserId == id).FirstOrDefault();
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
