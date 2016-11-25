using LanguageJournal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageJournal.Filters {
    public class AuthenticationFilterAttribute : ActionFilterAttribute {
        private readonly PostgresDbContext _db;
        private Authenticator _auth;

        public AuthenticationFilterAttribute(PostgresDbContext db) {
            _db = db;
            _auth = new Authenticator(_db);
        }

        public override void OnActionExecuting(ActionExecutingContext context) {
            StringValues tokenValues;
            if (context.HttpContext.Request.Headers.TryGetValue("Token", out tokenValues)) {
                context.RouteData.Values.Add("User", _auth.AuthenticateByToken(tokenValues.FirstOrDefault()));
            } else {
                context.Result = new ContentResult {
                    StatusCode = 402,
                    Content = "Failed Token Authentication"
                };
            }
            // context.RouteData.Values.Add("User", user);
            base.OnActionExecuting(context);
        }
    }
}
