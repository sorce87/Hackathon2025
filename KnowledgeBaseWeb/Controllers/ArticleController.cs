using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repository;
using KnowledgeBaseWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowledgeBaseWeb.Controllers
{
    public class ArticleController : Controller
    {
        public readonly IArticleRepository _articleRepository;
        private readonly ICommentRepository _commentRepository = new CommentRepository();
        // GET: ArticleController
        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public ActionResult Index()
        {
            return View(_articleRepository.GetArticles());
        }

        public ActionResult Search(string searchWord = "")
        {
            return View(_articleRepository.SearchArticles(searchWord));
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            _articleRepository.ViewsIncrement(id);
            var article = _articleRepository.GetArticleById(id);
            var comments = _articleRepository.GetCommentsForArticle(id);
            var articleComments = new ArticleCommentsViewModel();
            articleComments.Comments = comments;
            articleComments.Article = article;
            return View(articleComments);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            try
            {
                _articleRepository.CreateArticle(article);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_articleRepository.GetArticleById(id));
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Article article)
        {
            try
            {
                _articleRepository.EditArticle(article);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LikeCount(int id)
        {
            try
            {
                _articleRepository.LikeIncrement(id);
                return RedirectToAction("Details", new { id = id });
            }
            catch
            {
                return View();
            }
        }
        // GET: ArticleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
