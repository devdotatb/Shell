namespace Shell.Data
{
    public class OrdereditSearchData
    {
        public int? ProductQty { get; set; }
        public int? ProductQuantityLimit { get; set; }
        public string? MaterialCode { get; set; }
        public string? ProductPic { get; set; }
        public string? ProductName { get; set; }
        public string? ProductSubPic { get; set; }
        public string? ProductSub { get; set; }
        public string? CustShopType { get; set; }
        public string? SHAREID { get; set; }
        public int CurrentPoint { get; set; }
        public int CurrentBonusPoint { get; set; }
        public string? ProductUnit { get; set; }
        public string? ProductDes { get; set; }

        //for binding
        public int binding_qty { get; set; }
        public string? binding_isuse { get; set; }
        public string? binding_itemuse { get; set; }

        //for filter
        public bool? BestSeller { get; set; }
        public string? ProductGroup { get; set; }
    }
}
