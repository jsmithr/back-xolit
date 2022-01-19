using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XolitTest.Model.Dto;
using XolitTest.Model.Entity;

namespace XolitTest.Interface
{
    public interface IInvoiceService
    {
        object add(InvoiceDto data);
        object update(int idInvoice, InvoiceDto data);
        Boolean delete(int id);
        List<InvoiceDto> get();
        InvoiceDto find(int idInvoice);
        object getList();

    }
}
