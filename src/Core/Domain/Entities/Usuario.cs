using Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string cpf, string nomeDaMae, string nomeDoPai, string email, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            NomeDaMae = nomeDaMae;
            NomeDoPai = nomeDoPai;
            Email = email;
            DataNascimento = dataNascimento;
        }

        private Usuario() // ORM
        {
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string NomeDaMae { get; set; }
        public string NomeDoPai { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }


        /* EF Relations */
        //public Endereco Endereco { get; set; }
        //public ICollection<UsuarioEmpresa> UsuarioEmpresas { get; set; }
    }
}
