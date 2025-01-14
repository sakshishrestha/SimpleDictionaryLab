using CSCI5220SimpleDictionary.Models;
using CSCI5220SimpleDictionary.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSCI5220SimpleDictionary.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDictionaryRepository _dictionaryRepo;

    public HomeController(IDictionaryRepository dictionaryRepo, ILogger<HomeController> logger)
    {
        _logger = logger;
        _dictionaryRepo = dictionaryRepo;
    }

    public IActionResult Index()
    {
        var model = _dictionaryRepo.ReadAll();
        return View(model);
    }

    public IActionResult AddWord()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddWord(DictionaryEntry entry)
    {
        _dictionaryRepo.Create(entry);
        return RedirectToAction("Index");
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
