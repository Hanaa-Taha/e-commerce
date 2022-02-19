﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ecomerce.Models
{
    public partial class TblMemberRole
    {
        public int MemberRoleId { get; set; }
        public int? MemberId { get; set; }
        public int? RoleId { get; set; }
    }
}
