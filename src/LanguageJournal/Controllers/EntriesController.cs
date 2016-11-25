using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageJournal.Services;
using LanguageJournal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.Extensions.Primitives;
using LanguageJournal.Filters;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LanguageJournal.Controllers {
    [Route("api/[controller]"), ServiceFilter(typeof(AuthenticationFilterAttribute))]
    public class EntriesController : Controller {
        private readonly PostgresDbContext _db;
        private Authenticator _auth;

        public EntriesController(PostgresDbContext context) {
            _db = context;
            _auth = new Authenticator(_db);
        }

        // GET api/entries
        [HttpGet]
        public IEnumerable<Entry> Get() {
            return _db.Entries.ToList();
        }

        // GET api/entries/5
        [HttpGet("{id}")]
        public Entry Get(int id) {
            return _db.Entries.Where(e => e.EntryId == id).FirstOrDefault();
        }

        // POST api/entries
        [HttpPost]
        public Entry Post([FromBody]Entry entry) {
            _db.Entries.Add(entry);
            _db.SaveChanges();
            return entry;

        }

        // PUT api/entries/5
        [HttpPut("{id}")]
        public Entry Put(int id, [FromBody]Entry entry) {
            entry.EntryId = id;
            _db.Entry(entry).State = EntityState.Modified;
            _db.SaveChanges();
            return entry;
        }

        // DELETE api/entries/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            var entry = _db.Entries.Where(e => e.EntryId == id).FirstOrDefault();
            _db.Entries.Remove(entry);
            _db.SaveChanges();
        }
    }
}
