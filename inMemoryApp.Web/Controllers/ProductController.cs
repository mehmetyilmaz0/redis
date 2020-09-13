using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using inMemoryApp.Models;

namespace inMemoryApp.Controllers
{
    public class ProductController : Controller
    {
        private IMemoryCache _memoryCache;

        public ProductController (IMemoryCache memoryCache) 
        {
            _memoryCache = memoryCache;
        }

        public IActionResult Index() 
        {
            MemoryCacheEntryOptions options = new MemoryCacheEntryOptions(); // cache ayarlari
            options.SetAbsoluteExpiration(DateTime.Now.AddSeconds(30)); // 30 saniye sonra cache sil
            options.SetSlidingExpiration(TimeSpan.FromSeconds(10)); // 10 saniye icinde cache e request yapilmazsa cache yi sil. yapilirsa 10 saniye daha uzat.
            options.Priority = CacheItemPriority.Low; // bu ayardaki cache en dusuk oncelikli cache
            
            // cache 'in neden silindigi ile ilgili loglama
            options.RegisterPostEvictionCallback((key, value, reason, state) => {
                _memoryCache.Set<string>("callback", key + "-" + value + " -> reason : " + reason);
            });
            
            _memoryCache.Set<string>("zaman", DateTime.Now.ToString(), options); // simdiki zamani "zaman" degiskeni ile cache ledik.

            // cache e bir nesne setleme
            Product product = new Product {ID = 1, name = "mehmet", amount = "200"};
            _memoryCache.Set<Product>("product1", product);

            return View();
        }

        public IActionResult Show()
        {
            _memoryCache.TryGetValue<string>("zaman", out string zamanCache); // cache de bulunan "zaman" isimli value yi aldik.
            ViewBag.zaman = zamanCache; // on yuzde gostermek icin cache den aldigimiz degeri ViewBag icinde "zaman" isimli degiskene atadik

            _memoryCache.TryGetValue<Product>("product1", out Product product1Cache); // cache de bulunan "product1" isimli nesne yi aldik.
            ViewBag.product1 = product1Cache;

            _memoryCache.TryGetValue<string>("callback", out string callbackCache);
            ViewBag.callback = callbackCache;
 
            // _memoryCache.Remove("zaman"); // cache den silme
            
            /* 
            // cache de "zaman" isimli key var mi yoksa yarat..
            _memoryCache.GetOrCreate<string>("zaman", (entry) => {
                return DateTime.Now.ToString();
            }); 
            */

            return View();
        }
        
    }
}