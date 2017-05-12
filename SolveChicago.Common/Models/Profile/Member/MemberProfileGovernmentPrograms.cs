﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolveChicago.Common.Interfaces.Profile.Member;

namespace SolveChicago.Common.Models.Profile.Member
{

    public class MemberProfileGovernmentPrograms : IMemberProfileGovernmentPrograms
    {
        public int MemberId { get; set; }
        public int[] GovernmentProgramsIds { get; set; }
        public GovernmentProgramEntity[] GovernmentPrograms { get; set; }
    }

    public class GovernmentProgramEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ProgramId { get; set; }
        public string ProgramName { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Start { get; set; }
        public bool IsCurrent { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? End { get; set; }
        public decimal? Amount { get; set; }
    }
}
