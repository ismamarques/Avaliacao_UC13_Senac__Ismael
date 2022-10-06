using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroAluno.Data;
using CadastroAluno.Models;
using CadastroAluno.Contracts;
namespace CadastroAluno.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunoRepository _context;
        public AlunosController(IAlunoRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Index());
        }

        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _context.Details(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Create(aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _context.Details(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,Turma,Media")] Aluno aluno)
        {
            if (id != aluno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Edit(id, aluno);
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = _context.Details(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var aluno = _context.Details(id);
            _context.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private IActionResult AlunoExists(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}