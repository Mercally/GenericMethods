using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.Common.Entities;
using CGC_GM_BE.DataAccess.Modelo;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class _ResultadoV2
    {
        public int ResultadoTipoInsert { get; set; }
        public bool ResultadoTipoUpdate { get; set; }
        public bool ResultadoTipoDelete { get; set; }
        public SqlDataReader ResultadoTipoQuery { get; set; }
        public int CantidadCambios { get; set; }
        public System.Exception Excepcion { get; set; }

        public bool EsCorrecto
        {
            get
            {
                return ResultadoTipoQuery != null && Excepcion == null;
            }
        }

        /// <summary>
        /// Obtiene el resultado convertido al tipo especificado
        /// </summary>
        /// <typeparam name="T">Tipo de dato a retornar</typeparam>
        /// <returns>Lista de objetos de tipo especificado</returns>
        public List<Boleta> ConvertirResultadoLista()
        {
            if (!this.EsCorrecto)
            {
                return new List<Boleta>();
            }

            try
            {
                var ListaResultado = new List<Boleta>();

                while (ResultadoTipoQuery.Read())
                {
                    var Boleta = new Boleta()
                    {
                        Actividades = null,
                        Cliente = null,
                        ClienteId = int.Parse(ResultadoTipoQuery["ClienteId"].ToString()),
                        Departamento = null,
                        DepartamentoId = int.Parse(ResultadoTipoQuery["DepartamentoId"].ToString()),
                        Descripcion = ResultadoTipoQuery["Descripcion"].ToString(),
                        EsActivo = false,
                        FechaEntrada = DateTime.Parse(ResultadoTipoQuery["FechaEntrada"].ToString()),
                        FechaRegistro = DateTime.Parse(ResultadoTipoQuery["FechaRegistro"].ToString()),
                        FechaSalida = DateTime.Parse(ResultadoTipoQuery["FechaSalida"].ToString()),
                        Id = int.Parse(ResultadoTipoQuery["Id"].ToString()),
                        NumeroBoleta = ResultadoTipoQuery["NumeroBoleta"].ToString(),
                        Proyecto = null,
                        ProyectoId = int.Parse(ResultadoTipoQuery["ProyectoId"].ToString()),
                        TiempoEfectivo = decimal.Parse(ResultadoTipoQuery["TiempoEfectivo"].ToString()),
                        TiempoInvertido = null,
                        TiempoInvertidoEn = int.Parse(ResultadoTipoQuery["TiempoInvertidoEn"].ToString()),
                        Usuario = null,
                        UsuarioId = int.Parse(ResultadoTipoQuery["UsuarioId"].ToString())
                    };

                    ListaResultado.Add(Boleta);
                }

                return ListaResultado;
            }
            catch (Exception Ex)
            {
                Excepcion = Ex;
                return new List<Boleta>();
            }
        }
    }
}
