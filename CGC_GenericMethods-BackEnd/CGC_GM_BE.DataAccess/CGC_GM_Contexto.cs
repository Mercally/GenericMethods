using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CGC_GM_BE.DataAccess.Conexion;
using CGC_GM_BE.DataAccess.Modelo;
using CGC_GM_BE.DataAccess.Interfaces;
using CGC_GM_BE.Common.Entities;

namespace CGC_GM_BE.DataAccess
{
    /// <summary>
    /// Almacena todas las clases de modelo de la base de datos
    /// </summary>
    public class CGC_GM_Contexto : IDisposable, IContextoCustomizado
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public CGC_GM_Contexto()
        {
            this.ListaExcepciones = new List<Exception>();

            try
            {
                Byte Pasos = 0;
                // Inicializa una conexion:
                if (this.Conexion == null)
                {
                    this.Conexion = BaseDeDatos.Conectar_CGC_GM();
                    Pasos += 1;
                }

                // Iniciliza una transaccion:
                if (this.Transaccion == null && this.Conexion != null)
                {
                    this.Transaccion = Conexion.BeginTransaction();
                    Pasos += 2;
                }

                if (Pasos == 3)
                {
                    Comandos = new Comandos(Transaccion);
                }
            }
            catch (Exception ex)
            {
                ListaExcepciones.Add(ex);
            }
            finally
            {
                if (ListaExcepciones.Count > 0)
                {
                    this.TimeOut = 0;
                }
            }
        }

        private Comandos Comandos { get; set; }
        public SqlConnection Conexion { get; protected set; }
        public SqlTransaction Transaccion { get; protected set; }
        public List<Exception> ListaExcepciones { get; protected set; }
        public int TimeOut { get; protected set; }

        public void Excepciones(Exception Ex)
        {
            if (ListaExcepciones != null)
            {
                if (Ex != null)
                {
                    ListaExcepciones = new List<Exception>() { Ex };
                }
                else
                {
                    ListaExcepciones = new List<Exception>();
                }
            }
            else
            {
                if (Ex != null)
                {
                    ListaExcepciones.Add(Ex);
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
            if (ListaExcepciones.Count > 0)
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
            if (this == null)
            {
                return;
            }
            CommitOrRollback();

            Transaccion.Dispose();
            Conexion.Dispose();
        }

        /// <summary>
        /// Ejecuta una consulta
        /// </summary>
        /// <param name="Consulta">Consulta a ejecutar</param>
        /// <returns></returns>
        public _ResultadoDB Ejecutar(_ConsultaT_Sql Consulta)
        {
            return Comandos.Ejecutar(Consulta);
        }

        public _ResultadoV2 EjecutarV2(_ConsultaT_Sql Consulta)
        {
            return Comandos.EjecutarV2(Consulta);
        }

        /*
         * Accesores a modelos
         */

        public Com_ActividadesModelo Com_ActividadesModelo
        {
            get
            {
                return new Com_ActividadesModelo(this);
            }
        }

        public Com_BoletasModelo Com_BoletasModelo
        {
            get
            {
                return new Com_BoletasModelo(this);
            }
        }

        public Cat_CatalogosModelo Cat_CatalogosModelo
        {
            get
            {
                return new Cat_CatalogosModelo(this);
            }
        }

        public Neg_ClientesModelo Neg_ClientesModelo
        {
            get
            {
                return new Neg_ClientesModelo(this);
            }
        }

        public Neg_ProyectosModelo Neg_ProyectosModelo
        {
            get
            {
                return new Neg_ProyectosModelo(this);
            }
        }

        public Seg_UsuariosModelo Seg_UsuariosModelo
        {
            get
            {
                return new Seg_UsuariosModelo(this);
            }
        }
    }
}