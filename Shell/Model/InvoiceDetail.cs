using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class InvoiceDetail
    {
        public long Id { get; set; }
        public string InvoiceNo { get; set; } = null!;
        public string MaterialCode { get; set; } = null!;
        public int? ProductQty { get; set; }
        public string? AddDate { get; set; }
        public string? AddTime { get; set; }
        public string? AddUserId { get; set; }
        public string? EditDate { get; set; }
        public string? EditTime { get; set; }
        public string? EditUserId { get; set; }
        public bool? Deleted { get; set; }
    }
}
