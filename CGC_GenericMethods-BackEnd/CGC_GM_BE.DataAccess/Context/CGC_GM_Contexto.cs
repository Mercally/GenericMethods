using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGC_GM_BE.DataAccess;
using CGC_GM_BE.DataAccess.Conexion;
using CGC_GM_BE.DataAccess.Model;

namespace CGC_GM_BE.DataAccess.Context
{
    public class CGC_GM_Contexto : AjustesComandosGenerico
    {
        private Comandos _Comandos { get; set; }

        public CGC_GM_Contexto(int TimeOut = 5) 
            : base(TimeOut)
        {
            if(Excepciones.Count > 0)
            {
                // Registrar excepciones

                throw new ArgumentNullException("Error al conectarse con la base de datos.");
            }
            else
            {
                this._Comandos = new Comandos(this.Transaccion);
            }
        }

        public Comandos Comandos {
            get
            {
                return _Comandos;
            }
        }

        public Seg_Usuario_Model Seg_Usuario_Model
        {
            get
            {
                return new Seg_Usuario_Model(this);
            }
        }

        public Age_Agenda_Model Age_Agenda_Model {
            get
            {
                return new Age_Agenda_Model(this);
            }
        }

        public Age_Tarea_Model Age_Tarea_Model
        {
            get
            {
                return new Age_Tarea_Model(this);
            }
        }

        public Cat_Catalogos Cat_Catalogos
        {
            get
            {
                return new Cat_Catalogos(this);
            }
        }
    }
}
