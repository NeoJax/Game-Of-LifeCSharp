using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Game_Of_LifeCSharp.Models;

namespace Game_Of_LifeCSharp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GameOfLife(int num)
        {
            List<bool> boardList = new List<bool>();
            List<List<bool>> boardGame = new List<List<bool>>();
            for (int i = 0; i < num; i++)
            {
                boardList.Add(false);
            }
            for (int i = 0; i < num; i++)
            {
                boardGame.Add(boardList);
            }
            return View(boardGame);
        }

        public IActionResult GameOfLifeContinue(List<bool> boardGame)
        {
            return View(boardGame);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
