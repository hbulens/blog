using System;
using System.Collections.Generic;
using System.Text;

namespace Wordpress
{
    public class Post
    {
        public int Id { get; set; }
        public string Guid { get; set; }
        public Uri Link { get; set; }

        public DateTime Date { get; set; }
        public DateTime DateGmt { get; set; }

        public DateTime Modified { get; set; }
        public DateTime ModifiedGmt { get; set; }

        public string Slug { get; set; }

        public string Type { get; set; }
        public string Status { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public Author Author { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}
