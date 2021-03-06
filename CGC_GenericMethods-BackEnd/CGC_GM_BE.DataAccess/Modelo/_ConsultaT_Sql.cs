﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess.Conexion;

namespace CGC_GM_BE.DataAccess.Modelo
{
    public class _ConsultaT_Sql
    {
        /// <summary>
        /// Consulta en forma de cadena T-SQL
        /// </summary>
        public string ConsultaCruda { get; set; }

        /// <summary>
        /// Lista de parámetros según nombre en ConsultaCruda
        /// </summary>
        public List<SqlParameter> Parametros { get; set; }

        /// <summary>
        /// Tipo de consulta a realizar: Insert, Update, Delete, Query
        /// </summary>
        public _TipoConsultaEnum TipoConsulta { get; set; }

        /// <summary>
        /// Tiempo de espera en segundos para cada comando de forma individual
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// Determina si la consulta tiene errores
        /// </summary>
        public bool TieneError { get; internal set; }
    }
}
