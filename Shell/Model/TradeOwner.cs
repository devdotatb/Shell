using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class TradeOwner
    {
        public string Acode { get; set; } = null!;
        public string? GeoRegion { get; set; }
        public string? ClusterCode { get; set; }
        public string? SiteName { get; set; }
        public string? ShopName { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? LineUid { get; set; }
        public string? Dsmid { get; set; }
        public string? Dsrid { get; set; }
        public string? Obamid { get; set; }
        public string? Site { get; set; }
        public string? Brand { get; set; }
        public string? ShopType { get; set; }
        public string? CustShopType { get; set; }
        public string? CustSubShopType { get; set; }
        public string? Tier { get; set; }
        public bool? Agree { get; set; }
        public string? AgreeDate { get; set; }
        public string? Status { get; set; }
        public bool? RegisterCheck { get; set; }
        public string? RegisterDate { get; set; }
        public string? UserEdit { get; set; }
        public string? UserDate { get; set; }
        public string? LineName { get; set; }
    }
}
