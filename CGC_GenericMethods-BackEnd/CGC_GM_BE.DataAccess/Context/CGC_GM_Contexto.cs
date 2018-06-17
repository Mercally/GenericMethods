using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.DataAccess.Connection;
using CGC_GM_BE.DataAccess.Model;

namespace CGC_GM_BE.DataAccess.Context
{
    /// <summary>
    /// Almacena todas las clases de modelo de la base de datos
    /// </summary>
    public class CGC_GM_Contexto : IDisposable
    {
        private Comandos _Comandos { get; set; }
        public SqlConnection Conexion { get; protected set; }
        public SqlTransaction Transaccion { get; protected set; }
        public List<Exception> Excepciones { get; protected set; }
        public int TimeOut { get; protected set; }

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

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public CGC_GM_Contexto()
        {
            this.Excepciones = new List<Exception>();

            try
            {
                // Inicializa una conexion:
                if (this.Conexion == null)
                {
                    this.Conexion = BaseDeDatos.Conectar_CGC_GM();
                }

                // Iniciliza una transaccion:
                if (this.Transaccion == null && this.Conexion != null)
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

            this._Comandos = new Comandos(this.Transaccion);
        }

        public Comandos Comandos
        {
            get
            {
                return _Comandos;
            }
        }

        public Seg_Usuario_Model Seg_Usuario_Model
        {
            get
            {
                return new Seg_Usuario_Model();
            }
        }

        public Age_Agenda_Model Age_Agenda_Model
        {
            get
            {
                return new Age_Agenda_Model();
            }
        }

        public Age_Tarea_Model Age_Tarea_Model
        {
            get
            {
                return new Age_Tarea_Model();
            }
        }

        public Cat_Catalogos Cat_Catalogos
        {
            get
            {
                return new Cat_Catalogos();
            }
        }
    }
}
