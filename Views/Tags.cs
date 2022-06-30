using System;
using System.Drawing;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Views
{
    public class Tags : Form
    {
        private System.ComponentModel.IContainer components = null;
        ListView lstTags;
        Button btnInserir;
        Button btnUpdate;
        Button btnDelete;
        Button btnVoltar;

        public Tags()
        {
            lstTags = new ListView();
            lstTags.Location = new Point(50, 50);
            lstTags.Size = new Size(400, 320);
            lstTags.View = View.Details;
            foreach (Tag i in TagController.SelectAllTags())
            {
                ListViewItem list = new ListViewItem(i.Id + "");
                list.SubItems.Add(i.Descricao);
                lstTags.Items.AddRange(new ListViewItem[] { list });
            }

            lstTags.Columns.Add("ID", -2, HorizontalAlignment.Left);
            lstTags.Columns.Add("Descrição", -2, HorizontalAlignment.Left);
            lstTags.FullRowSelect = true;
            lstTags.GridLines = true;
            lstTags.AllowColumnReorder = true;
            lstTags.Sorting = SortOrder.Ascending;

            this.btnInserir = new ButtonField("Inserir", 50, 380, 100, 30);
            btnInserir.Click += new EventHandler(this.btnInserirClick);

            this.btnUpdate = new ButtonField("Editar", 150, 380, 100, 30);
            btnUpdate.Click += new EventHandler(this.btnUpdateClick);

            this.btnDelete = new ButtonField("Delete", 250, 380, 100, 30);
            btnDelete.Click += new EventHandler(this.btnDeleteClick);

            this.btnVoltar = new ButtonField("Voltar", 350, 380, 100, 30);
            btnVoltar.Click += new EventHandler(this.btnVoltarClick);

            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lstTags);

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Text = "Tags";


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
            string message = "Você realmente deseja excluir a tag?";
            string caption = "Excluir";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons); ;

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (lstTags.SelectedItems.Count > 0)
                    {
                        ListViewItem li = lstTags.SelectedItems[0];
                        TagController.DeleteTag(Convert.ToInt32(li.Text));
                        MessageBox.Show("Tag" + li.Text + " foi deletado com sucesso!", "Sucesso");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao deletar tag", "Erro");
                }
            }
        }

        private void btnInserirClick(object sender, EventArgs e)
        {
            InsertTag insertTag = new InsertTag();
            insertTag.ShowDialog();
        }

        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (lstTags.SelectedItems.Count > 0)
            {
                ListViewItem li = lstTags.SelectedItems[0];

                UpdateTag updateTag = new UpdateTag(Convert.ToInt32(li.Text));
                updateTag.ShowDialog();
            }
        }
    }
}