using System;
using System.Drawing;
using System.Windows.Forms;
using Views;

namespace Views
{
    public class Menu : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblMenu;
        Button btnSair;
        Button btnCategoria;
        Button btnTags;
        Button btnSenhas;
        Button btnUsuario;

        public Menu()
        {

            this.lblMenu = new Label();
            this.lblMenu.Text = " Menu ";
            this.lblMenu.Location = new Point(135, 20);

            this.btnCategoria = new ButtonField("Categorias", 40, 50, 100, 30);
            btnCategoria.Click += new EventHandler(this.btnCategoriasClick);

            this.btnTags = new ButtonField("Tags", 40, 90, 100, 30);
            btnTags.Click += new EventHandler(this.btnTagsClick);

            this.btnSenhas = new ButtonField("Senhas", 170, 90, 100, 30);
            btnSenhas.Click += new EventHandler(this.btnSenhaClick);

            this.btnUsuario = new ButtonField("Usuário", 170, 50, 100, 30);
            btnUsuario.Click += new EventHandler(this.btnUsuarioClick);

            this.btnSair = new ButtonField("Sair", 105, 170, 100, 30);
            btnSair.Click += new EventHandler(this.btnSairClick);


            this.Controls.Add(this.btnCategoria);
            this.Controls.Add(this.btnTags);
            this.Controls.Add(this.btnSenhas);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.lblMenu);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = $"Olá, bem vindo ao Encryptme";
        }

        private void btnTagsClick(object sender, EventArgs e)
        {
            Tags Tags = new Tags();
            Tags.ShowDialog();
        }

        private void btnCategoriasClick(object sender, EventArgs e)
        {
            Categorie categorie = new Categorie();
            categorie.ShowDialog();
        }

        private void btnSenhaClick(object sender, EventArgs e)
        {
            Password password = new Password();
            password.ShowDialog();
        }

        private void btnUsuarioClick(object sender, EventArgs e)
        {
            User user = new User();
            user.ShowDialog();
        }

        private void btnSairClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public class ButtonField : Button
        {
            public ButtonField(string Text, int x, int y, int Z, int P)
            {
                this.Text = Text;
                this.Location = new Point(x, y);
                this.Size = new Size(Z, P);
            }
        }

    }
}