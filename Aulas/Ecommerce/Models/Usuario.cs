﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(150, ErrorMessage = "O campo deve ter no máximo 150 caracteres!")]
        [Display(Name = "Nome do usuário")]
        public string NomeUsuario { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(11, ErrorMessage = "O campo deve ter no mínimo 11 caracteres!")]
        [MaxLength(11, ErrorMessage = "O campo deve ter no máximo 11 caracteres!")]
        [Display(Name = "CPF do usuário")]
        public int CPFUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail do usuário")]
        public string EmailUsuario { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "E-mail do usuário")]
        public string SenhaUsuario { get; set; }
    }
}