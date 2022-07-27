using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class Lot
    {
        public string LotNo { get; set; } = null!;
        public string? LotDate { get; set; }
        public string? LotTime { get; set; }
        public string? LotUserId { get; set; }
    }
}
