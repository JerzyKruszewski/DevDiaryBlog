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

        [HttpGet]
        [Route("getuser/{id}")]
        public async Task<User> GetUser(int id)
        {
            return await _service.GetUser(id);
        }

        [HttpGet]
        [Route("getuserbylogin/{login}")]
        public async Task<User> GetUser(string login)
        {
            return await _service.GetUser(login);
        }

        [HttpGet]
        [Route("login/{login}/{password}")]
        public async Task<User> Login(string login, string password)
        {
            return await _service.ValidateUser(login, password);
        }

        [HttpPatch]
        [Route("changepassword/{password}")]
        public async Task<User> ChangePassword(string password, UserViewModel model)
        {
            return await _service.ChangePassword((await _service.GetUser(model.Login)), password);
        }

        [HttpPatch]
        [Route("editperms/{permType}")]
        public async Task<User> EditPermissions(int permType, UserViewModel model)
        {
            return await _service.EditPermission((await _service.GetUser(model.Login)), (PermissionType)permType);
        }
    }
}
