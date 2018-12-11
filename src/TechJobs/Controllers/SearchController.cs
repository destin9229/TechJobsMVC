using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results
        [HttpGet, HttpPost]
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Dictionary<string, string>> jobs;
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Results";
            if (searchType.Contains("all")){
                jobs = JobData.FindByValue(searchTerm);
                ViewBag.jobs = jobs;
                return View("Index");
            } else {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.jobs = jobs;
                return View("Index");
            }
        }
    }
}