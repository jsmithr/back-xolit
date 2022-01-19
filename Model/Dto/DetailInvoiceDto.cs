using System;
using System.Collections.Generic;
using System.Text;

namespace XolitTest.Model.Dto
{
    public class DetailInvoiceDto
    {
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorVentaConIva { get; set; }
        public decimal PorcentajeIVAAplicado { get; set; }
        public ProductDto Producto { get; set; }
    }
}
