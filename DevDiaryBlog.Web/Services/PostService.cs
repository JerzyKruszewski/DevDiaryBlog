using DevDiaryBlog.Web.Data;
using DevDiaryBlog.Web.Model;
using DevDiaryBlog.Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDiaryBlog.Web.Services
{
    public class PostService : IPostService
    {
        private readonly DevDiaryDatabaseContext _context;

        public PostService(DevDiaryDatabaseContext context)
        {
            _context = context;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _context.Posts.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Post> CreatePost(string title, string content, User user)
        {
            Post post = new Post()
            {
                Id = default,
                Title = title,
                Text = content,
                PublishDate = DateTime.Now,
                LastUpdateDate = null,
                Author = user
            };

            _context.Posts.Add(post);

            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Post> EditPost(int postId, string title, string content)
        {
            Post post = await GetPost(postId);

            if (post == null)
            {
                return null;
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                post.Title = title;
            }

            if (!string.IsNullOrWhiteSpace(content))
            {
                post.Text = content;
            }

            post.LastUpdateDate = DateTime.Now;

            _context.Posts.Update(post);

            return post;
        }
    }
}
