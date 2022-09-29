using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsumoAPI.Models
{
    public class ClientePagoModels
    {
        public string cedula { get; set; }
        public string? Nombre_Completo { get; set; }
        public DateTime? fecha_pago { get; set; }
        public double? monto { get; set; }
    }
}
