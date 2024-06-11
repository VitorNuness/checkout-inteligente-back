using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly CheckoutDbContext DbContext;
        public readonly TokenService TokenService;

        public AuthController()
        {
            this.DbContext = new CheckoutDbContext();
            this.TokenService = new TokenService();
        }

        [HttpPost("signIn")]
        public ActionResult<object> SingIn(User data)
        {
            User? user = this.DbContext.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);

            if (user == null)
            {
                return NotFound();
            }

            string token = this.TokenService.CreateToken(user);

            return new { user, token };
        }

        [HttpPost("signUp")]
        public ActionResult SignUp(User data)
        {
            this.DbContext.Users.Add(data);
            this.DbContext.SaveChanges();

            return NoContent();
        }
    }
}
