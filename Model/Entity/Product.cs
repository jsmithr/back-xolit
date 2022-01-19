using System;
using System.Collections.Generic;
using System.Text;

namespace XolitTest.Model.Entity
{
    public class Product
    {
        public int Id { get; set; }        
        public string Nombre { get; set; }
        public decimal ValorVentaConIva { get; set; }
        public int CantidadUnidadesInventario { get; set; }
        public decimal PorcentajeIVAAplicado { get; set; }
    }
}
