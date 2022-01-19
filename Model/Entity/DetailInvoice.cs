using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XolitTest.Model.Entity
{
    public class DetailInvoice
    {
        public int Id { get; set; }        
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorVentaConIva { get; set; }
        public decimal PorcentajeIVAAplicado { get; set; }
        public int Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Product Producto { get; set; }
        [NotMapped]
        public Invoice Factura { get; set; }
    }
}
