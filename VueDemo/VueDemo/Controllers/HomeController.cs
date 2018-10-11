using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VueDemo.Functions;
using VueDemo.Models;
using VueDemo.Requests;

namespace VueDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("other")]
        public IActionResult Other()
        {
            return View();
        }

        [Route("check-game-status")]
        [HttpPost]
        public JsonResult CheckGameStatus([FromBody]GameStateRequest gameStateRequest) 
        {
            GameResult result = Functions.GameFunctions.GetGameResult(gameStateRequest.Playground);
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
