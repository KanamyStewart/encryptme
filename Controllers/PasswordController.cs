using System;
using System.Collections.Generic;
using Models;

namespace Controllers
{
    public class PasswordController
    {
        public static Senha InsertPassword(string Nome, int CategoriaId, string Url, string Usuario, string SenhaEncrypt, string Procedimento)
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome não pode ficar me branco");
            }

            return new Senha(Nome, CategoriaId, Url, Usuario, SenhaEncrypt, Procedimento);
        }

        public static void UpdatePassword(int Id, string Nome, int CategoriaId, string Url, string Usuario, string SenhaEncrypt, string Procedimento)
        {
            Senha senha = Models.Senha.GetSenha(Id);
            if (!String.IsNullOrEmpty(Nome) && !String.IsNullOrEmpty(Url) && !String.IsNullOrEmpty(Usuario) && !String.IsNullOrEmpty(SenhaEncrypt) && !String.IsNullOrEmpty(Procedimento) && CategoriaId != 0)
            {
                senha.Nome = Nome;
                senha.Url = Url;
                senha.Usuario = Usuario;
                senha.SenhaEncrypt = SenhaEncrypt;
                senha.Procedimento = Procedimento;
                senha.CategoriaId = CategoriaId;
            }

            Senha.AlterarSenha(Id, Nome, CategoriaId, Url, Usuario, SenhaEncrypt, Procedimento);
        }

        public static Senha DeletePassword(int Id)
        {
            Senha senha = Models.Senha.GetSenha(Id);
            Senha.RemoverSenha(senha);
            return senha;
        }

        public static IEnumerable<Senha> SelectAllPasswords()
        {
            return Models.Senha.GetSenhas();
        }
    }
}