﻿using System.Collections.Generic;
using System.Configuration;
using CGC_GM_FE.Common.Models;
using CGC_GM_FE.WebApiRestClient.Metadata.ServiceTimeManagerApi;

namespace CGC_GM_FE.WebApiRestClient.Services.ServiceTimeManagerApi
{
    public class ClientesControllerApi : IClientesControllerApi
    {
        private string ApiUri
        {
            get
            {
                return ConfigurationSettings.AppSettings["ServiceTimeManagerApi"] + "/Clientes";
            }
        }

        public List<Cliente> ConsultarClientes()
        {
            var Respuesta = GenericHelper
                .Request<List<Cliente>>(
                Url: $"{ApiUri}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public Cliente ConsultarClientePorId(int ClienteId)
        {
            var Respuesta = GenericHelper
                .Request<Cliente>(
                Url: $"{ApiUri}/{ClienteId}",
                Method: HttpMethodEnum.HttpGet
                );

            return Respuesta;
        }

        public bool EliminarCliente(int ClienteId)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: $"{ApiUri}/{ClienteId}",
                Method: HttpMethodEnum.HttpDelete
                );

            return Respuesta;
        }

        public int InsertarCliente(Cliente Cliente)
        {
            var Respuesta = GenericHelper
                .Request<int>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPost_Json,
                Data: Cliente
                );

            return Respuesta;
        }

        public bool ModificarCliente(Cliente Cliente)
        {
            var Respuesta = GenericHelper
                .Request<bool>(
                Url: ApiUri,
                Method: HttpMethodEnum.HttpPut_Json,
                Data: Cliente
                );

            return Respuesta;
        }
    }
}
