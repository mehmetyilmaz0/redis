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
    public class SetTypeController : Controller
    {
        private readonly RedisService _redisService;

        private string listKey = "hashNames"; 

        public SetTypeController(RedisService redisService)
        {
            _redisService = redisService;
        }

        public IActionResult Index()
        {
            var db = _redisService.GetDb(2); //redis desktop manager den gorecegimiz uzere ikinci db yi kullanacagimizi belirtiyoruz.

            HashSet<string> hashSetList = new HashSet<string>();

            if (db.KeyExists(listKey))
            {
                db.SetMembers(listKey).ToList().ForEach((x) =>
                {
                    hashSetList.Add(x.ToString());
                });
            }

            return View(hashSetList);
        }


        [HttpPost]
        public IActionResult Add(string name)
        {
            var db = _redisService.GetDb(2); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.
            db.KeyExpire(listKey, DateTime.Now.AddMinutes(5)); // listKey degiskeni icin db de 5 dakikalik omur verildi
            db.SetAdd(listKey, name); // "hashNames" key isimli bir liste olustur ve metoda gelen "name" degiskenini bu listeye ekle
            return RedirectToAction("index"); // index actionuna git
        }

        public IActionResult Delete(string name)
        {
            var db = _redisService.GetDb(2); //redis desktop manager den gorecegimiz uzere birinci db yi kullanacagimizi belirtiyoruz.
            db.SetRemove(listKey, name);
            return RedirectToAction("index"); // index actionuna git
        }

    }
}
