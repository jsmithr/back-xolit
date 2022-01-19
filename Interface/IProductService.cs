using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XolitTest.Model.Dto;
using XolitTest.Model.Entity;

namespace XolitTest.Interface
{
    public interface IProductService
    {
        List<ProductDto> get();
        Product find(int idProduct);
        object add(ProductDto data);
        object update(int idProduct, ProductDto data);
        Boolean delete(int idProduct);
    }
}  