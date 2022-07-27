using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class ShoppingDetail
    {
        public long Id { get; set; }
        public string ShoppingNo { get; set; } = null!;
        public string MaterialCode { get; set; } = null!;
        public int? ProductQty { get; set; }
    }
}
