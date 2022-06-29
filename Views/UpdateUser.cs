using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Views
{
    public class UpdateUser : Form
    {
        private IContainer components = null;
        Label lblNome;
        Label lblEmail;
        Label lblSenha;

        int Id;

        TextBox txtNome;
        TextBox txtEmail;
        TextBox txtSenha;

        Button btnConfirmar;
        Button btnCancelar;

        public UpdateUser(int Id)
        {
            this.Id = Id;
            Usuario usuario = Models.Usuario.GetUsuario(Id);
            this.lblNome = new Label();
            this.lblNome.Text = "Nome: ";
            this.lblNome.Location = new Point(110, 30);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(60, 60);
            this.txtNome.Size = new Size(180, 20);
            this.txtNome.Text = usuario.Nome;

            this.lblEmail = new Label();
            this.lblEmail.Text = "E-mail: ";
            this.lblEmail.Location = new Point(110, 90);

            this.txtEmail = new TextBox();
            this.txtEmail.Location = new Point(60, 115);
            this.txtEmail.Size = new Size(180, 20);
            this.txtEmail.Text = usuario.Email;

            this.lblSenha = new Label();
            this.lblSenha.Text = "Senha: ";
            this.lblSenha.Location = new Point(110, 140);

            this.txtSenha = new TextBox();
            this.txtSenha.Location = new Point(60, 170);
            this.txtSenha.Size = new Size(180, 20);
            this.txtSenha.PasswordChar = '*';

            this.btnConfirmar = new lib.Campos.ButtonField("Confirmar", 100, 200, 100, 30);
            btnConfirmar.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancelar = new lib.Campos.ButtonField("Cancelar", 100, 230, 100, 30);
            btnCancelar.Click += new EventHandler(this.btnCancelarClick);


            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Atualizar Usuário";
        }

        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                UserController.UpdateUser(Id, this.txtNome.Text, this.txtEmail.Text, this.txtSenha.Text);
                MessageBox.Show("Usuário(a) atualizado(a) com sucesso");
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao atualizar o Usuário(a), tente novamente");
            }
        }
    }
}