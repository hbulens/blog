using Wordpress.Api;

namespace Wordpress
{
    public class Tag
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string description { get; set; }
        public int post_count { get; set; }
        public string feed_url { get; set; }
    }
}