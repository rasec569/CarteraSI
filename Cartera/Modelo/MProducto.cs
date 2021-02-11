using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartera.Modelo
{
    class MProducto
    {
        public Int64 ID_Producto { get; set; }
        public string Identificacion_Producto { get; set; }
        public Int64 Numero_contrato { get; set; }
        public string Tipo_pago { get; set; }
        public string Tipo_producto { get; set; }
        public Int64 Valor_Total { get; set; }
        public Int64 Valor_30 { get; set; }
        public Int64 Valor_Entrada { get; set; }
        public Int64 Cuotas_30 { get; set; }
        public Int64 Valor_70 { get; set; }
        public Int64 Cuotas_70 { get; set; }
        public Int64 Valor_intereses { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public string Observaciones { get; set; }

    }
}
