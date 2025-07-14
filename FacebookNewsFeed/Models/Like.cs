namespace FacebookNewsFeed.Models
{
    public class Like
    {
        public string Id { get; set; } // MongoDB will auto-generate this
        public string PostId { get; set; } // The Post that the Like belongs to
        public string UserId { get; set; } // The User who liked the post
        public DateTime DateCreated { get; set; } // Date when the like was created
    }
}
