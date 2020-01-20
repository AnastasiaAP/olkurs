using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class TableBuilder
    {
        public TableBuilder() { }

        public List<string> GetCodeLabels(List<Operation> operations)
        {
            var labels = new List<string>();
            foreach(var o in operations)
            {
                labels.Add("(" + o.FirstEvent + "," + o.SecondEvent + ")");
            }
            return labels;
        }
        public List<int> GetDurations(List<Operation> operations)
        {
            var durations = new List<int>();
            foreach(var e in operations)
            {
                durations.Add(e.Duration);
            }
            return durations;
        }

        public List<string> GetCriticalPath(List<Operation> operations, List<int> durationP, List<int> durationB)
        {
            var path = new List<string>();
            for(int i = 0; i < durationP.Count; i++)
            {
                if(durationP[i] == 0 && durationB[i] == 0)
                {
                    path.Add(operations[i].FirstEvent+","+operations[i].SecondEvent);
                }
            }
            return path;
        }

        public int GetCriticalValue(List<int> list)
        {
            return list.LastOrDefault();
        }

        public List<List<int>> GetIndicatiorsOfWork(List<Operation> actions)
        {
            List<List<int>> list = new List<List<int>>();
            var length = actions.Count;
            List<int> DurationRP = new List<int>(new int[length]);
            List<int> DurationRZ = new List<int>(new int[length]);
            List<int> DurationPP = new List<int>(new int[length]);
            List<int> DurationPZ = new List<int>(new int[length]);
            List<int> DurationP = new List<int>(new int[length]);
            List<int> DurationB = new List<int>(new int[length]);

            Dictionary<int, int> indexValueRatioRPRZ = new Dictionary<int, int>(length);
            Dictionary<int, int> indexValueRatioPPPZ = new Dictionary<int, int>(length);

            Operation model = new Operation();
            for(int j = 0; j < length; j++)
            {
                model = actions[j];
                var tempValue = (indexValueRatioRPRZ.ContainsKey(model.FirstEvent)) ? indexValueRatioRPRZ[model.FirstEvent] : 0;
                DurationRP[j] = tempValue;
                DurationRZ[j] = model.Duration + tempValue;
                if(DurationRZ[j] > ((indexValueRatioRPRZ.ContainsKey(model.SecondEvent)) ? indexValueRatioRPRZ[model.SecondEvent] : 0))
                {
                    indexValueRatioRPRZ[model.SecondEvent] = DurationRZ[j];
                }
            }
            list.Add(DurationRP);
            list.Add(DurationRZ);

            indexValueRatioPPPZ[actions[length - 1].SecondEvent] = DurationRZ[length - 1];
            for (int j = length - 1; j >= 0; j--)
            {
                model = actions[j];
                DurationPZ[j] = indexValueRatioPPPZ[model.SecondEvent];
                DurationPP[j] = DurationPZ[j] - model.Duration;

                if (!indexValueRatioPPPZ.ContainsKey(model.FirstEvent))
                {
                    indexValueRatioPPPZ[model.FirstEvent] = DurationPP[j];
                }
                else {
                    if (DurationPP[j] < ((indexValueRatioPPPZ.ContainsKey(model.FirstEvent)) ? indexValueRatioPPPZ[model.FirstEvent] : 999999))
                    {
                        indexValueRatioPPPZ[model.FirstEvent] = DurationPP[j];
                    }
                }
            }
            list.Add(DurationPZ);
            list.Add(DurationPP);

            for(int j = 0; j < length; j++)
            {
                DurationP[j] = DurationPZ[j] - DurationRZ[j];
            }
            for(int j = 0; j < length; j++)
            {
                model = actions.FirstOrDefault(a => a.FirstEvent == actions[j].SecondEvent);
                if(model != null)
                {
                    var index = actions.IndexOf(model);
                    DurationB[j] = DurationRP[index] - DurationRZ[j];
                }
            }
            list.Add(DurationP);
            list.Add(DurationB);
            return list;
        }
    }
}