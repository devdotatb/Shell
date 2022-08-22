namespace Shell.Data.ExcelData
{
    public class ProductPointListExcelImportData
    {
        public string? SalesTextCode { get; set; }
        public string? MaterialCode { get; set; }
        public string? ProductNameTH { get; set; }
        public string? ProductNameEN { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public string? ProductGroup { get; set; }
        public string? ProductModel { get; set; }
        public string? ProductQuantity { get; set; }
        public string? ProductCarType { get; set; }
        public string? ProductVis { get; set; }
        public string? ProductSub { get; set; }
        public string? ProductUnit { get; set; }
        public string? ProductPerUnit { get; set; }
        public string? ProductSize { get; set; }
        public string? ProductDesc { get; set; }
        public string? ProductQuantityLimit { get; set; }
        public string? ProductPic { get; set; }
        public string? ACodeUse { get; set; }
        public string? BestSeller { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? SHARECode { get; set; }
        public string? ImportResult { get; set; }

        public ProductPointListExcelImportData Clone()
        {
            return (ProductPointListExcelImportData)MemberwiseClone();
        }
    }
}
