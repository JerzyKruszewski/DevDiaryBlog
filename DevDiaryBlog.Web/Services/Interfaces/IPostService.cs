using DevDiaryBlog.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDiaryBlog.Web.Services.Interfaces
{
    public interface IPostService
    {
        public Task<Post> GetPost(int id);

        public Task<Post> CreatePost(string title, string content, User user);

        public Task<Post> EditPost(int postId, string title, string content);
    }
}
