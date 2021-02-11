using DevDiaryBlog.Web.Model;
using DevDiaryBlog.Web.Services.Interfaces;
using DevDiaryBlog.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDiaryBlog.Web.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("register")]
        public async Task<User> RegisterUser(UserViewModel model)
        {
            return await _service.RegisterUser(model.Login, model.Password, model.Username);
        }
    }
}
