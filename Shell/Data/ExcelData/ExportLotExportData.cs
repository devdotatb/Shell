namespace Shell.Data.ExcelData
{
    public class ExportLotExportData
    {
        public string InvoiceNo { get; set; } // [เลขที่ใบสั่งซื้อ]
        public string InvoiceDate { get; set; } // [วันที่สั่งซื้อ]
        public string ACode { get; set; } // [*A Code ]
        public string SiteName { get; set; } // [*Site Name]
        public string Site { get; set; } // [*Site (28)]
        public string ShopType { get; set; } // [*Shop Type (3)]
        public string Tier { get; set; } // [*Tier (3)]
        public string SalesTextCode { get; set; } // [Sales Text]
        public string MaterialCode { get; set; } // [MaterialCode]
        public string ProductNameTH { get; set; } // [ชื่อสินค้า(ไทย)]
        public int? ProductQuantity { get; set; } // [ขนาดบรรจุภัณฑ์(ลิตร)]
        public int? ProductQty { get; set; } // [จำนวนสั่งซื้อ]
        public string ProductUnit { get; set; } // [หน่วยสินค้า]
        public int? ProductPerUnit { get; set; } // [จำนวนบรรจุภัณฑ์ต่อหน่วยสินค้า]
        public string InvoiceStatusName { get; set; } // [สถานะล่าสุด]
        public string EditDate { get; set; } // [วันที่สถานะล่าสุด]
        public string CustShopType { get; set; } // [CustShopType]
        public string CustSubShopType { get; set; } // [Cust. Sub shop type]
        public int Point { get; set; } // [แต้ม]
        public string LotNo { get; set; } // [Lot No.]
        public string LotDate { get; set; } // [วันที่ Lot No.]


        public DateTimeOffset? InvoiceDate_Datetime { get; set; }
    }
}
