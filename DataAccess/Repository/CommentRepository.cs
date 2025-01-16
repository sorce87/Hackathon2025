using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public async Task<Comment> GetCommentByArticleId(int articleId)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }

}
