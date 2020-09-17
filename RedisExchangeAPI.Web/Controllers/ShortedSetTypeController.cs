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
    public class ShortedSetTypeController : Controller
    {
        private readonly RedisService _redisService;

        private string listKey = "sortedSetNames"; 

        public ShortedSetTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            var db = _redisService.GetDb(3); //redis desktop manager den gorecegimiz uzere ikinci db yi kullanacagimizi belirtiyoruz.

            HashSet<string> hashSetList = new HashSet<string>();

            if (db.KeyExists(listKey))
            {
                /*
                    db.SortedSetScan(listKey).ToList().ForEach((x) => // db deki kayit sirasina gore siralar
                    {
                        hashSetList.Add(x.ToString());
                    });
                */

                db.SortedSetRangeByRank(listKey, order:StackExchange.Redis.Order.Descending).ToList().ForEach((x) => // score degeri buyukten kucuge dogru sirala
                {
                    hashSetList.Add(x.ToString());
                });

            }


            return View(hashSetList);
        }


        [HttpPost]
        public IActionResult Add(string name, int score)
        {
            var db = _redisService.GetDb(3); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.
            db.SortedSetAdd(listKey, name, score); // "hashNames" key isimli bir liste olustur ve metoda gelen "name" degiskenini bu listeye ekle
            db.KeyExpire(listKey, DateTime.Now.AddMinutes(1)); // listKey degiskeni icin db de 5 dakikalik omur verildi
            return RedirectToAction("index"); // index actionuna git
        }

        public IActionResult Delete(string name)
        {
            var db = _redisService.GetDb(3); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.
            db.SortedSetRemove(listKey, name);
            return RedirectToAction("index"); // index actionuna git
        }

    }
}
