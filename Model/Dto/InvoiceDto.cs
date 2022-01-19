using System;
using System.Collections.Generic;

namespace XolitTest.Model.Dto
{
    public class InvoiceDto
    {
        public int NumeroFactura { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
        public List<DetailInvoiceDto> DetalleFactura { get; set; }
    }
}
