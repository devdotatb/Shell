namespace Shell.Data
{
    public class OrderlistSearchData
    {
        public int? total { get; set; }
        public int? Rows { get; set; }
        public string? InvoiceNo { get; set; }
        public string? InvoiceDate { get; set; }
        public DateTimeOffset? InvoiceDate_Datetime { get; set; }
        public int? InvoiceStatusID { get; set; }
        public string? InvoiceStatusName { get; set; }
        public string? EditDate { get; set; }
        public string? ACode { get; set; }
        public string? ShopName { get; set; }
        public string? Site { get; set; }
        public int? Point { get; set; }
        public string? CustShopType { get; set; }
    }
}
