using Shell.Data;
using Shell.Model;
using System.Data;

namespace Shell.Service
{
    public interface IPopulate
    {
        List<ListItem> DropDownDealerInvoice(string user_Position, string user_id);
        List<ListItem> DropDownInvoiceStatus(int? invoicestatus = null);
        List<ListItem> DropDownLotNo();
    }
    public class Populate : IPopulate
    {
        public List<ListItem> DropDownDealerInvoice(string user_Position, string user_id)
        {
            using (var db = new SHELLREGContext())
            {
                var tradefilter_before = db.TradeOwners.Where(t1 => !string.IsNullOrWhiteSpace(t1.Acode));
                IQueryable<TradeOwner> tradefilter_after;
                //user Position
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
        public List<ListItem> DropDownInvoiceStatus(int? invoicestatus_except = null)
        {
            using (var db = new SHELLREGContext())
            {
                var query = db.InvoiceStatuses.Where(t => t.InvoiceStatusId != null);
                if (invoicestatus_except != null)
                {
                    query = query.Where(t => t.InvoiceStatusId != invoicestatus_except);
                }
                var tolist = query.Select(t => new ListItem()
                {
                    text = t.InvoiceStatusName,
                    value = t.InvoiceStatusId.ToString()
                }).ToList();
                return tolist;
            }
        }

        public List<ListItem> DropDownLotNo()
        {
            using (var db = new SHELLREGContext())
            {
                var query = db.Lots.Where(t => t.LotNo != null).OrderByDescending(t => t.LotNo);
                var tolist = query.Select(t => new ListItem()
                {
                    text = t.LotNo,
                    value = t.LotNo,
                }).ToList();
                return tolist;
            }
        }
    }
}
