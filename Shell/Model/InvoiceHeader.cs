using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class InvoiceHeader
    {
        public string InvoiceNo { get; set; } = null!;
        public string InvoiceDate { get; set; } = null!;
        public string ShoppingNo { get; set; } = null!;
        public string Acode { get; set; } = null!;
        public int InvoiceStatusId { get; set; }
        public string? AddDate { get; set; }
        public string? AddTime { get; set; }
        public string? EditDate { get; set; }
        public string? EditTime { get; set; }
        public string? EditUserId { get; set; }
        public string? LotNo { get; set; }
    }
}
