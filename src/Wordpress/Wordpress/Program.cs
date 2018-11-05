using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wordpress
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string blogUri = "hendrikbulens.wordpress.com";

            Console.WriteLine($"Printing out posts for blog {blogUri} \n*********");            

            Wordpress wordpress = new Wordpress(new Uri(string.Format("https://public-api.wordpress.com/rest/v1.1/sites/{0}/posts/", blogUri)));
            IEnumerable<Post> posts = await wordpress.Posts();

            foreach (Post post in posts)
                Console.WriteLine($"On {post.Date}, {post.Author.FirstName} {post.Author.LastName} published post with title {post.Title}");

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
