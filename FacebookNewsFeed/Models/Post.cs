namespace FacebookNewsFeed.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
