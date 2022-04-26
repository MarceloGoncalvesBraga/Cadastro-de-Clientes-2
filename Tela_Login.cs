using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cadastro_de_Clientes
{
    public partial class Tela_Login : Form
    {
        public static bool Cancelar = false;
        public Tela_Login()
        {
            InitializeComponent();
        }

        private void Tela_Login_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cancelar = true;
            Close();
        }
    }
}
