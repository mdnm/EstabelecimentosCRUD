using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var estabelecimentos = from m in _db.estabelecimentos
                                   select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                estabelecimentos = estabelecimentos.Where(s => s.RazaoSocial.Contains(searchString) || s.CNPJ.Contains(searchString) || s.NomeFantasia.Contains(searchString));
            }

            return View(await estabelecimentos.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            var estabelecimentoModel = new Estabelecimentos();
            estabelecimentoModel.categoriasList = _db.categorias.ToList();
            estabelecimentoModel.DataDeCadastro = DateTime.Today.Date;
            return View(estabelecimentoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Estabelecimentos estabelecimento)
        {
            estabelecimento.categoriasList = _db.categorias.ToList();
            if (ModelState.IsValid)
            {           
                if (estabelecimento.CheckTelefone())
                {
                    _db.Add(estabelecimento);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(estabelecimento);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _db.estabelecimentos.SingleOrDefaultAsync(m => m.Id == id);

            if (estabelecimento == null)
            {
                return NotFound();
            }

            estabelecimento.categoriasList = _db.categorias.ToList();
            return View(estabelecimento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _db.estabelecimentos.SingleOrDefaultAsync(m => m.Id == id);

            if (estabelecimento == null)
            {
                return NotFound();
            }
            estabelecimento.categoriasList = _db.categorias.ToList();
            return View(estabelecimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Estabelecimentos estabelecimento)
        {
            estabelecimento.categoriasList = _db.categorias.ToList();
            if (ModelState.IsValid)
            {
                if (estabelecimento.CheckTelefone())
                {
                    _db.Update(estabelecimento);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(estabelecimento);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _db.estabelecimentos.SingleOrDefaultAsync(m => m.Id == id);

            if (estabelecimento == null)
            {
                return NotFound();
            }
            estabelecimento.categoriasList = _db.categorias.ToList();
            return View(estabelecimento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEstabelecimento(int? id)
        {
            var estabelecimento = await _db.estabelecimentos.SingleOrDefaultAsync(m => m.Id == id);
            _db.estabelecimentos.Remove(estabelecimento);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
