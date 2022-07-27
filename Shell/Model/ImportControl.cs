using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class ImportControl
    {
        public string ImportId { get; set; } = null!;
        public string? ImportType { get; set; }
        public decimal? ImportDateTime { get; set; }
        public string? UsrId { get; set; }
        public string? Result { get; set; }
        public string? Remark { get; set; }
    }
}
