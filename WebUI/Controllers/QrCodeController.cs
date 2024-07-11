using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class QrCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.qrcodeActive = "active";
            return View();
        }
        
    }
}