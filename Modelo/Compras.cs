using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cadastro_de_Clientes.Modelo;

namespace Cadastro_de_Clientes.Modelo
{
    public class Compras //: Clientes
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Produto_Id { get; set; }
        public string Data_Compra { get; set; }
        public string Email { get; set; }

    }
}
