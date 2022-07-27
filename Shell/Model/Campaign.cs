using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class Campaign
    {
        public string CampaignCode { get; set; } = null!;
        public string? CampaignName { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Status { get; set; }
        public string? UserEdit { get; set; }
        public string? UserDate { get; set; }
    }
}
