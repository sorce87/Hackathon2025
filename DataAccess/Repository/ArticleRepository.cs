using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
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
                var article = _dbContext.Articles.Where(x => x.UserId == id).FirstOrDefault();
                article.ViewCount += 1;

                _dbContext.SaveChanges();
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

        //public Article EditArticle(Article article)
        //{
        //    try
        //    {
        //        var articleEdit = _dbContext.Articles.Where(x => x.ArticleId == article.UserId).FirstOrDefault();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message, ex);
        //    }
        //}
    }
}
