using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class ImportLog
    {
        public long Id { get; set; }
        public string? ImportId { get; set; }
        public int? RowData { get; set; }
        public string? Remark { get; set; }
    }
}
