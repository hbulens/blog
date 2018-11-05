namespace Wordpress
{
    public class Author
    {
        public int Id { get; set; }
        public string login { get; set; }
        public bool Email { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string nice_name { get; set; }
        public string URL { get; set; }
        public string avatar_URL { get; set; }
        public string profile_URL { get; set; }
    }
}