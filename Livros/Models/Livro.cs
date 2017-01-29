using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livros.Models
{
    public class Livro
    {
        public List<LivroModel> _listaLivros = new List<LivroModel>();
        public LivrariaContext _livrariaContexto = new LivrariaContext();

        public Livro()
        {
            _listaLivros.Add(new LivroModel() { ID = Guid.NewGuid(), Autor = "Autor1", Nome = "Teste1" });
            _listaLivros.Add(new LivroModel() { ID = Guid.NewGuid(), Autor = "Autor2", Nome = "Teste2" });
            _listaLivros.Add(new LivroModel() { ID = Guid.NewGuid(), Autor = "Autor3", Nome = "Teste3" });
            _listaLivros.Add(new LivroModel() { ID = Guid.NewGuid(), Autor = "Autor4", Nome = "Teste4" });
        }

        public void NovoLivro(LivroModel novoLivro)
        {
            _livrariaContexto.Livros.Add(novoLivro);
            _livrariaContexto.SaveChanges();
        }

        public void AtualizaLivro(LivroModel livroAtualizar)
        {
            LivroModel livro = _livrariaContexto.Livros.Where(livroAtual => livroAtual.ID == livroAtualizar.ID).First();

            if (livro != null)
            {
                livro.Nome = livroAtualizar.Nome;
                livro.Autor = livroAtualizar.Autor;

                _livrariaContexto.SaveChanges();
            }
        }

        public LivroModel BuscarLivro(Guid id)
        {
            return _livrariaContexto.Livros.Where(livro => livro.ID == id).First(); // _listaLivros.Where(livro => livro.ID == id).First();
        }

        public void ApagarLivro(Guid id)
        {
            LivroModel _livroApagar = _livrariaContexto.Livros.Where(livro => livro.ID == id).First();

            if (_livroApagar != null)
            {
                _livrariaContexto.Livros.Remove(_livroApagar);
                _livrariaContexto.SaveChanges();
            }
        }
    }
}