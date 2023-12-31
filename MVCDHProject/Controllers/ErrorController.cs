﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCDHProject.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("ClientError/{StatusCode}")]
        public IActionResult ClientErrorHandler(int StatusCode)
        {
            switch (StatusCode)
            {
                case 400:
                    ViewBag.ErrorTitle = "Bad Request";
                    ViewBag.ErrorMessage = "The server can’t return a response due to an error on the client’s end.";
                    break;
                case 401:
                    ViewBag.ErrorTitle = "Unauthorized or Authorization Required";
                    ViewBag.ErrorMessage = "Returned by server when the target resource lacks authentication credentials.";
                    break;
                case 402:
                    ViewBag.ErrorTitle = "Payment Required";
                    ViewBag.ErrorMessage = "Processing the request is not possible due to lack of required funds.";
                    break;
                case 403:
                    ViewBag.ErrorTitle = "Forbidden";
                    ViewBag.ErrorMessage = "You are attempting to access the resource that you don’t have permission to view.";
                    break;
                case 404:
                    ViewBag.ErrorTitle = "Not Found";
                    ViewBag.ErrorMessage = "The requested resource does not exist, and server does not know if it ever existed.";
                    break;
                case 405:
                    ViewBag.ErrorTitle = "Method Not Allowed";
                    ViewBag.ErrorMessage = "Hosting server supports the method received, but the target resource doesn’t.";
                    break;
            }
            return View("ClientErrorView");
        }

    }
}
