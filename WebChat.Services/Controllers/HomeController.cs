﻿namespace WebChat.Services.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.ViewBag.Title = "WebChat Home Page";

            return this.View();
        }
    }
}