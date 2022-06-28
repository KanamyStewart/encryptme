using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class CategorieController
    {
        public static Categoria InsertCategorie(string Nome, string Descricao)
        {
            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome não pode ficar em branco!");
            }

            return new Categoria(Nome, Descricao);
        }

        public static void UpdateCategorie(int Id, string Nome, string Descricao)
        {
            Categoria categoria = Models.Categoria.GetCategoria(Id);

            if (!String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Descricao))
            {
                categoria.Nome = Nome;
                categoria.Descricao = Descricao;
            }
            else
            {
                throw new Exception("Nome e descrição não pode ficar em branco!");
            }

            Categoria.AlterarCategoria(Id, Nome, Descricao);
        }

        public static Categoria DeleteCategorie(int Id)
        {
            Categoria categoria = Models.Categoria.GetCategoria(Id);
            Categoria.RemoverCategoria(categoria);
            return categoria;
        }

        public static IEnumerable<Categoria> SelectAllCategories()
        {
            return Models.Categoria.GetCategorias();
        }
    }
}