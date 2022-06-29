using System;
using System.Windows.Forms;
using System.Drawing;
using lib;
using Models;

namespace Views
{
    public delegate void HandleButton(object sender, EventArgs e);
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Login());
        }
    }

    public class Login : Form
    {
        readonly Campos.Field fieldUser;
        readonly Campos.Field fieldPass;
        readonly Button btnConfirm;
        readonly Button btnSair;

        public Login()

        {
            this.ClientSize = new Size(300, 300);
            this.fieldUser = new Campos.Field(this.Controls, "Usuário", 20, true);
            this.fieldPass = new Campos.Field(this.Controls, "Senha", 80, true, true);
            this.btnConfirm = new Campos.ButtonForm(this.Controls, "Confirmar", 100, 180, this.handleConfirmClick);
            this.btnSair = new Campos.ButtonForm(this.Controls, "Cancelar", 100, 220, this.handleCancelClick);

        }

        private void handleConfirmClick(object sender, EventArgs e)
        {
            DialogResult result;

            result = MessageBox.Show(
                $"Usuário: {this.fieldUser.textField.Text}",
                "Titulo da Mensagem",
                MessageBoxButtons.YesNo
            );

            if (result == DialogResult.Yes)
            {
                Menu Menus = new Menu();
                Menus.ShowDialog();
            }
            else
            {
                Console.WriteLine("Clicou não");
            }
        }

        private void handleCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}