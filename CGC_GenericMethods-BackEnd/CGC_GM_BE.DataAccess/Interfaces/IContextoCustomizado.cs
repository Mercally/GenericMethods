using CGC_GM_BE.DataAccess.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.DataAccess.Interfaces
{
    public interface IContextoCustomizado
    {
        void CommitOrRollback();

        void Commit();

        void Save(string SavePointName);

        void Rollback();

        _Resultado Ejecutar(_ConsultaT_Sql Consulta);

        void Excepciones(Exception Excepcion);
    }
}
