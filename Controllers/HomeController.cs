using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using random_passcode.Models;
using Microsoft.AspNetCore.Http;

namespace random_passcode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            int Count = 1;
            HttpContext.Session.SetInt32("Count", Count);
            ViewBag.Count = Count;


            Random rand = new Random();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string Passcode = "";
            for(int i = 0; i <= 13; i++)
            {
                int char_num = rand.Next(0, letters.Length - 1);
                Passcode += letters[char_num];
            }
            HttpContext.Session.SetString("Passcode", Passcode);
            ViewBag.Passcode = Passcode;
            return View();
        }
        [HttpPost("random_word")]
        public IActionResult RandomWord()
        {
            //For integer count
            int? Count = HttpContext.Session.GetInt32("Count");
            Count = (Count == null) ? 1 : Count;
            Count++;
            HttpContext.Session.SetInt32("Count", (int)Count);
            ViewBag.Count = Count;

            //For random passcode
            Random rand = new Random();
            char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string Passcode = "";
            for(int i = 0; i <= 13; i++)
            {
                int char_num = rand.Next(0, letters.Length - 1);
                Passcode += letters[char_num];
            }
            HttpContext.Session.SetString("Passcode", Passcode);
            ViewBag.Passcode = Passcode;
            return View();
        }
        [HttpGet("Reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
