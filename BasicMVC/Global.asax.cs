using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MyBlogEngine.Models;

namespace MyMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static BlogArticleRepository mainBlog;
        // sample rootPath 
        // private string rootPath = @"C:\Users\user\Downloads\MyMVC\blogFiles";
        private string rootPath = null;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Change it to your folder path
            rootPath = @"C:\Users\user\Downloads\MyMVC\blogFiles";
            if (rootPath == null)
            {
                throw new Exception("You have to set the rootPath to your blogFiles directory");
            }
            mainBlog = new BlogArticleRepository(rootPath, "blog.dat");
        }
    }
}
