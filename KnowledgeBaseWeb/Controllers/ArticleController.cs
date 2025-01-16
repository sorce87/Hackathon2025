using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowledgeBaseWeb.Controllers
{
    public class ArticleController : Controller
    {
        public readonly IArticleRepository _articleRepository;
        // GET: ArticleController
        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public ActionResult Index()
        {
            return View(_articleRepository.GetArticles());
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                //var article = new Article({
                //    CategoryId = 0,
                //    CommentLinkId = 0,
                //    Content = "",
                //    IsDeleted = false,
                //    LikeCount = 0,
                //    ProductId = 0,
                //    Tags = null,
                //    UserId = 0,
                //    ValueStreamId = 0,
                //    ViewCount = 0,
                //    Title = "",
                //    CreatedDate = DateTime.Now,
                //    LastModifiedDate = DateTime.Now,
                //}));


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
            return View();
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
