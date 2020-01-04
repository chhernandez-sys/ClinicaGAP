using System.Collections.Generic;

namespace ClinicaGAP.Models.Repositories
{
    public interface ITipoCitaRepository : IRepository<TIPO_CITA>
    {
        IEnumerable<TIPO_CITA> GetTiposCita();
    }
}