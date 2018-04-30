using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context;

namespace CGC_GM_BE.Business
{
    public class Usuario_BL
    {
        public List<Usuario> ConsultaGenerica()
        {
            List<Usuario> Lista = new List<Usuario>();

            // Transacción termina con el bloque using
            using (var DBContexto = new CGC_GM_Contexto())
            {
                Lista = DBContexto
                    .Seg_Usuario_Model
                    .Consulta()
                    .ObtenerResultadoLista<Usuario>();

            }

            return Lista;
        }
    }
}
