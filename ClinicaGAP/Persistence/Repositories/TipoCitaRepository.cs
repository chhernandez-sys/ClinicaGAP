using ClinicaGAP.Models;
using ClinicaGAP.Models.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ClinicaGAP.Persistence.Repositories
{
    public class TipoCitaRepository : Repository<TIPO_CITA>, ITipoCitaRepository
    {
        public TipoCitaRepository(ClinicaGAPEntities context) : base(context)
        {
        }
        
        public IEnumerable<TIPO_CITA> GetTiposCita()
        {
            return ClinicaGAPEntities.TIPO_CITA.OrderByDescending(c => c.ID_TIPO_CITA).ToList();
        }
        
        public ClinicaGAPEntities ClinicaGAPEntities
        {
            get { return Context as ClinicaGAPEntities; }
        }
    }
}