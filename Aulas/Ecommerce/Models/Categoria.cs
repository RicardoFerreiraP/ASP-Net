using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo deve ter no máximo 50 caracteres!")]
        [Display(Name = "Nome do Produto")]
        public string NomeCategoria { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo deve ter no máximo 50 caracteres!")]
        [Display(Name = "Nome do Produto")]
        public string DescricaoCategoria { get; set; }
    }
}