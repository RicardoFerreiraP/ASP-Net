using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(50, ErrorMessage = "O campo deve ter no máximo 50 caracteres!")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [MaxLength(150, ErrorMessage = "O campo deve ter no máximo 150 caracteres!")]
        [Display(Name = "Descrição do Produto")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name = "Categoria do Produto")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Preço do Produto")]
        public double Preco { get; set; }

        public string Imagem { get; set; }
    }
}