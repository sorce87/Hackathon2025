using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        public readonly KnowledgeBaseEntities _dbContext;
        public ArticleRepository()
        {
            _dbContext = new KnowledgeBaseEntities();
        }

        public List<Article> GetArticles()
        {
            try
            {
                var articles = _dbContext.Articles.ToList();
                return articles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Article GetArticleById(int id)
        {
            try
            {
                var article = _dbContext.Articles.Where(x => x.ArticleId == id).FirstOrDefault();

                return article;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }

        public void CreateArticle(Article article)
        {
            try
            {
                article.UserId = 1;
                article.CreatedDate = DateTime.Now;
                article.LastModifiedDate = DateTime.Now;
                article.LikeCount = 0;
                article.ViewCount = 0;
                article.ProductId = 1;
                article.CategoryId = 1;
                article.IsDeleted = false;

                _dbContext.Articles.Add(article);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void EditArticle(Article articleIn)
        {
            try
            {
                var article = _dbContext.Articles.Where(x => x.ArticleId == articleIn.ArticleId).FirstOrDefault();
                article.CategoryId = 1;
                article.Content = articleIn.Content;
                article.LastModifiedDate = DateTime.Now;
                article.ProductId = 1;
                article.Title = articleIn.Title;
                _dbContext.SaveChanges();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public Article LikeIncrement(int articleId)
        {
            try
            {
                var article = _dbContext.Articles.Where(x => x.ArticleId == articleId).FirstOrDefault();
                article.LikeCount += 1;
                _dbContext.SaveChanges();

                return article;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public void ViewsIncrement(int articleId)
        {
            try
            {
                var article = _dbContext.Articles.Where(x => x.ArticleId == articleId).FirstOrDefault();
                article.ViewCount += 1;
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public List<Comment> GetCommentsForArticle(int id)
        {
            try
            {
                var comments = _dbContext.Comments.Where(x => x.ArticleId == id).ToList();

                return comments;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Article> SearchArticles(string searchWord)
        {
            try
            {
                var articles = new List<Article>();
                if (!string.IsNullOrEmpty(searchWord))
                {
                    searchWord = searchWord.ToLower();
                    articles = _dbContext.Articles.Where(x => x.Content.ToLower().Contains(searchWord) || x.Title.ToLower().Contains(searchWord)).ToList();
                }

                return articles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
