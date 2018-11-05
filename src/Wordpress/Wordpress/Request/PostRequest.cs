using System;
using System.Collections.Generic;
using System.Text;

namespace Wordpress.Api
{
    internal class PostResponse
    {
        public int Found { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
