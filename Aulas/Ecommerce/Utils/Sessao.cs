using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ecommerce.Utils
{
    public class Sessao
    {
        public static string RetornarCarrinhoId()
        {
            if(HttpContext.Current.Session["carrinhoId"] == null)
            {
                Guid guid = Guid.NewGuid();

                HttpContext.Current.Session["carrinhoId"] = guid.ToString();
            }

            return HttpContext.Current.Session["carrinhoId"].ToString();
        }
    }
}