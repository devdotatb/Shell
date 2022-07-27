using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class LogSystem
    {
        public long Id { get; set; }
        public string? UserId { get; set; }
        public string? LogType { get; set; }
        public string? LogDate { get; set; }
        public string? Ipaddress { get; set; }
    }
}
