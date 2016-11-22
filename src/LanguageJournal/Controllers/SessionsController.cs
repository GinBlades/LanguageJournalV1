using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageJournal.Models;
using LanguageJournal.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LanguageJournal.Controllers {
    public class SessionsController : Controller {
        private readonly PostgresDbContext _db;

        public SessionsController(PostgresDbContext context) {
            _db = context;
        }

        [HttpPost]
        public Token SignIn([FromBody]Authenticator auth) {
            return auth.MakeToken();
        }

        [HttpDelete]
        public void SignOut(string authToken) {
            Authenticator auth = new Authenticator(_db);
            auth.SignOutWithToken(authToken);
        }
    }
}
