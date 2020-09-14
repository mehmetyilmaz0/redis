using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedisExchangeAPI.Web.Models;
using RedisExchangeAPI.Web.Services;

namespace RedisExchangeAPI.Web.Controllers
{
    public class StringTypeController : Controller
    {
        private readonly RedisService _redisService;

        public StringTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            var db = _redisService.GetDb(0); //redis desktop manager den gorecegimiz uzere sıfırıncı db yi kullanacagimizi belirtiyoruz.
            db.StringSet("name", "Mehmet Yilmaz");
            db.StringSet("ziyaretci", 100);

            return View();
        }

        public IActionResult Show()
        {
            var db = _redisService.GetDb(0); //redis desktop manager den gorecegimiz uzere sıfırıncı db yi kullanacagimizi belirtiyoruz.

            var valueName = db.StringGet("name");
            if (valueName.HasValue)
                ViewBag.valueName = valueName.ToString();

            var valueZiyaretci = db.StringIncrement("ziyaretci", 1);
            ViewBag.valueZiyaretci = valueZiyaretci.ToString();

            return View();
        }

    }
}
