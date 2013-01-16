using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Messages;
using MassTransit;
using WebSiteNew.Models;

namespace WebSiteNew.Controllers
{
    public class PublishController : Controller
    {
        //
        // GET: /Publish/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(SimpleMessage model)
        {
            Bus.Instance.Publish(new ParseCvMessage { S3Key = model.Message });
            return View();
        }

    }
}
