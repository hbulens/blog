using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using wordpress = Wordpress;

namespace Wordpress.Api
{
    internal class Post
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

        public Dictionary<string, Category> Categories { get; set; }
        public Dictionary<string, Tag> Tags { get; set; }

        public static explicit operator wordpress.Post(Post x)
            => new wordpress.Post
            {
                Id = x.Id,
                Title = x.Title,
                Slug = x.Slug,
                Date = x.Date,
                Modified = x.Modified,
                Content = x.Content,
                Guid = x.Guid,
                Author = new wordpress.Author
                {
                    Id = x.Author.ID,
                    FirstName = x.Author.first_name,
                    LastName = x.Author.last_name
                },
                Categories = x.Categories.Select(c => new wordpress.Category { name = c.Value.name }),
                Tags = x.Tags.Select(c => new wordpress.Tag { name = c.Value.name }),
            };
    }
}
