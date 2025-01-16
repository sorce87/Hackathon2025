using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICommentRepository
    {
        Task<User> GetUserById(int userId);
        Task<List<Comment>> GetCommentByArticleId(int articleId, int userId);
        Task<Comment> AddComment(Comment comment);
        Task<Comment> DeleteComment(int commentId);
    }
}
