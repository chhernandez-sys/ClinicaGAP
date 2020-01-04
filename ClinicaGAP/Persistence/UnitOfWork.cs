using ClinicaGAP.Models;
using ClinicaGAP.Models.Repositories;
using ClinicaGAP.Persistence.Repositories;

namespace ClinicaGAP.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicaGAPEntities _context;

        public UnitOfWork(ClinicaGAPEntities context)
        {
            _context = context;
            TipoCita = new TipoCitaRepository(_context);
        }

        public ITipoCitaRepository TipoCita { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}