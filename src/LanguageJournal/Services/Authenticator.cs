using LanguageJournal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Services {
    public class Authenticator {
        private readonly PostgresDbContext _db;

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User User { get; set; }

        public Authenticator(PostgresDbContext context) {
            _db = context;
        }

        public User AuthenticateByLogin() {
            User = _db.Users.FirstOrDefault(u => u.Username == Username || u.Email == Email);
            if (User.Password == Password) {
                return User;
            }
            return null;
        }

        public User AuthenticateByToken(string tokenValue) {
            User = _db.Tokens.FirstOrDefault(t => t.Value == tokenValue)?.User;
            return User;
        }

        public Token MakeToken() {
            if (AuthenticateByLogin() != null) {
                var token = new Token { User = User, Value = new Guid().ToString() };
                return token;
            }
            return null;
        }

        public void SignOutWithToken(string tokenValue) {
            Token token = _db.Tokens.FirstOrDefault(t => t.Value == tokenValue);
            _db.Tokens.Remove(token);
            _db.SaveChanges();
        }

        public User AuthenticateHeaders(HttpContext httpContext) {
            StringValues tokenValues;
            if (httpContext.Request.Headers.TryGetValue("Token", out tokenValues)) {
                return AuthenticateByToken(tokenValues.FirstOrDefault());
            } else {
                return null;
            }
        }

        public T AuthenticateWithResult<T>(HttpContext httpContext, T result) {
            var user = AuthenticateHeaders(httpContext);
            if (user != null) {
                return result;
            } else {
                return default(T);
            }
        }
    }
}
