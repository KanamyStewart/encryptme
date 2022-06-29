using System;
using System.Drawing;
using System.Windows.Forms;
using Models;
using Controllers;

namespace Views
{
    public class User : Form
    {
        private System.ComponentModel.IContainer components = null;
        ListView lstUsuario;
        Button btnInserir;
        Button btnUpdate;
        Button btnDelete;
        Button btnVoltar;

        public User()
        {
            lstUsuario = new ListView();
            lstUsuario.Location = new Point(50, 50);
            lstUsuario.Size = new Size(400, 320);
            lstUsuario.View = View.Details;
            foreach (Usuario i in UserController.SelectAllUsers())
            {
                ListViewItem list = new ListViewItem(i.Id + "");
                list.SubItems.Add(i.Nome);
                list.SubItems.Add(i.Email);
                lstUsuario.Items.AddRange(new ListViewItem[] { list });
            }
            lstUsuario.Columns.Add("ID", -2, HorizontalAlignment.Left);
            lstUsuario.Columns.Add("Nome", -2, HorizontalAlignment.Left);
            lstUsuario.Columns.Add("Email", -2, HorizontalAlignment.Left);
            lstUsuario.FullRowSelect = true;
            lstUsuario.GridLines = true;
            lstUsuario.AllowColumnReorder = true;
            lstUsuario.Sorting = SortOrder.Ascending;

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
            this.Controls.Add(this.lstUsuario);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "User";


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
            string message = "Você realmente deseja excluir usuário?";
            string caption = " Excluir";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (lstUsuario.SelectedItems.Count > 0)
                    {
                        ListViewItem li = lstUsuario.SelectedItems[0];
                        MessageBox.Show("Registro de usuário" + li.Text + " foi deletado com sucesso!", "Sucesso");
                        UserController.DeleteUser(Convert.ToInt32(li.Text));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao deletar usuário", "Erro");
                }
            }
        }

        private void btnInserirClick(object sender, EventArgs e)
        {

            InsertUser insertUser = new InsertUser();
            insertUser.ShowDialog();
        }

        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (lstUsuario.SelectedItems.Count > 0)
            {
                ListViewItem li = lstUsuario.SelectedItems[0];

                UpdateUser updateUser = new UpdateUser(Convert.ToInt32(li.Text));
                updateUser.ShowDialog();
            }
        }
    }
}