using LanguageJournal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LanguageJournal.Services {
    public class Authenticator : SigninUser {
        private readonly PostgresDbContext _db;
        
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
            // Use 'AsNoTracking' so it does not interfere with other User queries
            // https://jessedotnet.com/2016/03/17/entity-framework-7-solve-you-large-dataset-performance-issues-with-asnotracking/
            User = _db.Tokens.AsNoTracking().Include(t => t.User).FirstOrDefault(t => t.Value == tokenValue)?.User;
            return User;
        }

        public Token MakeToken() {
            if (AuthenticateByLogin() != null) {

                // https://msdn.microsoft.com/en-us/library/system.guid.newguid(v=vs.110).aspx
                var token = new Token { User = User, Value = Guid.NewGuid().ToString() };
                _db.Tokens.Add(token);
                _db.SaveChanges();
                return token;
            }
            return null;
        }

        public void SignOutWithToken(string tokenValue) {
            Token token = _db.Tokens.FirstOrDefault(t => t.Value == tokenValue);
            _db.Tokens.Remove(token);
            _db.SaveChanges();
        }
    }
}
