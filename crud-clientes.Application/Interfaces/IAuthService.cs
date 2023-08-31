using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud_clientes.Application.Interfaces
{
    public interface IAuthService
    {
        string GerarJwtToken(string email, Guid usuarioId);
    }
}
