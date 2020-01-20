using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Helpers;

namespace WebApplication1.Controllers
{
    public class GraphController : Controller
    {
        public ContextAdapter adapter = new ContextAdapter();
        public OperationHelper operationHelper = new OperationHelper();
        public TableBuilder tableBuilder = new TableBuilder();
        public GraphHelper graphHelper = new GraphHelper();
        // GET: Graph
        public ActionResult Index()
        {
            List<List<int>> list = tableBuilder.GetIndicatiorsOfWork(adapter.GetOperations());
            ViewBag.CriticalValue = tableBuilder.GetCriticalValue(list[1]);
            ViewBag.CriticalPath = tableBuilder.GetCriticalPath(adapter.GetOperations(),list[4],list[5]);
            ViewBag.Coordinates = graphHelper.GetCoordinates(adapter.GetOperations());
            return View();
        }
    }
}