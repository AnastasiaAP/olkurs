using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Context;
using WebApplication1.Helpers;

namespace WebApplication1.Views.Operations
{
    public class TableController : Controller
    {
        public ContextAdapter adapter = new ContextAdapter();
        public OperationHelper operationHelper = new OperationHelper();
        public TableBuilder tableBuilder = new TableBuilder();

        public ActionResult Index()
        {
            var actions = adapter.GetOperations();

            ViewBag.Labels = tableBuilder.GetCodeLabels(actions);
            ViewBag.Durations = tableBuilder.GetDurations(actions);
            List<List<int>> list = tableBuilder.GetIndicatiorsOfWork(actions);
            ViewBag.DurationsRP = list[0];
            ViewBag.DurationsRZ = list[1];
            ViewBag.DurationsPZ = list[2];
            ViewBag.DurationsPP = list[3];
            ViewBag.DurationsP = list[4];
            ViewBag.DurationsB = list[5];

            return View();
        }
    }
}