using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class AuthorizeMenuDocument
    {
        public int? MenuId { get; set; }
        public int? DocId { get; set; }
        public int? AuthOrder { get; set; }
    }
}
