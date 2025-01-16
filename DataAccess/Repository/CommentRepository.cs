using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly KnowledgeBaseEntities _dbContext;

        public CommentRepository()
        {
            _dbContext = new KnowledgeBaseEntities();
        }
        public async Task<List<Comment>> GetCommentByArticleId(int articleId, int userId)
        {
            List<Comment> comment = null;
            try
            {
                comment = await _dbContext.Comments.Where(x => x.ArticleId == articleId && x.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
            }
            return comment;
        }
        public async Task<User> GetUserById(int userId)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(userId);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Comment> AddComment(Comment comment)
        {
            try
            {
                var article = await _dbContext.Articles.FindAsync(comment.ArticleId);
                var user = await _dbContext.Users.FindAsync(comment.UserId);
                Comment commentNew = new Comment
                {
                    ArticleId = comment.ArticleId,
                    AuthorEmail = user.Email,
                    AuthorName = user.FirstName + " " + user.LastName,
                    Content = comment.Content,
                    CreatedDate = DateTime.UtcNow,
                    IsDeleted = false,
                    UserId = comment.UserId
                };
                _dbContext.Comments.Add(comment);
                await _dbContext.SaveChangesAsync();

                CommentLink commentLink = new CommentLink
                {
                    ArticleId = comment.ArticleId,
                    CommentId = comment.CommentId
                };
                _dbContext.CommentLinks.Add(commentLink);
                await _dbContext.SaveChangesAsync();
                return comment;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Comment> DeleteComment(int commentId)
        {
            Comment comment = null;
            try
            {
                //Do Soft Delete Here
                comment = await _dbContext.Comments.FindAsync(commentId);
                comment.IsDeleted = true;
                comment.Content = "[Comment deleted]";
                _dbContext.Entry(comment).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
            return comment;
        }
    }

}
