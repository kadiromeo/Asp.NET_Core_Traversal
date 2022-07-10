using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EFCommentDal());
        [HttpGet]
        public PartialViewResult addComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult addComment(Comment p)
        {
            p.CommentDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.CommentState = true;
            commentManager.TAdd(p);
            return RedirectToAction("Index","Destination");
        }
    }
}
