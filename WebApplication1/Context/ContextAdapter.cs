using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class ContextAdapter
    {
        public ContextDB db;
        public ContextAdapter() { db = new ContextDB(); }

        public List<Operation> GetOperations()
        {
            List<Operation> operations = new List<Operation>();
            try
            {
                var dbOperations = db.GetAll();
                foreach (DataRow dr in dbOperations.Rows)
                {
                    operations.Add(new Operation { Id = Convert.ToInt32(dr[0]), FirstEvent = Convert.ToInt32(dr[1]), SecondEvent = Convert.ToInt32(dr[2]), Duration = Convert.ToInt32(dr[3]) });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
            return operations;
        }

        public Operation GetById(int id)
        {
            Operation operation = new Operation();
            try
            {
                var dbOperation = db.GetById(id);
                operation.Id = Convert.ToInt32(dbOperation.Rows[0][0]);
                operation.FirstEvent = Convert.ToInt32(dbOperation.Rows[0][1]);
                operation.SecondEvent = Convert.ToInt32(dbOperation.Rows[0][2]);
                operation.Duration = Convert.ToInt32(dbOperation.Rows[0][3]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return operation;
        }

        public void Create(Operation operation)
        {
            try
            {
                db.Create(operation);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void Update(Operation operation)
        {
            try
            {
                db.Update(operation);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        public void DeleteAll()
        {
            try
            {
                db.DeleteAll();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
        public void DeleteById(int? id)
        {
            try
            {
                db.DeleteById(id);
            }
            catch (Exception e) { Console.WriteLine(e); }
        }

        //public void DeleteBeforeActionId(int? mainId, int? beforeActionId)
        //{
        //    try
        //    {
        //        db.DeleteBeforeActionId(mainId, beforeActionId);
        //    }catch(Exception e) { Console.WriteLine(e); }
        //}

        //public void DeleteAfterActionId(int? mainId, int? afterActionId)
        //{
        //    try
        //    {
        //        db.DeleteAfterActionId(mainId, afterActionId);
        //    }
        //    catch (Exception e) { Console.WriteLine(e); }
        //}

        //public void PushBeforeAction(int? mainActionId, int? idOperationBefore)
        //{
        //    try
        //    {
        //        db.PushBeforeAction(mainActionId, idOperationBefore);
        //    }
        //    catch (Exception e) { Console.WriteLine(e); }
        //}

        //public void PushAfterAction(int? mainActionId, int? idOperationAfter)
        //{
        //    try
        //    {
        //        db.PushAfterAction(mainActionId, idOperationAfter);
        //    }
        //    catch (Exception e) { Console.WriteLine(e); }
        //}

        //public List<BriefOperation> GetAllActionsBefore()
        //{
        //    List<BriefOperation> operations = new List<BriefOperation>();
        //    try
        //    {
        //        var dbOperations = db.GetAllActionsBefore();
        //        foreach (DataRow dr in dbOperations.Rows)
        //        {
        //            operations.Add(new BriefOperation { Id = Convert.ToInt32(dr[0]), MinorId = Convert.ToInt32(dr[1]), MainId = Convert.ToInt32(dr[2]) });
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }

        //    return operations;
        //}

        //public List<BriefOperation> GetAllActionsAfter()
        //{

        //    List<BriefOperation> operations = new List<BriefOperation>();
        //    try
        //    {
        //        var dbOperations = db.GetAllActionsAfter();
        //        foreach (DataRow dr in dbOperations.Rows)
        //        {
        //            operations.Add(new BriefOperation { Id = Convert.ToInt32(dr[0]), MinorId = Convert.ToInt32(dr[1]), MainId = Convert.ToInt32(dr[2]) });
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }

        //    return operations;
        //}
    }
}