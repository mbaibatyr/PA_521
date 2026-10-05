using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyPagination.Abstract;
using MyPagination.Model;

namespace MyPagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUser service;
        public UserController(IUser service) 
        { 
            this.service = service;
        }
        [HttpGet, Route("GetUsers")]
        public async Task<ActionResult> GetUsersAsync(int page = 1, int pageSize = 20)
        {
            var result =  await service.GetUsersAsync(page, pageSize);
            return Ok(result);
        }
    }
}

/*
 
 CREATE TABLE [dbo].[User] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [created]    DATETIME       DEFAULT (getdate()) NULL,
    [last_name]  NVARCHAR (200) NULL,
    [first_name] NVARCHAR (200) NULL,
    [date_birth] DATETIME       NULL,
    [email]      VARCHAR (200)  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);



CREATE   PROCEDURE GetUsers
    @PageNumber INT = 1,
    @PageSize INT = 10
AS
BEGIN
    SET NOCOUNT ON;
    IF @PageNumber < 1
        SET @PageNumber = 1;
    IF @PageSize < 1
        SET @PageSize = 10;    
    SELECT
        id,
        created,
        last_name,
        first_name,
        date_birth,
        email,
        COUNT(*) OVER() AS TotalCount
    FROM [User]
    ORDER BY id
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END

 */