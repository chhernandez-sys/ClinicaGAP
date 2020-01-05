using ClinicaGAP.Models;

namespace ClinicaGAP.Services
{
    public class ServicioAdministracion
    {
        public bool ObjetoEstadoEsValido(ESTADO Estado)
        {
            bool valido;

            if (Estado != null)
            {
                if (Estado.DESCRIPCION.Length <= 30)
                {
                    valido = true;
                }
                else
                {
                    valido = false;
                }
            }
            else
            {
                valido = false;
            }

            return valido;
        }
    }
}