using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD2AEMANUEL.Model
{
    public class Pessoa
    {
        //Encapsulamento
        public int Id { get; set; }
        public int Nome { get; set; }
        public int Nascimento { get; set; }
        public int Sexo { get; set; }
        public int Cpf { get; set; }
        public int Celular { get; set; }
        public int Endereco { get; set; }
        public int Bairro { get; set; }
        public int Cidade { get; set; }
        public int Estado { get; set; }
        public int Cep { get; set; }
    }
}
