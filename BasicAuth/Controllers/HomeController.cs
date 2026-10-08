using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class HomeController : ControllerBase
    {
        [HttpGet, Route("SayHelloAdmin")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult SayHelloAdmin(string name = "World")
        {
            return Ok($"Hello {name}!");
        }

        [HttpGet, Route("SayHelloUser")]
        [Authorize(Roles = "USER")]
        public ActionResult SayHelloUser(string name = "World")
        {
            return Ok($"Hello {name}!");
        }

        [HttpGet, Route("SayHelloAll")]
        [Authorize]
        public ActionResult SayHelloAll(string name = "World")
        {
            return Ok($"Hello {name}!");
        }

        [HttpGet, Route("SayHelloAnonymous")]
        [AllowAnonymous]
        public ActionResult SayHelloAnonymous(string name = "World")
        {
            return Ok($"Hello {name}!");
        }
    }
}


/*
 create table [User]
(
	id int primary key identity,
	login varchar(200),
	psw nvarchar(200)
)

insert into [User] (login, psw)
values ('admin', 'admin'),
('user', 'user'),
('audit', 'audit')


create table [Role]
(
	id int primary key identity,
	name varchar(200)
)

insert into [Role] (name)
values ('ADMIN'),
('USER'),
('AUDIT')

create table User_Role
(
	[user_id] int,
	[role_id] int
)

insert into User_Role ([user_id], [role_id])
values (3,3)


select r.name from [user] u 
join user_role ur on u.id = ur.[user_id]
join role r on r.id = ur.role_id
where u.login = 'audit' and u.psw = 'audit'
 
 */