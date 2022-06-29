using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Views
{
    public class UpdateCategorie : Form
    {
        private System.ComponentModel.IContainer components = null;
        Label lblNome;
        Label lblDescricao;
        TextBox txtNome;
        TextBox txtDescricao;
        int Id;
        Button btnConfirm;
        Button btnCancel;

        public UpdateCategorie(int Id)
        {
            this.Id = Id;
            Categoria categoria = Models.Categoria.GetCategoria(Id);
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";

            this.lblNome.Location = new Point(125, 30);
            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(60, 60);
            this.txtNome.Size = new Size(180, 20);
            this.txtNome.Text = categoria.Nome;

            Categoria categoria2 = Models.Categoria.GetCategoria(Id);
            this.lblDescricao = new Label();
            this.lblDescricao.Text = " Descrição ";
            this.lblDescricao.Location = new Point(125, 100);

            this.txtDescricao = new TextBox();
            this.txtDescricao.Location = new Point(60, 130);
            this.txtDescricao.Size = new Size(180, 20);
            this.txtDescricao.Text = categoria.Descricao;

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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Atualizar Categoria";
        }

        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                CategorieController.UpdateCategorie(Id, this.txtNome.Text, this.txtDescricao.Text);
                MessageBox.Show("Categoria atualizada com sucesso");
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao atualizar a categoria, tente novamente");
            }
        }
    }
}