
using System;
using System.Collections.Generic;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class UserController
    {
        public static Usuario InsertUser(string Nome, string Email, string Senha)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");

            if (String.IsNullOrEmpty(Nome))
            {
                throw new Exception("Nome não pode ficar em branco");
            }
            if (!validateEmailRegex.IsMatch(Email))
            {
                throw new Exception("Por favor digite um e-mail válido!");
            }
            if (String.IsNullOrEmpty(Senha) || Senha.Length < 8)
            {
                throw new Exception("Sua senha deve ter no minimo 8 dígitos");
            }
            else
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
            }

            return new Usuario(Nome, Email, Senha);
        }

        public static void UpdateUser(int Id, string Nome, string Email, string Senha)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            Usuario usuario = Models.Usuario.GetUsuario(Id);

            if (!String.IsNullOrEmpty(Nome))
            {
                usuario.Nome = Nome;
            }

            if (validateEmailRegex.IsMatch(Email))
            {
                usuario.Email = Email;
            }
            else
            {
                throw new Exception("Por favor digite um e-mail válido!");
            }

            if (!String.IsNullOrEmpty(Senha) || Senha.Length! < 8)
            {
                Senha = BCrypt.Net.BCrypt.HashPassword(Senha);
                usuario.Senha = Senha;
            }
            else
            {
                throw new Exception("Sua senha deve ter no minimo 8 dígitos");
            }

            Usuario.AlterarUsuario(Id, Nome, Email, Senha);
        }

        public static Usuario DeleteUser(int Id)
        {
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            Usuario.RemoverUsuario(usuario);
            return usuario;
        }

        public static IEnumerable<Usuario> SelectAllUsers()
        {
            return Models.Usuario.GetUsuarios();
        }
    }
}