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
