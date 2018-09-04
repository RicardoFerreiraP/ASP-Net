using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.DAL
{
    public class UsuarioDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<Usuario> RetornarUsuarios()
        {
            return context.Usuarios.ToList();
        }

        public static bool CadastrarUsuario(Usuario usuario)
        {
            if (BuscarUsuarioPorLogin(usuario) == null)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Usuario BuscarUsuarioPorLogin(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.EmailUsuario.Equals(usuario.EmailUsuario));
        }

        public static Usuario Login(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.EmailUsuario.Equals(usuario.EmailUsuario) && (x.SenhaUsuario.Equals(usuario.SenhaUsuario)));
        }

    }
}