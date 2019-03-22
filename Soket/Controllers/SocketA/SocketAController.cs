using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Soket.Controllers.SocketA
{
    public class SocketAController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}