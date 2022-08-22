namespace Shell.Data.ExcelData
{
    public class MasterExcelImportData
    {
        public string? GeoRegion { get; set; }
        public string? ClusterCode { get; set; }
        public string? SiteName { get; set; }
        public string? ShopName { get; set; }
        public string? ACode { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? DSMName { get; set; }
        public string? DSMID { get; set; }
        public string? DSRName { get; set; }
        public string? DSRID { get; set; }
        public string? OBAMName { get; set; }
        public string? OBAMID { get; set; }
        public string? OBAMPhone { get; set; }
        public string? OBAMEmail { get; set; }
        public string? Site { get; set; }
        public string? Brand { get; set; }
        public string? ShopType { get; set; }
        public string? CustShopType { get; set; }
        public string? CustSubShopType { get; set; }
        public string? Tier { get; set; }
        public string? LineUID { get; set; }
        public string? DSMLineUID { get; set; }
        public string? DSRLineUID { get; set; }
        public string? OBAMLineUID { get; set; }
        public string? Agree { get; set; }
        public string? AgreeDate { get; set; }
        public string? UserShare { get; set; }
        public string? DSRPhone { get; set; }
        public string? ShopAddress1 { get; set; }
        public string? ShopAddress2 { get; set; }
        public string? ShopPostalCode { get; set; }
        public string? ShopCompanyCity { get; set; }
        public string? StateName { get; set; }
        public string? ImportResult { get; set; }

        public MasterExcelImportData Clone()
        {
            return (MasterExcelImportData)MemberwiseClone();
        }
    }
}
