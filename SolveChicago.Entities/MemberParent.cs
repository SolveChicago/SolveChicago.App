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
    
    public partial class MemberParent
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public bool IsBiological { get; set; }
    
        public virtual Member Children { get; set; }
        public virtual Member Parents { get; set; }
    }
}