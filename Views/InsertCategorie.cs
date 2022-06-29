using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;

namespace Views
{
    public class InsertCategorie : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblNome;
        Label lblDescricao;
        TextBox txtNome;
        TextBox txtDescricao;

        Button btnConfirm;
        Button btnCancel;

        public InsertCategorie()
        {

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(125, 30);


            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(60, 60);
            this.txtNome.Size = new Size(180, 20);


            this.lblDescricao = new Label();
            this.lblDescricao.Text = " Descrição ";
            this.lblDescricao.Location = new Point(125, 100);

            this.txtDescricao = new TextBox();
            this.txtDescricao.Location = new Point(60, 130);
            this.txtDescricao.Size = new Size(180, 20);

            this.btnConfirm = new lib.Campos.ButtonField("Confirmar", 100, 170, 100, 30);
            btnConfirm.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancel = new lib.Campos.ButtonField("Cancelar", 100, 200, 100, 30);
            btnCancel.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 300);
            this.Text = "Cadastrar Categoria";
        }

        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                CategorieController.InsertCategorie(this.txtNome.Text, this.txtDescricao.Text);
                MessageBox.Show("Categoria cadastrada com sucesso");
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao inserir a categoria, tente novamente");
            }
        }
    }
}