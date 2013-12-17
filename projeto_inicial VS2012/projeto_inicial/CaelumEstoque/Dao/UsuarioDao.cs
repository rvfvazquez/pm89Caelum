using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaelumEstoque.Models;
using System.Data;

namespace CaelumEstoque.Dao
{
    public class UsuarioDao
    {
        public Usuario Busca(String usuario, String senha)
        {
            var session = new DBSession();
            Query query = session.CreateQuery("select * from usuarios where username=@usuario and senha=@senha");
            query.SetParameter("usuario", usuario);
            query.SetParameter("senha", senha);
            IDataReader reader = query.ExecuteQuery();
            Usuario user = null;
            if (reader.Read())
            {
                user = new Usuario
                {
                    Login = Convert.ToString(reader["username"]),
                    Senha = Convert.ToString(reader["senha"])
                };
            }
            return user;
        }
    }
}
