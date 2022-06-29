using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using Controllers;

namespace Views
{
    public class Password : Form
    {
        private System.ComponentModel.IContainer components = null;
        ListView lstSenhas;
        Button btnInserir;
        Button btnUpdate;
        Button btnDelete;
        Button btnVoltar;

        public Password()
        {
            lstSenhas = new ListView();
            lstSenhas.Location = new Point(50, 50);
            lstSenhas.Size = new Size(400, 320);
            lstSenhas.View = View.Details;
            foreach (Senha i in PasswordController.SelectAllPasswords())
            {
                ListViewItem list = new ListViewItem(i.Id + "");
                list.SubItems.Add(i.Nome);
                list.SubItems.Add(i.Categoria.ToString());
                list.SubItems.Add(i.Url);
                lstSenhas.Items.AddRange(new ListViewItem[] { list });
            }
            lstSenhas.Columns.Add("ID", -2, HorizontalAlignment.Left);
            lstSenhas.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lstSenhas.Columns.Add("Categoria", -2, HorizontalAlignment.Left);
            lstSenhas.Columns.Add("Url", -2, HorizontalAlignment.Left);
            lstSenhas.FullRowSelect = true;
            lstSenhas.GridLines = true;
            lstSenhas.AllowColumnReorder = true;
            lstSenhas.Sorting = SortOrder.Ascending;

            this.btnInserir = new ButtonField("Inserir", 50, 380, 100, 30);
            btnInserir.Click += new EventHandler(this.btnInserirClick);

            this.btnUpdate = new ButtonField("Update", 150, 380, 100, 30);
            btnUpdate.Click += new EventHandler(this.btnUpdateClick);

            this.btnDelete = new ButtonField("Delete", 250, 380, 100, 30);
            btnDelete.Click += new EventHandler(this.btnDeleteClick);

            this.btnVoltar = new ButtonField("Voltar", 350, 380, 100, 30);
            btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lstSenhas);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Senhas";
        }

        private void btnVoltarClick(object sender, EventArgs e)
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

        public void btnDeleteClick(object sender, EventArgs e)
        {
            string message = "Você realmente deseja excluir a senha?";
            string caption = "Excluir";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (lstSenhas.SelectedItems.Count > 0)
                    {
                        ListViewItem li = lstSenhas.SelectedItems[0];
                        MessageBox.Show("A senha" + li.Text + " foi deletado com sucesso!", "Excluido");
                        PasswordController.DeletePassword(Convert.ToInt32(li.Text));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao deletar", "Erro");
                }
            }
        }

        private void btnInserirClick(object sender, EventArgs e)
        {
            InsertPassword insertPassword = new InsertPassword(this);
            insertPassword.ShowDialog();
        }

        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (lstSenhas.SelectedItems.Count > 0)
            {
                ListViewItem li = lstSenhas.SelectedItems[0];

                UpdatePassword updatePassword = new UpdatePassword(Convert.ToInt32(li.Text), this);
                updatePassword.ShowDialog();
            }
        }
    }
}