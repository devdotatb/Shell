using Shell.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Data;

namespace Shell.Service
{
    public class clsDefault
    {
        SHELLREGContext db = new SHELLREGContext();
        public clsDefault()
        {

        }
        public async Task<string> GenID(string Prefix)//string TableName, string FieldName, int Length, 
        {
            try
            {
                //var Prefix = DateTime.Now.ToString("yy"));
                string? ReturnValue;
                var ReturnValue_Param = new SqlParameter("ReturnValue", SqlDbType.VarChar,8) { Direction = ParameterDirection.Output };

                await db.Database.ExecuteSqlRawAsync("EXEC clsDefault_GenID @ReturnValue output", new[] { ReturnValue_Param });
                ReturnValue = (string)(ReturnValue_Param.Value);
                return Prefix + ReturnValue;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
