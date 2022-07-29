using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Shell.Model;
using System.Data;

namespace Shell.Service
{
    public interface IMyService
    {
        void testService();
        string findmyservicepath();
    }
    public class MyService : IMyService
    {
        SHELLREGContext db = new SHELLREGContext();
        private readonly IWebHostEnvironment _env;

        public MyService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async void testService()
        {
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

        public string findmyservicepath()
        {
            //var path = Path.Combine(_env.ContentRootPath, "App_Data/Files");
            return _env.ContentRootPath;
        }
    }
}
