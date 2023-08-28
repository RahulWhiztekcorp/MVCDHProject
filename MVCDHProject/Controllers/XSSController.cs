using Microsoft.AspNetCore.Mvc;
using MVCDHProject.Models;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCDHProject.Controllers
{
    public class XSSController : Microsoft.AspNetCore.Mvc.Controller
    {
        public static List<Comment> comments = new List<Comment>() 
        {
            new Comment()
            {
                ID = 1,
                Name = "Rahul",
                CommentName = "Hello World",
            }
        };
        public IActionResult Index()
        {
            return View(comments);
        }
        public IActionResult Create()
        {
            return View();
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ValidateInput(false)]
        public IActionResult Create(Comment comment)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(comment.CommentName);
                //sb.Replace("<script >","&lt;script&gt;");
                //sb.Replace("</script >","&lt;/script&gt;");
                //sb.Replace("<script>", "&lt;script&gt;");
                //sb.Replace("</script>", "&lt;/script&gt;");
                //sb.Replace("< script>", "&lt;script&gt;");
                //sb.Replace("< /script>", "&lt;/script&gt;");
                sb.Replace("&", "&amp");
                sb.Replace("<", "&lt");
                sb.Replace(">", "&gt");
                sb.Replace("\"", "&quot");
                sb.Replace("\'", "&#x27");
                comment.CommentName = sb.ToString();
                string strName = HttpUtility.HtmlEncode(comment.Name);
                comment.Name = strName;
                comments.Add(comment);
                return RedirectToAction("Index");
            }
            catch (System.Exception ex)
            {
                return RedirectToAction("Create");
                throw ex;
            }
        }
    }
}
