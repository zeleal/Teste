using Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario( string nome, string cpf, string nomeDaMae, string nomeDoPai, string email, DateTime dataNascimento)
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
        [RegularExpression("^[0-9]+$", ErrorMessage = "O campo CPF deve conter apenas números.")]
        public string Cpf { get; set; }
        public string NomeDaMae { get; set; }
        public string NomeDoPai { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }



        /* EF Relations */
        public Endereco Endereco { get; set; }
        public ICollection<UsuarioEmpresa> UsuarioEmpresas { get; set; }
    }
}
