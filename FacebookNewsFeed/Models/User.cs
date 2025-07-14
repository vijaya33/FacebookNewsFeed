namespace FacebookNewsFeed.Models
{
    public class User
    {
        public string Id { get; set; } // MongoDB will automatically create this
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}
