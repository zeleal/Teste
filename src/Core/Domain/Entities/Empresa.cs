using Domain.ValueObjects;
using Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empresa : BaseEntity
    {
        public Empresa(string nomeFantasia, string razaoSocial, string cnpj)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
        }

        private Empresa() // ORM
        {
        }

        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }


        /* EF Relations */
        //public ICollection<UsuarioEmpresa> UsuarioEmpresas { get; set; }
    }
}
