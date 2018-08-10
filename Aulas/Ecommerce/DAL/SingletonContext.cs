using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ecommerce.DAL
{
    public class SingletonContext
    {
        private static Context context;

        private SingletonContext() { }

        public static Context GetInstance()
        {
            if(context == null)
            {
                context = new Context();
            }
            return context;
        }
    }
}