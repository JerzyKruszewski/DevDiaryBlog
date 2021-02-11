using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDiaryBlog.Web.Model
{
    public class User
    {
        public int Id { init; get; }

        public string Login { init; get; }

        public string HashedPassword { get; set; }

        public string Username { get; set; }

        public DateTime RegisterDate { init; get; }

        public PermissionType Permissions { get; set; }
    }
}
