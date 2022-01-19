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
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly ContextDb context;
        public ProductService(IMapper mapper, ContextDb _context)
        {
            _mapper = mapper;
            context = _context;
        }
        public List<ProductDto> get()
        {
            var list = context.Producto.ToList();
            return _mapper.Map<List<ProductDto>>(list);
        }

        public Product find(int idProduct)
        {
            var productos = context.Producto.Single(e => e.Id == idProduct);
            return productos;
        }

        public object add(ProductDto data)
        {
            try
            {
                Product newProduct = _mapper.Map<Product>(data);
                context.Producto.Add(newProduct);
                context.SaveChanges();

                return Message.build(data, "success_save", "product_save", true);
            }
            catch (Exception e)
            {
                return Message.build(false, "error" + e.Message, "invoice_save", false);
            }
        }

        public object update(int idProduct, ProductDto data)
        {
            try
            {
                var productFound = context.Producto.Find(idProduct);
                Product productUpdate = _mapper.Map<Product>(data);

                if (productFound == null)
                    return Message.build(false, "Product not found", "product_save", false);

                context.Producto.Update(productUpdate);
                context.SaveChanges();

                return Message.build(data, "success_save", "product_save", true);
            }
            catch (Exception e)
            {
                return Message.build(false, "error" + e.Message, "invoice_save", false);
            }
        }

        public Boolean delete(int vProductoID)
        {
            try
            {
                var producto = context.Producto.Find(vProductoID);
                if (producto == null)
                {
                    return false;
                }
                context.Producto.Remove(producto);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

