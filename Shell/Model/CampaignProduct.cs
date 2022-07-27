using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class CampaignProduct
    {
        public string CampaignCode { get; set; } = null!;
        public string MaterialCode { get; set; } = null!;
        public int? Point { get; set; }
        public string? AcodeUse { get; set; }
    }
}
