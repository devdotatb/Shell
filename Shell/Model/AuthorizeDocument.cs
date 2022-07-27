using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class AuthorizeDocument
    {
        public int DocId { get; set; }
        public string? DocName { get; set; }
        public bool? CreatePer { get; set; }
        public bool? EditPer { get; set; }
        public bool? ViewPer { get; set; }
        public bool? DeletePer { get; set; }
        public bool? ApprovePer { get; set; }
        public bool? PrintPer { get; set; }
        public bool? ExportPer { get; set; }
        public bool? DocUsed { get; set; }
    }
}
