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

        public UsersController(PostgresDbContext context) {
            _db = context;
        }

        // GET api/users
        [HttpGet]
        public IEnumerable<User> Get() {
            return _db.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public User Get(int id) {
            return _db.Users.Where(u => u.UserId == id).FirstOrDefault();
        }

        // POST api/users
        [HttpPost]
        public User Post([FromBody]User user) {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;

        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody]User user) {
            user.UserId = id;
            _db.Entry(user).State = EntityState.Modified;
            _db.SaveChanges();
            return user;
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            var user = _db.Users.Where(u => u.UserId == id).FirstOrDefault();
            _db.Users.Remove(user);
            _db.SaveChanges();
        }
    }
}
