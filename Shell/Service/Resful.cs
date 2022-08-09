using Shell.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Data;
using Shell.Data;

namespace Shell.Service
{
    public interface IResful
    {
        int? AddProductShopping(string shoppingno, string materialcode, int productqty, string shareid, int cpoint, int cbpoint);
    }
    public class Resful : IResful
    {
        public int? AddProductShopping(string shoppingno, string materialcode, int productqty, string shareid, int cpoint, int cbpoint)
        {
            try
            {
                int irow = 0;
                using (var db = new SHELLREGContext())
                {
                    db.ShoppingDetails.Add(new ShoppingDetail()
                    {
                        ShoppingNo = shoppingno,
                        MaterialCode = materialcode,
                        ProductQty = productqty,
                        //cururentpoint
                        //currentbonuspoint
                        //shareid
                    });

                    db.SaveChanges();

                    irow = db.ShoppingDetails.Where(t => t.ShoppingNo == shoppingno).Count();
                    return irow;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
