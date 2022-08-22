namespace Shell.Data.SearchData
{
    public class LotListSeachData
    {
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public DateTimeOffset? InvoiceDate_Datetime { get; set; }
        public string Site { get; set; }
        public int InvoiceStatusID { get; set; }
        public string InvoiceStatusName { get; set; }
        public string EditDate { get; set; }
        public string ACode { get; set; }
        public string ShopName { get; set; }
        public string LotNo { get; set; }
        public string LotDate { get; set; }
        public int? Point { get; set; }
        public string CustShopType { get; set; }
        public string OrderID { get; set; }
        public string DSMID { get; set; }
        public string DSRID { get; set; }
        public string OBAMID { get; set; }
    }
}
