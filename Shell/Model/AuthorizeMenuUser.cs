using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class AuthorizeMenuUser
    {
        public string UserId { get; set; } = null!;
        public int MenuId { get; set; }
        public bool? MenuUsed { get; set; }
    }
}
