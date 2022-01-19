namespace XolitTest.Model.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal ValorVentaConIva { get; set; }
        public int CantidadUnidadesInventario { get; set; }
        public decimal PorcentajeIVAAplicado { get; set; }
    }
}
