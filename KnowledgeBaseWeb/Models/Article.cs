namespace KnowledgeBaseWeb.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int CategoryId { get; set; }
        public string Tags { get; set; }
        public int ViewCount { get; set; }
        public int UserId { get; set; }
        public int ValueStreamId { get; set; }
        public int ProductId { get; set; }
        public int LikeCount { get; set; }
        public int IsDeleted { get; set; }
        public int CommentLinkId { get; set; }

    }
}
