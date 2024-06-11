using Shared.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsuarioEmpresa : BaseEntity
    {
        public Guid UsuarioId { get; set; }
        //public Usuario Usuario { get; set; }
        public Guid EmpresaId { get; set; }
        //public Empresa Empresa { get; set; }
    }
}
