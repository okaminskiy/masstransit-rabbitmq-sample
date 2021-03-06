﻿using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Customers.App_Start;
using MassTransit;

namespace Customers
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : System.Web.HttpApplication
	{
	    public static IWindsorContainer Container;
		
        protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			ConfigureBus();
		}

		void ConfigureBus()
		{
			Bus.Initialize(sbc =>
			{
				sbc.UseRabbitMq();
				// this should be different from other endpoints in the project
				sbc.ReceiveFrom("rabbitmq://localhost/sample.web.customer");
			});
		}  
    }       

}