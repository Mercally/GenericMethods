using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CGC_GM_FE.Models;
using CGC_GM_FE.WebApiRestClient.Services.ServiceSeguridadApi;
namespace CGC_GM_FE.WebAppMVC.Controllers
{
    public class SeguridadController : Controller
    {
        UsuariosControllerApi UsuarioControllerApi = new UsuariosControllerApi();

        // GET: Seguridad
        public ActionResult Index()
        {
            return View();
        }

        // GET: Seguridad/Usuarios
        public ActionResult ListaUsuarios()
        {
            var Modelo = UsuarioControllerApi.ObtenerUsuarios();

            return View(Modelo);
        }
    }
}