using ConsumoAPI.Models;
using CrudVentas.Datos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoAPI.Datos
{
    public class DatosClientePago : Controller
    {
        public List<ClientePagoModels> Listar(string cedula)
        {
            var oListar = new List<ClientePagoModels>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ConsultaPagosCliente", conexion);
                cmd.Parameters.AddWithValue("Cedula", cedula);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oListar.Add(new ClientePagoModels()
                        {
                            cedula = dr["cedula"].ToString(),
                            Nombre_Completo = dr["Nombre_Completo"].ToString(),
                            fecha_pago = Convert.ToDateTime(dr["fecha_pago"]),
                            monto = Convert.ToDouble(dr["monto"])
                        });
                    }
                }
            }
            return oListar;
        }

    }
}
