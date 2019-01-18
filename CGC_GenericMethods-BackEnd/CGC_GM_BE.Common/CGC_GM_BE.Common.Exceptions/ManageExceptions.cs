using CGC_GM_BE.Common.Entities.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGC_GM_BE.Common.Exceptions
{
    public class ManageExceptions
    {
        public static void AddExceptionBL<T>(_Resultado<T> pObjeto, Exception ex)
        {
            try
            {
                if (pObjeto == null)
                {
                    pObjeto = new _Resultado<T>(ex);
                }
                else
                {
                    pObjeto.ListaErrores.Add(ex);
                }
            }
            catch (Exception exOut)
            {
                throw exOut;
            }
        }
    }
}
