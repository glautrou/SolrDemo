using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SolrDemo.Models;
using SolrNet;
using SolrNet.Attributes;

namespace SolrDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISolrOperations<Product> _solr;

        public HomeController(ILogger<HomeController> logger, ISolrOperations<Product> solr)
        {
            _logger = logger;
            _solr = solr;
        }

        public IActionResult Index()
        {
            var p = new Product
            {
                Id = "SP2514N",
                Manufacturer = "Samsung Electronics Co. Ltd.",
                Categories = new[] { "electronics", "hard drive" },
                Price = 92,
                InStock = true,
            };

            //Add
            //_solr.Add(p);
            //_solr.Commit();

            //Get
            var results = _solr.Query(new SolrQueryByField("id", "SP2514N"));

            return View();
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

    public class Product
    {
        [SolrUniqueKey("id")]
        public string Id { get; set; }

        [SolrField("manu_exact")]
        public string Manufacturer { get; set; }

        [SolrField("cat")]
        public ICollection<string> Categories { get; set; }

        [SolrField("price")]
        public decimal Price { get; set; }

        [SolrField("inStock")]
        public bool InStock { get; set; }
    }
}
