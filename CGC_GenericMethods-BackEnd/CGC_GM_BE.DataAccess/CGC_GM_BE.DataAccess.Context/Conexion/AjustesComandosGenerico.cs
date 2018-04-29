using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess.Context.Conexion;
using CGC_GM_BE.DataAccess.Context.GenericInterface;

namespace CGC_GM_BE.DataAccess.Context.Conexion
{
    public class AjustesComandosGenerico : IDisposable
    {
        protected SqlConnection Conexion { get; set; }
        protected SqlTransaction Transaccion { get; set; }
        protected List<Exception> Excepciones { get; set; }
        protected int TimeOut { get; set; }

        /// <summary>
        /// Inicializa los
        /// </summary>
        public AjustesComandosGenerico(int TimeOut)
        {
            // Inicializa una conexion:
            this.Conexion = BaseDeDatos.Conectar();

            // Iniciliza una transaccion:
            this.Transaccion = Conexion.BeginTransaction();

            // Incializando lista de excepciones, 0 errores:
            this.Excepciones = new List<Exception>();

            // Inicializa el tiempo de espera para cada comando
            this.TimeOut = TimeOut;
        }

        /// <summary>
        /// Guarda el estado de la transacción a un puto especifico, si se llama a rollback
        /// se realiza hasta este punto.
        /// </summary>
        public void Save(string SavePointName)
        {
            if (Transaccion != null)
                Transaccion.Save(SavePointName);
        }

        /// <summary>
        /// Realiza rollback a un punto guardado de la transacción
        /// </summary>
        public void Rollback()
        {
            if (Transaccion != null)
                Transaccion.Rollback();
        }

        /// <summary>
        /// Guarda los cambios dentro de la base de datos
        /// </summary>
        public void Commit()
        {
            if (Transaccion != null)
                Transaccion.Commit();
        }

        /// <summary>
        /// Guarda la transacción si ha sido exitosa. Si ha fallado, se realiza Rollback.
        /// </summary>
        public void CommitOrRollback()
        {
            if (Excepciones.Count > 0)
            {
                Rollback();

                // Registrar excepciones
            }
            else
            {
                Commit();
            }
        }

        /// <summary>
        /// Libera recursos utilizados en la transacción
        /// </summary>
        public void Dispose()
        {
            CommitOrRollback();

            Transaccion.Dispose();
            Conexion.Dispose();
        }
    }
}
