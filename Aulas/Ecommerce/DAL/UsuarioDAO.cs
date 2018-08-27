﻿using Ecommerce.Models;
using System.Linq;

namespace Ecommerce.DAL
{
    public class UsuarioDAO
    {
        private static Context context = SingletonContext.GetInstance();
        
        public static Usuario Logar(Usuario usuario)
        {
            var usuarioLogado = context.Usuarios.Where(x => x.Login.Equals(usuario.EmailUsuario) && x.Senha.Equals(usuario.SenhaUsuario)).FirstOrDefault();

            if(usuarioLogado == null)
            {
                return null;
            }
            else
            {
                return usuarioLogado;
            }
        }
        public static bool CadastrarUsuario(Usuario usuario)
        {
            if(BuscarUsuarioPorLogin(usuario) == null)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Usuario BuscarUsuarioPorLogin(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.Login.Equals(usuario.EmailUsuario));
        }
    }
}