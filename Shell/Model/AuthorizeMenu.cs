using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class AuthorizeMenu
    {
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public int? MenuMain { get; set; }
        public int? MenuPosition { get; set; }
    }
}
