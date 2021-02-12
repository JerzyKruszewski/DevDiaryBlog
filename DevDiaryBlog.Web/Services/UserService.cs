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

            _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> EditPermission(User user, PermissionType permission)
        {
            user.Permissions = permission;

            _context.Users.Update(user);

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

        public async Task<User> ValidateUser(string login, string password)
        {
            User user = await GetUser(login);

            if (user == null)
            {
                return null;
            }

            return (MD5Hash(password) == user.HashedPassword) ? user : null;
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
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
