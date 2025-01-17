using DataAccess;
using DataAccess.Interfaces;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeBaseWeb.Controllers
{ 
    public class CommentController : Controller
    {
        private readonly ICommentRepository _context = new CommentRepository();
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(int articleId, string content, int userId)
        {
            if (string.IsNullOrEmpty(content))
            {
                return BadRequest("Comment content cannot be empty");
            }
            var author = await _context.GetUserById(userId);
            var comment = new Comment
            {
                ArticleId = articleId,
                Content = content,
                CreatedDate = DateTime.UtcNow,
                AuthorName = author.FirstName + " " + author.LastName, 
                AuthorEmail = author.Email,
                IsDeleted = false,
                UserId = userId
            };
            var response = await _context.AddComment(comment);

            if (response != null)
            {
                return RedirectToAction("Details", "Article", new { id = articleId });
            }
            return RedirectToAction("index", "Article");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int commentId)
        {
            var comment = await _context.DeleteComment(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = true });
            }

            return RedirectToAction("Details", "Articles", new { id = comment.ArticleId });
        }
    }
}
