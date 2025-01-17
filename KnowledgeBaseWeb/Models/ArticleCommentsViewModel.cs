using DataAccess;
using System.Collections.Generic;

namespace KnowledgeBaseWeb.Models
{
    public class ArticleCommentsViewModel
    {
        public List<Comment> Comments { get; set; }
        public Article Article { get; set; }
    }
}
