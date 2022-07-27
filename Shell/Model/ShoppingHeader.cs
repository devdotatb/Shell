using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class ShoppingHeader
    {
        public string ShoppingNo { get; set; } = null!;
        public string Acode { get; set; } = null!;
        public bool? ShoppingUse { get; set; }
        public string? AddDate { get; set; }
        public string? AddTime { get; set; }
    }
}
