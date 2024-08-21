using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCS.Data;
using CadastroCS.Models;
using NuGet.Common;
using Microsoft.AspNetCore.Http;

namespace CadastroCS.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly CadastroCSContext _context;

        public FornecedoresController(CadastroCSContext context)
        {
            _context = context;
        }

        // GET: Fornecedors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedor.ToListAsync());
        }

        // GET: Fornecedors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedors/Create
        public IActionResult Cadastro()
        {
            return View();
        }

        // POST: Fornecedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastro([Bind("Id,Name,Cnpj,Segmento,Cep,Endereco")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var form = Request.Form;
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();

                var files = Request.Form.Files;
                if (files.Count > 0){ 
                    await SetImage(files[0], fornecedor); 
                }

                return RedirectToAction(nameof(Index));

            }
            return View(fornecedor);
        }

        // GET: Fornecedors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return View(fornecedor);
        }

        public async Task<IActionResult> SetImage(IFormFile file, Fornecedor fornecedor)
        {
            string path = "./wwwroot/profiles/" + fornecedor.Id.ToString() + ".png";

            using (var stream = System.IO.File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            fornecedor.Foto = path;
            await _context.SaveChangesAsync();

            return Ok("Imagem foi carregada com sucesso.");

        }

        public async Task<IActionResult> GetImage(int id)
        {
            string path = "./wwwroot/profiles/" + id.ToString() + ".png";

            if (System.IO.File.Exists(path))
            {
                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(path);
                return File(fileBytes, "image/png");

            } else
            {
                byte[] fileBytes = await System.IO.File.ReadAllBytesAsync("./wwwroot/profiles/default.png");
                return File(fileBytes, "image/png");

            }

        }

        // GET: FornecedoresController1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedor.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedor.Remove(fornecedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool FornecedorExists(int id)
        {
            return _context.Fornecedor.Any(e => e.Id == id);
        }

    }
}
