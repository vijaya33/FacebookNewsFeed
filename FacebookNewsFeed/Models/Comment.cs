namespace FacebookNewsFeed.Models
{
    public class Comment
    {
        public string Id { get; set; } // MongoDB will auto-generate this
        public string PostId { get; set; } // The Post that the Comment belongs to
        public string UserId { get; set; } // The User who commented
        public string Content { get; set; } // The content of the comment
        public DateTime DateCreated { get; set; } // Date when the comment was created
    }
}
