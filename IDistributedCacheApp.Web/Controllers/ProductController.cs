using System;
using System.IO;
using System.Text.Json;
using IDistributedCacheApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace IDistributedCacheApp.Web.Controllers
{
    public class ProductController : Controller
    {
        private IDistributedCache _distributedCache;

        public ProductController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }


        public IActionResult Index()
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.AbsoluteExpiration = DateTime.Now.AddMinutes(1); // 1 dk sonra bu ayardaki cache leri sil
            _distributedCache.SetString("city", "ankara", options ); // redis sunucusunda city key ile cash yaptik

            Product product = new Product{ ID = 2, name = "kalem2", amount = "20" };
            string jsonProduct = JsonSerializer.Serialize(product);
            _distributedCache.SetString("product:2", jsonProduct); // kendi product nesnesini cacheledik

            return View();
        }

        public IActionResult Show()
        {
            string city = _distributedCache.GetString("city");
            ViewBag.city = city;

            string jsonProduct = _distributedCache.GetString("product:1"); // cache de bulunan kendi product nesnemizi aldik
            Product product = JsonSerializer.Deserialize<Product>(jsonProduct);
            ViewBag.product = product;

            return View();
        }

        public IActionResult Remove()
        {
            _distributedCache.Remove("city");
            return View();
        }

        public IActionResult ImageCache()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/pic1.jpg"); // resmimizin path ini buluyoruz
            byte[] byteImage = System.IO.File.ReadAllBytes(path); // resmimizi byte tipine donduruyoruz
            _distributedCache.Set("pic:2", byteImage); // byte dizisi olan resmimizi cache e kaydediyoruz

            return View();
        }

        public IActionResult ImageShow()
        {
            byte[] byteImage = _distributedCache.Get("pic:2"); // byte dizisi olan resmimizi cache den aliyoruz.
            return File(byteImage, "image/jpg"); // cacheden aldigimiz resmimizi return edip product/index sayfamizda gosteriyoruz.
        }
    }
}
