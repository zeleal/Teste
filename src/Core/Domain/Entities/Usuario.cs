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
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }


        /* EF Relations */
        public Endereco Endereco { get; set; } 
        public ICollection<UsuarioEmpresa> UsuarioEmpresas { get; set; } = new List<UsuarioEmpresa>();
    }
}
