using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class LogSendLine
    {
        public long Id { get; set; }
        public string? LogType { get; set; }
        public string? LogName { get; set; }
        public string? LogUid { get; set; }
        public string? LogJson { get; set; }
        public string? LogResult { get; set; }
        public string? LogDate { get; set; }
    }
}
