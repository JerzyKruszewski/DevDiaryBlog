using DevDiaryBlog.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDiaryBlog.Web.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUser(string login, string password, string username);

        Task<User> GetUser(int id);

        Task<User> GetUser(string login);

        Task<bool> ValidateUser(string login, string password);

        Task<User> ChangePassword(User user, string newPassword);

        Task<User> EditPermission(User user, PermissionType permission);
    }
}
