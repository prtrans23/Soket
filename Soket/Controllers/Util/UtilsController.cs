using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Soket.Controllers.Util
{

    public class UtilsController : Controller
    {
        private IHttpContextAccessor _accessor;

        public UtilsController(IHttpContextAccessor httpContextAccessor)
        {
            
            _accessor = httpContextAccessor;
        }

        /*
           실서버에서 작동 되는지 확인해봐야함.
        */

        public string GetClientIP()
        {
            var ClientIPAddress = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return ClientIPAddress;
        }


        /*
          Url 가져오기.
          https://stackoverflow.com/questions/38437005/how-to-get-current-url-in-view-in-asp-net-core-1-0
        */

        public string GetHostUrl()
        {
            var url = string.Format("{0}://{1}", _accessor.HttpContext.Request.Scheme, _accessor.HttpContext.Request.Host);
            return url;
        }

        public string GetNow()
        {
            var url = string.Format("{0}://{1}{2}{3}", _accessor.HttpContext.Request.Scheme, _accessor.HttpContext.Request.Host, _accessor.HttpContext.Request.Path, _accessor.HttpContext.Request.QueryString);
            return url;
        }



    }
}