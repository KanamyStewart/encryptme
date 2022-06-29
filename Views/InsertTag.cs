using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Views
{
    public class InsertTag : Form
    {
        private System.ComponentModel.IContainer components = null;

        Label lblDescricao;
        TextBox txtDescricao;
        Button btnConfirm;
        Button btnCancel;

        public InsertTag()
        {

            this.lblDescricao = new Label();
            this.lblDescricao.Text = " Descrição ";
            this.lblDescricao.Location = new Point(120, 40);

            this.txtDescricao = new TextBox();
            this.txtDescricao.Location = new Point(60, 80);
            this.txtDescricao.Size = new Size(180, 20);

            this.btnConfirm = new lib.Campos.ButtonField("Confirmar", 100, 170, 100, 30);
            btnConfirm.Click += new EventHandler(this.btnConfirmarClick);

            this.btnCancel = new lib.Campos.ButtonField("Cancelar", 100, 200, 100, 30);
            btnCancel.Click += new EventHandler(this.btnCancelarClick);

            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = "Cadastrar Tag";
        }

        private void btnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                TagController.InsertTag(this.txtDescricao.Text);
                MessageBox.Show("Tag cadastrada com sucesso");
            }
            catch (System.Exception)
            {

                throw new Exception("Erro ao cadastrar tag, tente novamente");
            }
        }
    }
}