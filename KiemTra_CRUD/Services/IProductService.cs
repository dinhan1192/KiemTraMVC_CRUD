using KiemTra_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiemTra_CRUD.Services
{
    interface IProductService
    {
        Product Store(Product product);
        List<Product> GetList();
        Product GetDetail(int? id);
        Product Update(int? id, Product product);
        bool Delete(int? id);
    }
}
