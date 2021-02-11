using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDiaryBlog.Web.Model
{
    public class Post
    {
        public int Id { init; get; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime PublishDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public User Author { init; get; }
    }
}
