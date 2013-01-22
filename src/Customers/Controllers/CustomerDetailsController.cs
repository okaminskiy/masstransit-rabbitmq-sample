    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customers.Models;
using Domain.Messages;
using MassTransit;

namespace Customers.Controllers
{
    public class CustomerDetailsController : Controller
    {
        //
        // GET: /CustomerDetails/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CustomerDetailsModel model)
        {
            Bus.Instance.Publish( new CustomerDetails
            {
                Age = model.Age,
                EmailAddress = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Location = model.Location
            });
            return View(model);
        }

    }
}
