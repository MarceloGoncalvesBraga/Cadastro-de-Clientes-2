using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_de_Clientes.Modelo
{
    public class Clientes
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Data_Nascimento { get; set; }
        public string Email { get; set; }
        //[Required, EmailAddress, StringLength(70, MinimumLength = 5)]
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }
        public DateTime Data_Cadastro { get; set; }
        public Nullable<DateTime> Data_Atualizado { get; set; }

    }
}
