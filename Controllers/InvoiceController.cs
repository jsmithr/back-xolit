using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XolitTest.Interface;
using XolitTest.Model.Dto;
using XolitTest.Model.Entity;
using XolitTest.Utils;

namespace XolitTest.Controllers
{
    [Route("invoice")]
    [ApiController]
    public class InvoiceController
    {
        IInvoiceService _service;
        public InvoiceController(IInvoiceService vService)
        {
            _service = vService;
        }

        [HttpGet]
        public List<InvoiceDto> data()
        {
            return _service.get();
        }

        [HttpGet]
        [Route("{id_invoice}")]
        public InvoiceDto fin(int id_invoice)
        {
            return _service.find(id_invoice);
        }

        [HttpPost]
        public object add([FromBody()] InvoiceDto Factura)
        {
            return _service.add(Factura);
        }

        [HttpPut]
        public object Update(int vFacturaID, [FromBody()] InvoiceDto invoice)
        {
            var query = _service.update(vFacturaID, invoice);
            return query;
        }

        [HttpDelete]
        [Route("{id_invoice}")]
        public object Delete(int id_invoice)
        {
            var query = _service.delete(id_invoice);

            if (query == false)
                return Message.build(false, "Invoice cann't be delete", "invoice_delete", false);

            return Message.build(query, "invoice delete", "invoice_delete", true);
        }
    }
}
