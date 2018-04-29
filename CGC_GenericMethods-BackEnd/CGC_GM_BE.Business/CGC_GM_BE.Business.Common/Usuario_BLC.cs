using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context.GenericInterface;
using CGC_GM_BE.DataAccess.Model.Seguridad;

namespace CGC_GM_BE.Business.Common
{
    public class Usuario_BLC
    {
        public List<Usuario> ConsultaGenerica()
        {
            List<Usuario> Lista = new List<Usuario>();

            // Transaccion termina con el bloque using
            using (var ConsultasSegUsuario = new SegUsuario_Model())
            {
                Lista = ConsultasSegUsuario
                        .Consulta()
                        .ObtenerResultadoLista<Usuario>();

            }

            return Lista;
        }
    }
}
