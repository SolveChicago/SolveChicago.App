//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SolveChicago.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class AdminInviteCode
    {
        public int Id { get; set; }
        public string InviteCode { get; set; }
        public string InvitingAdminUserId { get; set; }
        public string RecevingAdminUserId { get; set; }
        public bool IsStale { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
