using System;
using System.Collections.Generic;

namespace Shell.Model
{
    public partial class User
    {
        public string UserId { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Fullname { get; set; }
        public string? LineUid { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
        public string? Status { get; set; }
        public bool? UserUse { get; set; }
        public bool? RegisterCheck { get; set; }
        public string? RegisterDate { get; set; }
    }
}
