using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageJournal.Models;
using LanguageJournal.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace LanguageJournal.Controllers {
    [Route("api/[controller]")]
    public class SessionsController : Controller {
        private readonly PostgresDbContext _db;

        public SessionsController(PostgresDbContext context) {
            _db = context;
        }

        [Route("signin")]
        [HttpPost]
        public object SignIn([FromBody]SigninUser user) {
            var auth = new Authenticator(_db) { Username = user.Username, Email = user.Email, Password = user.Password };
            return new { Token = auth.MakeToken()?.Value };
        }

        [HttpDelete]
        public void SignOut(string authToken) {
            var auth = new Authenticator(_db);
            auth.SignOutWithToken(authToken);
        }
    }
}
