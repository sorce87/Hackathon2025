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

            var comment = new Comment
            {
                ArticleId = articleId,
                Content = content,
                CreatedDate = DateTime.UtcNow,
                AuthorName = "Anonymous", // Replace with actual user name when authentication is added
                AuthorEmail = "anonymous@example.com",
                IsDeleted = false,
                UserId = userId
            };

            //_context.Comment.Add(comment);
            //await _context.SaveChangesAsync();

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_CommentPartial", comment);
            }

            return RedirectToAction("Details", "Articles", new { id = articleId });
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var comment = await _context.Comments.FindAsync(id);
        //    if (comment == null)
        //    {
        //        return NotFound();
        //    }

        //    // Soft delete
        //    comment.IsDeleted = true;
        //    comment.Content = "[Comment deleted]";
        //    await _context.SaveChangesAsync();

        //    if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        //    {
        //        return Json(new { success = true });
        //    }

        //    return RedirectToAction("Details", "Articles", new { id = comment.ArticleId });
        //}
    }
}
