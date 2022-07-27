using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class MatchField
    {
        public int Fieldndex { get; set; }
        public string FieldType { get; set; } = null!;
        public string? FieldExcel { get; set; }
        public string? FieldData { get; set; }
        public bool? IsImport { get; set; }
    }
}
