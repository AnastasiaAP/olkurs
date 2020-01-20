using System.Web.Mvc;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    public class OperationsController : Controller
    {

        public ContextAdapter adapter = new ContextAdapter();
        public OperationHelper operationHelper = new OperationHelper();
        public TableBuilder tableBuilder = new TableBuilder();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Operations = adapter.GetOperations();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Create(Operation operation)
        {
            if (ModelState.IsValid)
            {
                adapter.Create(operation);
                return null;
            }
            return View(operation);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            List<Operation> operations = adapter.GetOperations();
            Operation operation = operations.Find(o => o.Id == id);
            return View(operation);
        }

        [HttpPost]
        public ActionResult Edit(Operation operation)
        {
            if (ModelState.IsValid)
            {
                adapter.Update(operation);
                return null;
            }
            return View(operation);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            adapter.DeleteById(id);
           
            return RedirectToAction("Index", "Operations");
        }

        [HttpPost]
        public ActionResult ClearAll()
        {
            adapter.DeleteAll();
            return RedirectToAction("Index", "Operations");
        }
    }
}
