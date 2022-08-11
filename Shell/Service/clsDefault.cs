using Shell.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Data;
using Shell.Data;

namespace Shell.Service
{
    public interface IclsDefault
    {
        string WebRootPath();
        string ContentRootPath();
        Task<string> GenImportID(string Prefix);
        Task<string> GenShoppingNO();
        Task<string> GenInvoiceNo();
        string ReplaceText(string txt);
    }
    public class clsDefault : IclsDefault
    {
        private readonly IWebHostEnvironment _env;

        public clsDefault(IWebHostEnvironment env)
        {
            _env = env;
        }
        public string ContentRootPath()
        {
            return _env.ContentRootPath;
        }
        public string WebRootPath()
        {
            return _env.WebRootPath;
        }
        public async Task<string> GenImportID(string Prefix)//string TableName, string FieldName, int Length, 
        {
            try
            {
                string? ReturnValue;
                var ReturnValue_Param = new SqlParameter("ReturnValue", SqlDbType.VarChar, 8) { Direction = ParameterDirection.Output };

                using (var db = new SHELLREGContext())
                {
                    await db.Database.ExecuteSqlRawAsync("EXEC clsDefault_GenID @ReturnValue output", new[] { ReturnValue_Param });
                }
                ReturnValue = (string)(ReturnValue_Param.Value);
                return Prefix + ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public string ReplaceText(string txt)
        {
            return txt.Replace(@"'", "").Replace("&#8203;", "").Trim();
        }

        public async Task<string> GenShoppingNO()//string TableName, string FieldName, int Length, 
        {
            try
            {
                string? ReturnValue;
                using (var db = new SHELLREGContext())
                {
                    using (var cmd = db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "select dbo.GenShoppingNo()";
                        //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                        //cmd.Parameters.Add(new SqlParameter("Ticket", ticket));
                        //cmd.Parameters.Add(new SqlParameter("Reference", reference));
                        ReturnValue = (string)cmd.ExecuteScalar();
                    }
                }
                return ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<string> GenInvoiceNo()//string TableName, string FieldName, int Length, 
        {
            try
            {
                string? ReturnValue;
                using (var db = new SHELLREGContext())
                {
                    using (var cmd = db.Database.GetDbConnection().CreateCommand())
                    {
                        cmd.CommandText = "select dbo.GenInvoiceNo()";
                        if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                        ReturnValue = (string)cmd.ExecuteScalar();
                    }
                }
                return ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

    }
}
