using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IArticleRepository
    {
        Article GetArticleById(int id);
        List<Article> GetArticles();
        //Article EditArticle(int id);
        void CreateArticle(Article article);
    }
}
