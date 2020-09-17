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
    public class RedisHashTypeController : Controller
    {
        private readonly RedisService _redisService;

        private string listKey = "redisHashSozluk"; 

        public RedisHashTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            var db = _redisService.GetDb(3); //redis desktop manager den gorecegimiz uzere ikinci db yi kullanacagimizi belirtiyoruz.

            Dictionary<string, string> keyValues = new Dictionary<string, string>();

            if (db.KeyExists(listKey))
            {
                db.HashGetAll(listKey).ToList().ForEach((x) =>
                {
                    keyValues.Add(x.Name, x.Value);
                });
            }
            


            return View(keyValues);
        }


        [HttpPost]
        public IActionResult Add(string name, string value)
        {
            var db = _redisService.GetDb(3); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.
            db.HashSet(listKey, name, value);
            return RedirectToAction("index"); // index actionuna git
        }

        public IActionResult Delete(string name)
        {
            var db = _redisService.GetDb(3); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.
            db.HashDelete(listKey, name);
            return RedirectToAction("index"); // index actionuna git
        }

    }
}
