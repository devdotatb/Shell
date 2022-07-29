using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Shell.Model;
using System.Data;

namespace Shell.Service
{
    public class MyService
    {
        SHELLREGContext db = new SHELLREGContext();
        public MyService()
        {

        }
        public async void testService()
        {

            /*var storedProcName = "MyTest2";
            SqlParameter[] @params =
                {
                    new SqlParameter("@returnVal", SqlDbType.UniqueIdentifier) {Direction = ParameterDirection.Output}
                };


            //db.Database.ExecuteSqlCommand("exec @returnVal=" + storedProcName, @params);
            db.Database.ExecuteSqlCommandAsync("exec MyTest2", @params);

            var result = @params[0].Value; //result is 29*/

            /*SqlParameter[] parameters =
{
   new SqlParameter("@inCode", SqlDbType.Varchar { Direction = ParameterDirection.Input, Value = "InputValue" },
   new SqlParameter("@outValue", SqlDbType.Int { Direction = ParameterDirection.Output }
}
db.Database.ExecuteSqlRaw("exec MyTest2 @inCode, @outValue OUTPUT", parameters);
            var result -parameters[1].Value;*/


            //db.Database.FormSqlRaw("exec MyTest2");
            //db.AuthorizeDocuments.FromSqlRaw("exec MyTest2");

            Guid? quantity;
            var ticketParam = new SqlParameter("Ticket", "1");
            var referenceParam = new SqlParameter("Reference", "22");
            var quantityParam = new SqlParameter("Quantity", SqlDbType.UniqueIdentifier) { Direction = ParameterDirection.Output };
            try
            {
                await db.Database.ExecuteSqlRawAsync("EXEC MyTest88 @Ticket, @Reference, @Quantity output", new[] { ticketParam, referenceParam, quantityParam });
                quantity = (Guid)(quantityParam.Value);
            }
            catch (Exception ex)
            {
            }


        }
    }
}
