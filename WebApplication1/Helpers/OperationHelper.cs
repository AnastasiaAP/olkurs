using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public class OperationHelper
    {
        public OperationHelper() { }

        //public int IndexOf(List<Operation> list, int id)
        //{
        //    var operation = list.FirstOrDefault(o => o.Id == id);
        //    if (operation != null)
        //        return list.IndexOf(operation);
        //    return -1;
        //}
        //public List<int> GetZeroSumElem(int[,] helpMatrix, int row)
        //{
        //    var list = new List<int>() { };
        //    for(int i = 0; i < helpMatrix.GetLength(0); i++)
        //    {
        //        if(helpMatrix[row, i] == 0)
        //        {
        //            list.Add(i);
        //        }
        //    }
        //    return list;
        //}
        //public void SetMatrixActions(List<Operation> actions, List<BriefOperation> briefActions,int[,] matrix)
        //{
        //    foreach (var a in briefActions)
        //    {
        //        matrix[IndexOf(actions, a.MainId), IndexOf(actions, a.MinorId)] = 1;
        //    }
        //}
        //public void SetDefaultValues(int[,] helpMatrix)
        //{
        //    var length = helpMatrix.GetLength(0);
        //    for (int i = 0; i < length; i++)
        //    {
        //        for(int j = 0; j < length; j++)
        //        {
        //            helpMatrix[i, j] = -1;
        //        }
        //    }
        //}

        //public void SetWithValuesNextRow(int[,] helpMatrix, int[,] matrix, List<int> list, int row)
        //{
        //    if (row - 1 >= 0)
        //    {
        //        for (int i = 0; i < helpMatrix.GetLength(0); i++)
        //        {
        //            if (!list.Contains(i))
        //            {
        //                foreach(var a in list)
        //                {
        //                    if(matrix[a,i] >= 0)
        //                        helpMatrix[row - 1, i] -= matrix[a, i];
        //                }
        //                helpMatrix[row, i] = helpMatrix[row - 1, i];
        //            }
        //        }
        //    }
        //    else
        //    {

        //    }
        //}
        //public void InitWithValues(List<Operation> actions, List<BriefOperation> actionsAfter, List<BriefOperation> actionsBefore, int[,] matrix)
        //{
        //    if (actionsAfter.Count != 0)
        //        SetMatrixActions(actions, actionsAfter, matrix);
        //    else if (actionsBefore.Count != 0)
        //        SetMatrixActions(actions, actionsBefore, matrix);
        //    else
        //        return;
        //}
    }
}