using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XolitTest.Interface;
using XolitTest.Model;
using XolitTest.Model.Dto;
using XolitTest.Model.Entity;
using XolitTest.Utils;

namespace XolitTest.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IMapper _mapper;
        private readonly ContextDb context;
        public InvoiceService(IMapper mapper, ContextDb _context)
        {
            _mapper = mapper;
            context = _context;
        }

        public List<InvoiceDto> get()
        {
            var lis = context.Factura.ToList();
            return _mapper.Map<List<InvoiceDto>>(lis);
        }

        public InvoiceDto find(int idInvoice)
        {
            var invoice = context.Factura
                .Where(e => e.Id == idInvoice)
                .FirstOrDefault();

            if (invoice == null)
                return null;

            var invoiceDetail = context.DetalleFactura
                .Where(e => e.FacturaId == idInvoice)
                .Include(m => m.Producto)
                .ToList();
            InvoiceDto invoiceDto = _mapper.Map<InvoiceDto>(invoice);
            invoiceDto.DetalleFactura = _mapper.Map<List<DetailInvoiceDto>>(invoiceDetail);
            return invoiceDto;
        }

        public object add(InvoiceDto data)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    data.FechaPedido = DateTime.Now;
                    Invoice invoice = _mapper.Map<Invoice>(data);
                    invoice.FechaCreacion = DateTime.Now;
                    context.Factura.Add(invoice);
                    context.SaveChanges();

                    foreach (var productDetail in data.DetalleFactura)
                    {
                        var product = context.Producto.Single(c => c.Id == productDetail.ProductoId);
                        DetailInvoice invoiceDetail = new DetailInvoice
                        {
                            FacturaId = invoice.Id,
                            ProductoId = productDetail.ProductoId,
                            Cantidad = productDetail.Cantidad,
                            ValorVentaConIva = product.ValorVentaConIva,
                            PorcentajeIVAAplicado = product.PorcentajeIVAAplicado,
                            FechaCreacion = DateTime.Now,
                            Estado = 1
                        };

                        context.DetalleFactura.Add(invoiceDetail);
                        product.CantidadUnidadesInventario -= invoiceDetail.Cantidad;
                        context.Update(product);
                    }

                    data.NumeroFactura = invoice.Id;

                    context.SaveChanges();
                    transaction.Commit();
                    return Message.build(data, "success_save", "invoice_save", true);
                }
                catch (Exception e)
                {
                    return Message.build(false, "error" + e.Message, "invoice_save", false);
                }
            }
        }

        public object update(int idInvoice, InvoiceDto data)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var invoice = context.Factura.Find(idInvoice);

                    if (invoice == null)
                        return Message.build(false,"Invoice not found", "error_update", false);


                    List<DetailInvoice> invoiceDetail = context.DetalleFactura.Where(df => df.FacturaId == idInvoice).ToList();

                    foreach (var item in invoiceDetail)
                        item.Estado = 0;

                    foreach (DetailInvoiceDto invoiceDetailDto in data.DetalleFactura)
                    {
                        DetailInvoice productFound = invoiceDetail.Find(id => id.ProductoId == invoiceDetailDto.ProductoId);
                        var product = context.Producto.Single(c => c.Id == invoiceDetailDto.ProductoId);

                        if (productFound == null){

                            DetailInvoice updateProduct = new DetailInvoice
                            {
                                FacturaId = idInvoice,
                                ProductoId = invoiceDetailDto.ProductoId,
                                Cantidad = invoiceDetailDto.Cantidad,
                                FechaCreacion = DateTime.Now,
                                PorcentajeIVAAplicado = product.PorcentajeIVAAplicado,
                                ValorVentaConIva = product.ValorVentaConIva,
                                Estado = 1
                            };
                            context.DetalleFactura.Add(updateProduct);
                        }
                        else
                        {
                            productFound.Cantidad = invoiceDetailDto.Cantidad;
                            productFound.PorcentajeIVAAplicado = product.PorcentajeIVAAplicado;
                            productFound.ValorVentaConIva = product.ValorVentaConIva;
                            productFound.Estado = 1;
                        }
                    }

                    context.DetalleFactura.UpdateRange(invoiceDetail);
                    context.SaveChanges();

                    transaction.Commit();
                    return Message.build(data, "success_save", "invoice_save", true);
                }
                catch (Exception e)
                {
                    return Message.build(false, "error" + e.Message, "invoice_save", false);
                }
            }
        }

        public Boolean delete(int idInvoice)
        {
            try
            {
                Invoice invoice = context.Factura.Find(idInvoice);
                if (invoice == null)
                    return false;

                var lstOriginal = context.DetalleFactura
                                          .Where(e => e.FacturaId == idInvoice)
                                          .ToList();

                context.DetalleFactura.RemoveRange(lstOriginal);

                context.Factura.Remove(invoice);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public object getList()
        {
            var Produc = context.Producto.ToList();

            /*Object item = new ObjListados();

            item.lisProducto = _mapper.Map<List<ProductoDto>>(Produc);*/

            return null;
        }
    }
}
