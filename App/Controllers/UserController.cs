using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService Service;

        public UserController()
        {
            this.Service = new UserService();
        }

        [HttpGet]
        public ActionResult<List<User>> Index()
        {
            return this.Service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<User> Show(int id)
        {
            return this.Service.GetById(id);
        }

        [HttpPost]
        public ActionResult<User> Store(User user)
        {
            this.Service.Create(user);

            return user;
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, User data)
        {
            this.Service.Update(id, data);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.Service.Delete(id);

            return NoContent();
        }
    }
}
