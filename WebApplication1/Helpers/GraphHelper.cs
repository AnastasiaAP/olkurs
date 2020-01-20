using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class Point
    {
        public Point():this(x: 0,y: "") { }
        public Point(int x,string y) { X = x; Y = y; }
        public int X { get; set; }
        public string Y { get; set; }
    }
    public class GraphHelper
    {
        public GraphHelper() { }
        public List<Point> GetCoordinates(List<Operation> operations)
        {
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            List<Point> points = new List<Point>();
            var point = new Point();
            var model = new Operation();
            for (int j = 0; j < operations.Count; j++)
            {
                model = operations[j];
                var tempValue = (pairs.ContainsKey(model.FirstEvent)) ? pairs[model.FirstEvent] : 0;
                point.X = tempValue;
                point.Y = model.FirstEvent + "," + model.SecondEvent;
                points.Add(new Point(point.X,point.Y));
                point.X = point.X + model.Duration;
                points.Add(new Point(point.X,point.Y));

                if(point.X > ((pairs.ContainsKey(model.SecondEvent)) ? pairs[model.SecondEvent] : 0))
                {
                    pairs[model.SecondEvent] = point.X;
                }
            }
            return points;
        }
    }
}