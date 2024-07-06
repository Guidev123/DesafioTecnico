using DesafioTec.Business.Entities;
using DesafioTec.Business.Interfaces.Repository;

namespace DesafioTec.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DesafioTecDb context) : base(context) { }

    }
}
