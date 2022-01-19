using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace XolitTest.Model.Entity
{
    public class Invoice
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
        public int Estado{ get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
