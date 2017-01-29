using Livros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livros.Controllers
{
    public class LivroController : Controller
    {
        private static Livro _livros = new Livro();

        // GET: Livro
        public ActionResult Index()
        {
            return View(_livros._livrariaContexto.Livros.OrderBy(livro => livro.Nome));
        }

        public ActionResult NovoLivro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovoLivro(LivroModel _novoLivro)
        {
            _livros.NovoLivro(_novoLivro);
            return View();
        }
        public ViewResult ApagaLivro(Guid id)
        {
            return View(_livros.BuscarLivro(id));
        }

        [HttpPost]
        public RedirectToRouteResult ApagaLivro(Guid id, FormCollection collection)
        {
            _livros.ApagarLivro(id);
            return RedirectToAction("Index");
        }

        public ActionResult AtualizaLivro(Guid id)
        {
            return View(_livros.BuscarLivro(id));
        }

        [HttpPost]
        public RedirectToRouteResult AtualizaLivro(LivroModel _livroAtualizado, FormCollection collection)
        {
            _livros.AtualizaLivro(_livroAtualizado);
            return RedirectToAction("Index");
        }

    }
}