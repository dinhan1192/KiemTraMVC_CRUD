using KiemTra_CRUD.Models;
using KiemTra_CRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KiemTra_CRUD.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        //private static string _rollNumber;
        public ProductController()
        {
            _productService = new InMemoryProductService();
        }
        #region Auto

        public ActionResult Default()
        {
            //ViewData["ListStudent"] = studentService.GetList();
            var listStudent = _productService.GetList();

            return View(listStudent);
        }

        //[HttpPost]
        //public ActionResult GetList()
        //{
        //    return RedirectToAction("Create");
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            _productService.Store(product);
            return RedirectToAction("Display", new { id = product.Id });
        }

        public ActionResult Display(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productService.GetDetail(id);
            return View(product);
        }

        public ActionResult Edit(int? id)
        {
            var product = _productService.GetDetail(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Product product)
        {
            var productAfterUpdate = _productService.Update(id, product);
            return RedirectToAction("Display", new { id = id });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = _productService.GetDetail(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _productService.Delete(id);
            return RedirectToAction("Default");
        }

        #endregion
    }
}