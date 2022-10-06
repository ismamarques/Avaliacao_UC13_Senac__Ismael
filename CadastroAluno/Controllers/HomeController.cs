using CadastroAluno.Data;
using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;



// Home Controller

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private CadastroAlunoContext _context;



    //Home Controller
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Context
    public HomeController(CadastroAlunoContext context)
    {
        _context = context;
    }


    // Index
    public IActionResult Index()
    {

        return View(_context.Aluno);
    }


    // View
    public IActionResult Privacy()
    {
        return View();
    }

    // Erro
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}