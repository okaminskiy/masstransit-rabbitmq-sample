﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Messages;
using MassTransit;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult Create(string name)
        {
            Bus.Instance.Publish(new ActivateCustomerCommand{ S3Key = name });
			//Bus.Instance.Publish(new CreateCustomer { Name = name, Email = "Email + " + name, Password = "Password + " + name});
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            return View();
        }
    }
}
