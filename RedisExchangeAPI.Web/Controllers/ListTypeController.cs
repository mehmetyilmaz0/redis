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
    public class ListTypeController : Controller
    {
        private readonly RedisService _redisService;

        private string listKey = "names";

        public ListTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            var db = _redisService.GetDb(1); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.

            List<string> namesList = new List<string>();
            if(db.KeyExists(listKey))
            {
                db.ListRange(listKey, 0, 10).ToList().ForEach((x) =>
               {
                   namesList.Add(x);
               });
            }

            return View(namesList);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            var db = _redisService.GetDb(1); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.

            db.ListRightPush(listKey, name); // "names" key isimli bir liste olustur ve metoda gelen "name" degiskenini bu listenin sagina yani sonuna kaydet

            return RedirectToAction("index"); // index actionuna git
        }

        public IActionResult Delete(string name)
        {
            var db = _redisService.GetDb(1); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.

            db.ListRemove(listKey, name);

            return RedirectToAction("index"); // index actionuna git
        }

    }
}
