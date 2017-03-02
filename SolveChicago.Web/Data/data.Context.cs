﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SolveChicago.Web.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SolveChicagoEntities : DbContext
    {
        public SolveChicagoEntities()
            : base("name=SolveChicagoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CaseManager> CaseManagers { get; set; }
        public virtual DbSet<CaseNote> CaseNotes { get; set; }
        public virtual DbSet<Corporation> Corporations { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<GovernmentProgram> GovernmentPrograms { get; set; }
        public virtual DbSet<MemberCorporation> MemberCorporations { get; set; }
        public virtual DbSet<MemberEmergencyContact> MemberEmergencyContacts { get; set; }
        public virtual DbSet<MemberGovernmentProgram> MemberGovernmentPrograms { get; set; }
        public virtual DbSet<MemberNonprofit> MemberNonprofits { get; set; }
        public virtual DbSet<MemberSkill> MemberSkills { get; set; }
        public virtual DbSet<MemberSurvey> MemberSurveys { get; set; }
        public virtual DbSet<Nonprofit> Nonprofits { get; set; }
        public virtual DbSet<Outcome> Outcomes { get; set; }
        public virtual DbSet<SurveyAnswer> SurveyAnswers { get; set; }
        public virtual DbSet<SurveyQuestionOption> SurveyQuestionOptions { get; set; }
        public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Member> Members { get; set; }
    }
}
