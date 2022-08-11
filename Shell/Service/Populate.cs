using Shell.Data;
using Shell.Model;
using System.Data;

namespace Shell.Service
{
    public interface IPopulate
    {
        List<ListItem> DropDownDealerInvoice();
        List<ListItem> DropDownInvoiceStatus();
    }
    public class Populate : IPopulate
    {
        public List<ListItem> DropDownDealerInvoice()
        {
            using (var db = new SHELLREGContext())
            {
                var tradefilter_before = db.TradeOwners.Where(t1 => !string.IsNullOrWhiteSpace(t1.Acode));
                IQueryable<TradeOwner> tradefilter_after;
                //user Position
                var user_Position = "DSR";
                var user_id = "00000001";
                if (user_Position == "DSR")
                {
                    tradefilter_after = tradefilter_before.Where(t => t.Dsrid == user_id);
                }
                else if (user_Position == "DSM")
                {
                    tradefilter_after = tradefilter_before.Where(t => t.Dsmid == user_id);
                }
                else if (user_Position == "OBAM")
                {
                    tradefilter_after = tradefilter_before.Where(t => t.Obamid == user_id);
                }
                else
                {
                    tradefilter_after = tradefilter_before;
                }
                var query = (
                    from TO in tradefilter_after
                    join Inv in db.InvoiceHeaders on TO.Acode equals Inv.Acode
                    group TO by new { TO.Acode, TO.ShopName } into g
                    select new ListItem()
                    {
                        text = g.Key.ShopName,
                        value = g.Key.Acode
                    }
                );
                return query.ToList();
            }
        }
        public List<ListItem> DropDownInvoiceStatus()
        {
            using (var db = new SHELLREGContext())
            {
                var query = (
                    from InvStat in db.InvoiceStatuses.Where(t => t.InvoiceStatusId != null)
                    select new ListItem()
                    {
                        text = InvStat.InvoiceStatusName,
                        value = InvStat.InvoiceStatusId.ToString()
                    }
                );
                return query.ToList();
            }
        }
    }
}
