using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess.Conexion;
using CGC_GM_BE.DataAccess.Implement;

namespace CGC_GM_BE.DataAccess.Conexion
{
    public class AjustesComandosGenerico : IDisposable
    {
        public SqlConnection Conexion { get; protected set; }
        public SqlTransaction Transaccion { get; protected set; }
        public List<Exception> Excepciones { get; protected set; }
        public int TimeOut { get; protected set; }

        /// <summary>
        /// Inicializa los
        /// </summary>
        public AjustesComandosGenerico(int TimeOut)
        {
            // Incializando lista de excepciones, 0 errores:
            if (this.Excepciones == null)
            {
                this.Excepciones = new List<Exception>();
            }

            // Inicializa el tiempo de espera para cada comando
            this.TimeOut = TimeOut;

            try
            {
                // Inicializa una conexion:
                if (this.Conexion == null)
                {
                    this.Conexion = BaseDeDatos.Conectar_CGC_GM();
                }

                // Iniciliza una transaccion:
                if (this.Transaccion == null)
                {
                    this.Transaccion = Conexion.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                Excepciones.Add(ex);
            }
            finally
            {
                if (Excepciones.Count > 0)
                {
                    this.TimeOut = 0;
                }
            }
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
