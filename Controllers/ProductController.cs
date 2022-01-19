using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XolitTest.Interface;
using XolitTest.Model.Dto;

namespace XolitTest.Controllers
{
    [Route("product")]
    [ApiController]
    public class ProductController
    {

        IProductService _service;

        public ProductController(IProductService vService)
        {
            _service = vService;
        }

        [HttpGet]
        public List<ProductDto> data()
        {
            return _service.get();
        }
    }
}
