using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlascoAppFuncionalTreinamento.Models;

namespace BlascoAppFuncionalTreinamento.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       [HttpGet]
       [Route(template:"listar-clientes")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Clientes.ToListAsync());
        }

        [HttpGet]
        [Route(template: "cliente-detalhe/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            
            var cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        [Route(template: "novo-cliente")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route(template: "novo-cliente")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,Senha,ConfirmacaSenha,DataCadastro,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                cliente.DataCadastro = DateTime.Now;
                await db.SaveChangesAsync();

                TempData["Mensagem"] = "Cliente criado com sucesso";

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        [HttpGet]
        [Route(template:"editar-cliente/{id:int}")]
        public async Task<ActionResult> Edit(int id)
        {
            
            var cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [Route(template:"editar-cliente/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,Senha,ConfirmacaSenha,DataCadastro,Ativo")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.Entry(cliente).Property(Cliente => Cliente.DataCadastro).IsModified = false;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        [Route(template:"deletar-cliente/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            
            var cliente = await db.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [Route(template: "deletar-cliente/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cliente cliente = await db.Clientes.FindAsync(id);
            db.Clientes.Remove(cliente);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
