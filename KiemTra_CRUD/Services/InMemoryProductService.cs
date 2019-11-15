using KiemTra_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KiemTra_CRUD.Services
{
    public class InMemoryProductService : IProductService
    {
        private static List<Product> _listProduct;
        public InMemoryProductService()
        {
            if (_listProduct == null)
            {
                _listProduct = new List<Product> {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = Decimal.Parse("188888888.90"),
                    Description = "Rất tốt",
                    Image = @"~/Images/Trump.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 2,
                    Name = "Bike",
                    Price = Decimal.Parse("20000999.90"),
                    Description = "Rất tốt",
                    Image = @"https://www.google.com/imgres?imgurl=http%3A%2F%2Fthuvienanhdep.net%2Fwp-content%2Fuploads%2F2016%2F10%2Fhinh-anh-dep-nhat-the-gioi-ve-su-hoan-hao-khien-moi-nguoi-ngo-ngang2.jpg&imgrefurl=http%3A%2F%2Fthuvienanhdep.net%2Fhinh-anh-dep-nhat-the-gioi-ve-su-hoan-hao-khien-moi-nguoi-ngo-ngang%2F&docid=jKKVx0tDwtGR9M&tbnid=vWWyhk98CLtJJM%3A&vet=10ahUKEwibuqiL7uvlAhUPU30KHRDgDp8QMwh6KAEwAQ..i&w=500&h=625&bih=657&biw=1366&q=%E1%BA%A3nh%20%C4%91%E1%BA%B9p&ved=0ahUKEwibuqiL7uvlAhUPU30KHRDgDp8QMwh6KAEwAQ&iact=mrc&uact=8",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Product
                {
                    Id = 3,
                    Name = "Television",
                    Price = Decimal.Parse("89.90"),
                    Description = "Rất tốt",
                    Image= @"https://icdn.dantri.com.vn/zoom/327_245//2019/11/15/6-tong-duyet-1573812784025.jpg",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                };
            }
        }
        public bool Delete(int? id)
        {
            for (int i = 0; i < _listProduct.Count; i++)
            {
                if (_listProduct[i].Id == id)
                {
                    _listProduct.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public Product GetDetail(int? id)
        {
            for (int i = 0; i < _listProduct.Count; i++)
            {
                if (_listProduct[i].Id == id)
                {
                    return _listProduct[i];
                }
            }
            return null;
        }

        public List<Product> GetList()
        {
            return _listProduct;
        }

        public Product Store(Product product)
        {
            product.Id = _listProduct.Count + 1;
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = null;
            _listProduct.Add(product);
            return product;
        }

        public Product Update(int? id, Product product)
        {
            for (int i = 0; i < _listProduct.Count; i++)
            {
                if (_listProduct[i].Id == id)
                {
                    _listProduct[i].Name = product.Name;
                    _listProduct[i].Price = product.Price;
                    _listProduct[i].Description = product.Description;
                    _listProduct[i].Image = product.Image;
                    _listProduct[i].UpdatedAt = DateTime.Now;

                    return _listProduct[i];
                }
            }

            return null;
        }
    }
}