using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EmprestaGame.API.Controllers
{
    public class BaseController : ApiController
    {
        protected string GetUsuarioLogado()
        {
            if (HttpContext.Current != null && HttpContext.Current.Request != null
                && HttpContext.Current.Request.Headers["Authorization"] != null)
            {
                return HttpContext.Current.Request.Headers["Authorization"].ToString().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)[0];
            }

            return string.Empty;
        }
    }
}