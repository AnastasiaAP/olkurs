using System;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class ContextDB
    {
        string connectionString = @"Data Source=DESKTOP-68D3S9N\SQLEXPRESS;Initial Catalog=OperationDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ContextDB() { }

        public DataTable GetAll()
        {
            DataTable dtOperation = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Select * from Operations", sqlCon);
                sqlData.Fill(dtOperation);
            }
            return dtOperation;
        }
        public void Create(Operation operation)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Operations(FirstEvent, SecondEvent, Duration) VALUES(@FirstEvent, @SecondEvent, @Duration)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@FirstEvent", operation.FirstEvent);
                sqlCmd.Parameters.AddWithValue("@SecondEvent", operation.SecondEvent);
                sqlCmd.Parameters.AddWithValue("@Duration", operation.Duration);
                sqlCmd.ExecuteNonQuery();
            }
        }
        public void Update(Operation operation)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                String query = "UPDATE Operations SET FirstEvent = @firstEvent, SecondEvent = @secondEvent, Duration = @duration WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, sqlCon);
                command.Parameters.AddWithValue("@firstEvent", operation.FirstEvent);
                command.Parameters.AddWithValue("@secondEvent", operation.SecondEvent);
                command.Parameters.AddWithValue("@duration", operation.Duration);
                command.Parameters.AddWithValue("@id", operation.Id);
                command.ExecuteNonQuery();
            }
        }
        public void DeleteAll()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "delete from Operations";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
            }
        }

        public void DeleteById(int? id)
        {
            if(id != null && id > 0)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "delete from Operations where Id = " + id;
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetById(int? id)
        {
            DataTable dtOperation = new DataTable();
            if (id != null && id > 0)
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "select * from Operations where Id = " + id;
                    SqlDataAdapter sqlData = new SqlDataAdapter(query, sqlCon);
                    sqlData.Fill(dtOperation);
                }
            }
            return dtOperation;
        }

        //public void DeleteBeforeActionId(int? mainId, int? beforeActionId)
        //{
        //    if (mainId != null && mainId > 0 && beforeActionId != null && beforeActionId > 0)
        //    {
        //        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //        {
        //            sqlCon.Open();
        //            string query = "delete from BeforeActions where MainActionId = " + mainId +" AND BeforeActionId =" + beforeActionId;
        //            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        //            sqlCmd.ExecuteNonQuery();
        //        }
        //    }
        //}
        //public void DeleteAfterActionId(int? mainId, int? afterActionId)
        //{
        //    if (mainId != null && mainId > 0 && afterActionId != null && afterActionId > 0)
        //    {
        //        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //        {
        //            sqlCon.Open();
        //            string query = "delete from AfterActions where MainActionId = " + mainId + " AND AfterActionId =" + afterActionId;
        //            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
        //            sqlCmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public void PushBeforeAction(int? mainActionId, int? idOperationBefore)
        //{
        //    if (mainActionId != null && mainActionId > 0 && idOperationBefore != null && idOperationBefore > 0) { 
        //        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //        {
        //            sqlCon.Open();
        //            String query = "INSERT INTO BeforeActions (BeforeActionId,MainActionId) VALUES (@beforeId,@mainId)";

        //            SqlCommand command = new SqlCommand(query, sqlCon);
        //            command.Parameters.AddWithValue("@mainId", mainActionId);
        //            command.Parameters.AddWithValue("@beforeId", idOperationBefore);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}


        //public void PushAfterAction(int? mainActionId, int? idOperationAfter)
        //{
        //    if (mainActionId != null && mainActionId > 0 && idOperationAfter != null && idOperationAfter > 0)
        //    {

        //        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //        {
        //            sqlCon.Open();
        //            String query = "INSERT INTO AfterActions (AfterActionId,MainActionId) VALUES (@afterId,@mainId)";
        //            SqlCommand command = new SqlCommand(query, sqlCon);
        //            command.Parameters.AddWithValue("@mainId", mainActionId);
        //            command.Parameters.AddWithValue("@afterId", idOperationAfter);
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}
        //public DataTable GetAllActionsBefore()
        //{
        //    DataTable dtOperation = new DataTable();
        //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //    {
        //        sqlCon.Open();
        //        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from BeforeActions", sqlCon);
        //        sqlData.Fill(dtOperation);
        //    }
        //    return dtOperation;
        //}
        //public DataTable GetAllActionsAfter()
        //{
        //    DataTable dtOperation = new DataTable();
        //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //    {
        //        sqlCon.Open();
        //        SqlDataAdapter sqlData = new SqlDataAdapter("Select * from AfterActions", sqlCon);
        //        sqlData.Fill(dtOperation);
        //    }
        //    return dtOperation;
        //}
    }
}