using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Dapper;

namespace BasicAuth.Handlers
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            try
            {

                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);

                if (!string.Equals(authHeader.Scheme, "Basic", StringComparison.OrdinalIgnoreCase))
                {
                    return AuthenticateResult.Fail("Invalid Authorization Scheme");
                }


                var credentialBytes = Convert.FromBase64String(authHeader.Parameter ?? string.Empty);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);

                if (credentials.Length != 2)
                {
                    return AuthenticateResult.Fail("Invalid Authorization Header Format");
                }

                var username = credentials[0];
                var password = credentials[1];

                IEnumerable<string> roles;
                using (SqlConnection db = new SqlConnection(""))
                {
                    roles = db.Query<string>("select r.name from user u " +
                                            "join user_role ur on u.id = ur.user_id " +
                                            "join role r on r.id = ur.role_id " +
                                            $"where u.login = {username} and u.psw = {password} ");
                }
                if (username == "admin" && password == "admin")
                {
                    roles = new[] { "Admin", "User" }; // Администратор имеет обе роли
                }
                else if (username == "user" && password == "user")
                {
                    roles = new[] { "User" }; // Обычный пользователь
                }
                else
                {
                    return AuthenticateResult.Fail("Invalid Username or Password");
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, username)
                };

                // Добавляем каждую роль отдельным клеймом
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }


                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
        }
    }
}

