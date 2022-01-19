using System;
using Microsoft.EntityFrameworkCore;
using XolitTest.Model.Entity;

namespace XolitTest.Model
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Invoice> Factura { get; set; }
        public DbSet<DetailInvoice> DetalleFactura { get; set; }        
        public DbSet<Product> Producto { get; set; }        

    }
}
