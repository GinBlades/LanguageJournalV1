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

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LanguageJournal.Controllers {
    [Route("api/[controller]")]
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
            return _auth.AuthenticateWithResult<IEnumerable<Entry>>(HttpContext, _db.Entries.ToList());
        }

        // GET api/entries/5
        [HttpGet("{id}")]
        public Entry Get(int id) {
            return _auth.AuthenticateWithResult<Entry>(HttpContext, _db.Entries.Where(e => e.EntryId == id).FirstOrDefault());
        }

        // POST api/entries
        [HttpPost]
        public Entry Post([FromBody]Entry entry) {
            var user = _auth.AuthenticateHeaders(HttpContext);
            if (user != null) {
                _db.Entries.Add(entry);
                _db.SaveChanges();
                return entry;
            } else {
                return null;
            }

        }

        // PUT api/entries/5
        [HttpPut("{id}")]
        public Entry Put(int id, [FromBody]Entry entry) {
            var user = _auth.AuthenticateHeaders(HttpContext);
            if (user != null) {
                entry.EntryId = id;
                _db.Entry(entry).State = EntityState.Modified;
                _db.SaveChanges();
                return entry;
            } else {
                return null;
            }
        }

        // DELETE api/entries/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            var user = _auth.AuthenticateHeaders(HttpContext);
            if (user == null) {
                return;
            }
            var entry = _db.Entries.Where(e => e.EntryId == id).FirstOrDefault();
            _db.Entries.Remove(entry);
            _db.SaveChanges();
        }
    }
}
