using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Wordpress.Api;

namespace Wordpress
{
    public class Wordpress
    {
        private readonly Uri _uri;

        public Wordpress(Uri uri)
        {
            _uri = uri;
        }

        public async Task<IEnumerable<Post>> Posts()
        {
            PostResponse blogPosts = await GetResource<PostResponse>();
            return blogPosts.Posts.Select(x => (Post)x).OrderByDescending(x => x.Date);
        }

        private async Task<T> GetResource<T>()
        {
            using (WebClient webClient = new WebClient())
            {
                string response = await webClient.DownloadStringTaskAsync(_uri);
                return JsonConvert.DeserializeObject<T>(response);
            }
        }
    }
}