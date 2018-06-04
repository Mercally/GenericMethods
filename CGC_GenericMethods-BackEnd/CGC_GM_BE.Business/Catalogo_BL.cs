using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Context;

namespace CGC_GM_BE.Business
{
    public class Catalogo_BL
    {
        public List<Catalogo> Consulta(string Tabla, string Campo)
        {
            List<Catalogo> Lista = new List<Catalogo>();
            
            using (var DBContexto = new CGC_GM_Contexto())
            {
                Lista = DBContexto
                    .Cat_Catalogos
                    .Consulta(Tabla, Campo)
                    .ObtenerResultadoLista<Catalogo>();

            }

            return Lista;
        }

        public Catalogo ConsultaPorId(int Id)
        {
            Catalogo Cat = new Catalogo();

            using (var DBContexto = new CGC_GM_Contexto())
            {
                Cat = DBContexto
                    .Cat_Catalogos
                    .ConsultaPorId(Id)
                    .ObtenerResultadoUnico<Catalogo>();

            }

            return Cat;
        }
    }
}
