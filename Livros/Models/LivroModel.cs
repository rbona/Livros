using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Livros.Models
{
    [Table("TB_LIVROS")]
    public class LivroModel
    {
        [DisplayName("Código")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [DisplayName("Livro")]
        [Required(ErrorMessage = "Deve ser informado o nome do livro.")]
        [StringLength(100, ErrorMessage = "O nome do livro deve ter no máximo 100 caracteres.")]
        [Column("NOME")]
        public string Nome { get; set; }

        [DisplayName("Autor")]
        [Required(ErrorMessage = "Deve ser informado o nome do autor do livro.")]
        [StringLength(100, ErrorMessage = "O nome do autor do livro deve ter no máximo 100 caracteres.")]
        [Column("NOMEAUTOR")]
        public string Autor { get; set; }
    }
}