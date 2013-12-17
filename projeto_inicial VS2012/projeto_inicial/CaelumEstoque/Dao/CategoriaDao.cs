using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaelumEstoque.Models;
using System.Data;

namespace CaelumEstoque.Dao
{
    public class CategoriaDao
    {
        public List<CategoriaDoProduto> Lista()
        {
            List<CategoriaDoProduto> categorias = new List<CategoriaDoProduto>();
            DBSession session = new DBSession();
            IDataReader reader = session.CreateQuery("select * from categorias").ExecuteQuery();
            while (reader.Read())
            {
                categorias.Add(new CategoriaDoProduto
                {
                    Nome = Convert.ToString(reader["nome"]),
                    Id = Convert.ToInt32(reader["id"]),
                    Descricao = Convert.ToString(reader["descricao"])
                });
            }
            reader.Close();
            return categorias;
        }

        public void Salva(CategoriaDoProduto categoria)
        {
            DBSession session = new DBSession();
            Query query = session.CreateQuery("insert into categorias (nome, descricao) values (@nome, @descricao)");
            query.SetParameter("nome", categoria.Nome)
                 .SetParameter("descricao", categoria.Descricao);
            query.ExecuteUpdate();
        }

        public CategoriaDoProduto BuscaPorId(int id)
        {
            DBSession session = new DBSession();
            Query query = session.CreateQuery("select * from categorias where id = @id");
            query.SetParameter("id", id);
            IDataReader reader = query.ExecuteQuery();
            CategoriaDoProduto categoria = null;
            if (reader.Read())
            {
                categoria = new CategoriaDoProduto
                {
                    Nome = Convert.ToString(reader["nome"]),
                    Id = Convert.ToInt32(reader["id"]),
                    Descricao = Convert.ToString(reader["descricao"])
                };
            }
            return categoria;
        }
    }
}