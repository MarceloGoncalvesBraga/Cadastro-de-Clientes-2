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
    public partial class Tela_de_Cadastro : Form
    {
        public Tela_de_Cadastro()
        {
            InitializeComponent();
        }

        private void Tela_de_Cadastro_Load(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
