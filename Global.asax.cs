using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using AutoMapper;
using WebApplication2.Models;

namespace WebApplication2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Mapper.Initialize(config =>
            {
                config.CreateMap<customersModel, CustomersViewModel>().ReverseMap();
            });
        }
        protected void Application_BeginRequest()

        {

            string[] allowedOrigin = new string[] { "http://localhost:1933" };

            var origin = HttpContext.Current.Request.Headers["Origin"];

            if (origin != null && allowedOrigin.Contains(origin))

            {

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", origin);

                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET,POST");

            }
        }
    }
}
