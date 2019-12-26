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

        public IActionResult GameOfLifeSetup(int num1, int num2)
        {
            List<bool> boardList = new List<bool>();
            List<List<bool>> boardGame = new List<List<bool>>();
            for (int i = 0; i < num1; i++)
            {
                boardList.Add(false);
            }
            for (int i = 0; i < num2; i++)
            {
                boardGame.Add(boardList);
            }
            TempData["board"] = boardGame;
            return RedirectToAction("GameOfLife");
        }
        
        public IActionResult GameOfLife(List<List<bool>> boardGame)
        {
            var temp = TempData["board"];
            if (boardGame.Count == 0)
            {
                return View(TempData["board"]);
            }
            return View(boardGame);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
