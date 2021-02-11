using DevDiaryBlog.Web.Data;
using DevDiaryBlog.Web.Model;
using DevDiaryBlog.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DevDiaryBlog.Web.Services
{
    public class UserService : IUserService
    {
        private readonly DevDiaryDatabaseContext _context;

        public UserService(DevDiaryDatabaseContext context)
        {
            _context = context;
        }

        public async Task<User> ChangePassword(User user, string newPassword)
        {
            user.HashedPassword = MD5Hash(newPassword);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> EditPermission(User user, PermissionType permission)
        {
            user.Permissions = permission;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUser(string login)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Login == login);
        }

        public async Task<bool> ValidateUser(string login, string password)
        {
            User user = await GetUser(login);

            if (user == null)
            {
                return false;
            }

            return MD5Hash(password) == user.HashedPassword;
        }

        public async Task<User> RegisterUser(string login, string password, string username)
        {
            if (_context.Users.Any(u => u.Login == login))
            {
                return null;
            }

            User user = new User()
            {
                Id = default,
                Login = login,
                HashedPassword = MD5Hash(password),
                Username = username,
                RegisterDate = DateTime.Now,
                Permissions = PermissionType.Read
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        private static string MD5Hash(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] md5data = md5.ComputeHash(data);

            return Encoding.ASCII.GetString(md5data);
        }
    }
}
