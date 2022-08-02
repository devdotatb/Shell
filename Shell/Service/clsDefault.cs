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
        Task<string> GenID(string Prefix);
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
        public async Task<string> GenID(string Prefix)//string TableName, string FieldName, int Length, 
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
        public async Task<string> SelectExportExcel()
        {
           /* try
            {
                IQueryable<MasterExcelImportData> ReturnValue;
                var ReturnValue_Param = new SqlParameter("ReturnValue", ReturnValue) { Direction = ParameterDirection.Output };

                using (var db = new SHELLREGContext())
                {
                    await db.Database.ExecuteSqlRawAsync("EXEC clsDefault_GenID @ReturnValue output", new[] { ReturnValue_Param });
                }
                ReturnValue = (IQueryable<MasterExcelImportData>)(ReturnValue_Param.Value);
                return ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }*/

        }
    }
}
