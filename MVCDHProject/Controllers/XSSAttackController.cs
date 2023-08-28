using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MVCDHProject.Controllers
{
    public class XSSAttackController : Controller
    {
        #region Output Encoding for “HTML Attribute Contexts”
        public IActionResult DecodeIndex()
        {
            string name = "Kondi Rahul <script> alert(898989); </script>";

            TempData["name"] = name;
            // Return a view with the encoded name.
            return View("DecodeIndex");
        }
        public IActionResult EncodeIndex()
        {
            string name = "Kondi Rahul <script> alert(898989); </script>";

            // Encode the name for an HTML attribute context.
            string encodedName = HttpUtility.HtmlAttributeEncode(name);

            TempData["name"] = encodedName;
            // Return a view with the encoded name.
            return View("EncodeIndex");
        }
        #endregion
        #region Output Encoding for “JavaScript Contexts”
        public ActionResult JavaScriptDecodeIndex()
        {
            string name = "This is a test <script>alert('XSS');</script>";
            TempData["name"] = name;

            // Return a view with the encoded name.
            return View("JavaScriptDecodeIndex",new { name = name });
        }
        public ActionResult JavaScriptEncodeIndex()
        {
            string name = "This is a test <script>alert('XSS');</script>";
                
            // Encode the name for a JavaScript context.
            string encodedName = HttpUtility.JavaScriptStringEncode(name);
            TempData["name"] =encodedName;
            // Return a view with the encoded name.
            return View(new { name = encodedName });
        }
        #endregion
        #region Output Encoding for “CSS Contexts”
        public ActionResult CSSDecodeIndex()
        {
            string colorname = "color:blue;";
            TempData["colorname"] = colorname;

            // Return a view with the encoded name.
            return View("CSSDecodeIndex", new { color = colorname });
        }
        public ActionResult CSSEncodeIndex()
        {
            string colorname = "color:blue;";

            // Encode the name for a JavaScript context.
            string encodedcolorname = HttpUtility.HtmlEncode(colorname);
            TempData["encodedcolorname"] = encodedcolorname;
            // Return a view with the encoded name.
            return View("CSSEncodeIndex",new { name = encodedcolorname });
        }
        #endregion
        #region Output Encoding for “URL Contexts”
        public ActionResult UrlDecodeIndex()
        {
            string name = "https://www.google.com/";
            TempData["url"] = name;
            // Return a view with the encoded name.
            return View("UrlDecodeIndex",new { name = name });
        }
        public ActionResult UrlEncodeIndex()
        {
            string name = "https://www.google.com/";

            // Encode the name for a URL context.
            string encodedName = HttpUtility.UrlEncode(name);
            TempData["url"] = encodedName;

            // Return a view with the encoded name.
            return View("UrlEncodeIndex",new { name = encodedName });
        }
        #endregion
    }
}
