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
    
    public partial class MemberSkill
    {
        public int MemberId { get; set; }
        public int SkillId { get; set; }
        public Nullable<int> NonprofitSkillsId { get; set; }
        public bool IsComplete { get; set; }
    
        public virtual NonprofitSkill NonprofitSkill { get; set; }
        public virtual Skill Skill { get; set; }
        public virtual Member Member { get; set; }
    }
}
