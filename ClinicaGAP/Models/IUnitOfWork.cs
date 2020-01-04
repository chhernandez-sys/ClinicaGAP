using ClinicaGAP.Models.Repositories;
using System;

namespace ClinicaGAP.Models
{
    public interface IUnitOfWork : IDisposable
    {
        ITipoCitaRepository TipoCita { get; }
        int Complete();
    }
}