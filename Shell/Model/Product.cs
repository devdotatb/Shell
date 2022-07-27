using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class Product
    {
        public string MaterialCode { get; set; } = null!;
        public string? SalesTextCode { get; set; }
        public string? ProductNameTh { get; set; }
        public string? ProductNameEn { get; set; }
        public string? ProductName { get; set; }
        public string? ProductType { get; set; }
        public string? ProductGroup { get; set; }
        public string? ProductModel { get; set; }
        public int? ProductQuantity { get; set; }
        public string? ProductCarType { get; set; }
        public string? ProductVis { get; set; }
        public string? ProductSub { get; set; }
        public string? ProductUnit { get; set; }
        public int? ProductPerUnit { get; set; }
        public string? ProductSize { get; set; }
        public string? ProductDesc { get; set; }
        public int? ProductQuantityLimit { get; set; }
        public string? ProductPic { get; set; }
        public string? AcodeUse { get; set; }
        public bool? BestSeller { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
