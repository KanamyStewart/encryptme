using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class TagController
    {
        public static Tag InsertTag(string Descricao)
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição não pode ficar em branco");
            }
            return new Tag(Descricao);
        }

        public static void UpdateTag(int Id, string Descricao)
        {
            Tag tag = Models.Tag.GetTag(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                tag.Descricao = Descricao;
            }

            Tag.AlterarTag(Id, Descricao);
        }

        public static Tag DeleteTag(int Id)
        {
            Tag tag = Models.Tag.GetTag(Id);
            Tag.RemoverTag(tag);
            return tag;
        }

        public static IEnumerable<Tag> SelectAllTags()
        {
            return Models.Tag.GetTags();
        }
    }
}