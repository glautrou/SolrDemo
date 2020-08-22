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
        private readonly ISolrOperations<UserRequests> _solr;

        public HomeController(ILogger<HomeController> logger, ISolrOperations<UserRequests> solr)
        {
            _logger = logger;
            _solr = solr;
        }

        public IActionResult Index()
        {
            var userRequests = new UserRequests
            {
                Id = 1,
                Reference = "U001",
                Firstname = "Gilles",
                Firstname2 = "Gilles",
                Lastname = "Lautrou"
            };

            //Add
            _solr.Add(userRequests);
            _solr.Commit();

            //Get
            var results1 = _solr.Query(new SolrQueryByField("id", "1"));
            var results2 = _solr.Query(new SolrQueryByField("firstname2", "Gilles"));
            var results3 = _solr.Query(new SolrQueryByField("firstname2", "gilles"));
            var results4 = _solr.Query(new SolrQueryByField("firstname2", "lles"));

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
