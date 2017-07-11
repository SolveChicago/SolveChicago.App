﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Web;
using SolveChicago.Web.Controllers;
using System.IO;
using System.Web.Mvc;
using System.Data.Entity;
using Moq;
using System.Security.Principal;
using static SolveChicago.Web.Controllers.BaseController;
using SolveChicago.Entities;
using System.Diagnostics.CodeAnalysis;
using SolveChicago.Web.Models;
using SolveChicago.Common;
using System.Security.Claims;
using System.Threading;

namespace SolveChicago.Tests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class BaseControllerTest : BaseController
    {

        [Fact]
        public void BaseController_MemberRedirect_ReturnsRedirectToRouteResult_MembersSurvey()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = Constants.Member.SurveyStep.Invited }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("Survey", result.RouteValues["action"]);
            Assert.Equal("Members", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_MemberRedirect_ReturnsRedirectToRouteResult_ProfileMemberPersonal()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = Constants.Member.SurveyStep.Personal }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("MemberPersonal", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_MemberRedirect_ReturnsRedirectToRouteResult_ProfileMemberFamily()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = Constants.Member.SurveyStep.Family }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("MemberFamily", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_MemberRedirect_ReturnsRedirectToRouteResult_ProfileMemberEducation()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = Constants.Member.SurveyStep.Education }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("MemberSchools", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_MemberRedirect_ReturnsRedirectToRouteResult_ProfileMemberJobs()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = Constants.Member.SurveyStep.Jobs }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("MemberJobs", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_MemberRedirect_ReturnsRedirectToRouteResult_ProfileMemberNonprofits()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = Constants.Member.SurveyStep.Nonprofits }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("MemberNonprofits", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_MemberRedirect_ReturnsRedirectToRouteResult_ProfileMemberGovernmentPrograms()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = Constants.Member.SurveyStep.GovernmentPrograms }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("MemberGovernmentPrograms", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_MemberRedirect_ReturnsRedirectToRouteResult_MembersIndex()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = Constants.Member.SurveyStep.Complete }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("MemberOverview", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_MemberRedirect_InvalidSurveyStep_ReturnsRedirectToRouteResult_ProfileMemberPersonal()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1, SurveyStep = "NotASurveyStep" }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("MemberPersonal", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_CaseManagerRedirect_ReturnsRedirectToRouteResult_CaseManagerIndex()
        {
            List<CaseManager> data = new List<CaseManager>
            {
                new CaseManager()
                {
                    Email = "casemanager@solvechicago.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Id = 1,
                    FirstName = "Tom",
                    LastName = "Elliot",
                    ProfilePicturePath = "../image.jpg",
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber
                        {
                            Number = "1234567890",
                        }
                    }
                }
            };
            List<PhoneNumber> phones = new List<PhoneNumber>();

            var set = new Mock<DbSet<CaseManager>>().SetupData(data);
            var phoneSet = new Mock<DbSet<PhoneNumber>>().SetupData(phones);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.CaseManagers).Returns(set.Object);
            context.Setup(c => c.PhoneNumbers).Returns(phoneSet.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.CaseManagerRedirect(1);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("CaseManagers", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_CaseManagerRedirect_ReturnsRedirectToRouteResult_ProfileCaseManager()
        {
            List<CaseManager> data = new List<CaseManager>
            {
                new CaseManager() { Id = 1 }
            };

            var set = new Mock<DbSet<CaseManager>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.CaseManagers).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.CaseManagerRedirect(1);

            Assert.Equal("CaseManager", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_CorporationRedirect_ReturnsRedirectToRouteResult_CorporationIndex()
        {
            List<Corporation> data = new List<Corporation>
            {
                new Corporation()
                {
                    Email = "corporation@solvechicago.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Id = 1,
                    Name = "Tom Elliot",
                }
            };

            var set = new Mock<DbSet<Corporation>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Corporations).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.CorporationRedirect(1);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("Corporations", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_CorporationRedirect_ReturnsRedirectToRouteResult_ProfileCorporation()
        {
            List<Corporation> data = new List<Corporation>
            {
                new Corporation() { Id = 1 }
            };

            var set = new Mock<DbSet<Corporation>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Corporations).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.CorporationRedirect(1);

            Assert.Equal("Corporation", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_NonprofitRedirect_ReturnsRedirectToRouteResult_NonprofitIndex()
        {
            List<Nonprofit> data = new List<Nonprofit>
            {
                new Nonprofit()
                {
                    Addresses = new List<Address>
                    {
                        new Address
                        {
                            Address1 = "123 Main Street",
                            Address2 = "Apt 2",
                            City = "Chicago",
                            Province = "IL",
                            Country = "USA",
                            ZipCode = "60254"
                        }
                    },
                    
                    Email = "nonprofit@solvechicago.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Id = 1,
                    Name = "Tom Elliot",
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber
                        {
                            Number = "1234567890",
                        }
                    }
                }
            };

            var set = new Mock<DbSet<Nonprofit>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Nonprofits).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.NonprofitRedirect(1);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("Nonprofits", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_NonprofitRedirect_ReturnsRedirectToRouteResult_ProfileNonprofit()
        {
            List<Nonprofit> data = new List<Nonprofit>
            {
                new Nonprofit() { Id = 1 }
            };

            var set = new Mock<DbSet<Nonprofit>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Nonprofits).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.NonprofitRedirect(1);

            Assert.Equal("Nonprofit", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_AdminRedirect_ReturnsRedirectToRouteResult_AdminIndex()
        {
            List<Admin> data = new List<Admin>
            {
                new Admin()
                {
                    Email = "admin@solvechicago.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Id = 1,
                    FirstName = "Tom",
                    LastName = "Elliot",
                    ProfilePicturePath = "../image.jpg",
                    PhoneNumbers = new List<PhoneNumber>
                    {
                        new PhoneNumber
                        {
                            Number = "1234567890"
                        }
                    }
                }
            };

            var set = new Mock<DbSet<Admin>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Admins).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.AdminRedirect(1);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("Admins", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_AdminRedirect_ReturnsRedirectToRouteResult_ProfileAdmin()
        {
            List<Admin> data = new List<Admin>
            {
                new Admin() { Id = 1 }
            };

            var set = new Mock<DbSet<Admin>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Admins).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.AdminRedirect(1);

            Assert.Equal("Admin", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void BaseController_RefreshState_UpdatesCaseManager_UpdatesMember()
        {
            List<AspNetUser> users = new List<AspNetUser>
            {
                new AspNetUser
                {
                    Id = "JHUIGYFTRDXS",
                    UserName = "member@solvechicago.com",
                    AspNetRoles = new List<AspNetRole>
                    {
                        new AspNetRole { Id = "KJHGF", Name = "Member" }
                    },
                    Members = new List<Member>
                    {
                        new Member()
                        {
                            Email = "member@solvechicago.com",
                            CreatedDate = DateTime.UtcNow.AddDays(-10),
                            Id = 1,
                            FirstName = "Tom",
                            LastName = "Elliot",
                            ProfilePicturePath = "../image.jpg",
                            NonprofitMembers = new List<NonprofitMember>
                            {
                                new NonprofitMember
                                {
                                    MemberId = 1,
                                    Member = new Member
                                    {
                                        Email = "member@solvechicago.com",
                                        CreatedDate = DateTime.UtcNow.AddDays(-10),
                                        Id = 1,
                                        FirstName = "Tom",
                                        LastName = "Elliot",
                                        ProfilePicturePath = "../image.jpg",
                                    },
                                    NonprofitStaffs = new List<NonprofitStaff>
                                    {
                                        new NonprofitStaff
                                        {
                                            CaseManager = new CaseManager
                                            {
                                                Id = 1,
                                                FirstName = "Terry",
                                                LastName = "Jones",
                                            },
                                        }
                                    }
                                }
                            }
                        }
                    },
                }
            };

            // mock Identity
            var username = "member@solvechicago.com";
            var userId = "JHUIGYFTRDXS";
            var identity = new GenericIdentity(username, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            Thread.CurrentPrincipal = mockPrincipal.Object;

            // mock controller
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            controllerContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var userSet = new Mock<DbSet<AspNetUser>>().SetupData(users);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(userSet.Object);
            BaseController controller = new BaseController(context.Object) { ControllerContext = controllerContext.Object };

            string name = controller.State.Member.FirstName;
            Assert.Equal("Tom", name);

            string caseManagerName = controller.State.Member.NonprofitMembers.SelectMany(x => x.NonprofitStaffs).First().CaseManager.FirstName;
            Assert.Equal("Terry", caseManagerName);

        }

        [Fact]
        public void BaseController_RefreshState_UpdatesCaseManager()
        {
            List<AspNetUser> data = new List<AspNetUser>
            {
                new AspNetUser
                {
                    Id = "JHUIGYFTRDXS",
                    UserName = "casemanager@solvechicago.com",
                    AspNetRoles = new List<AspNetRole>
                    {
                        new AspNetRole { Id = "KJHGF", Name = "CaseManager" }
                    },
                    CaseManagers = new List<CaseManager>
                    {
                        new CaseManager()
                        {
                            Email = "casemanager@solvechicago.com",
                            CreatedDate = DateTime.UtcNow.AddDays(-10),
                            Id = 1,
                            FirstName = "Terry",
                            LastName = "Jones",
                            PhoneNumbers = new List<PhoneNumber>
                            {
                                new PhoneNumber
                                {
                                    Id = 1,
                                    Number = "1234567890",
                                }
                            },
                            ProfilePicturePath = "../image.jpg",
                        }
                    },
                }
            };

            // mock Identity
            var username = "casemanager@solvechicago.com";
            var userId = "JHUIGYFTRDXS";
            var identity = new GenericIdentity(username, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            Thread.CurrentPrincipal = mockPrincipal.Object;

            // mock controller
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            controllerContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var set = new Mock<DbSet<AspNetUser>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(set.Object);
            BaseController controller = new BaseController(context.Object)
            {
                ControllerContext = controllerContext.Object
            };
            string name = controller.State.CaseManager.FirstName;
            Assert.Equal("Terry", name);

        }

        [Fact]
        public void BaseController_RefreshState_UpdatesCorporation()
        {
            List<AspNetUser> users = new List<AspNetUser>
            {
                new AspNetUser
                {
                    Id = "JHUIGYFTRDXS",
                    UserName = "corporation@solvechicago.com",
                    AspNetRoles = new List<AspNetRole>
                    {
                        new AspNetRole { Id = "KJHGF", Name = "Corporation" }
                    },
                    Corporations = new List<Corporation>
                    {
                        new Corporation()
                        {
                            Email = "corporation@solvechicago.com",
                            CreatedDate = DateTime.UtcNow.AddDays(-10),
                            Id = 1,
                            Name = "Honda Ferguson",
                        }
                    },
                }
            };

            // mock Identity
            var username = "corporation@solvechicago.com";
            var userId = "JHUIGYFTRDXS";
            var identity = new GenericIdentity(username, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            Thread.CurrentPrincipal = mockPrincipal.Object;

            // mock controller
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            controllerContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var userSet = new Mock<DbSet<AspNetUser>>().SetupData(users);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(userSet.Object);
            BaseController controller = new BaseController(context.Object)
            {

                //Set your controller ControllerContext with fake context
                ControllerContext = controllerContext.Object
            };
            string name = controller.State.Corporation.Name;
            Assert.Equal("Honda Ferguson", name);

        }

        [Fact]
        public void BaseController_RefreshState_UpdatesNonprofit()
        {
            List<AspNetUser> users = new List<AspNetUser>
            {
                new AspNetUser
                {
                    Id = "JHUIGYFTRDXS",
                    UserName = "nonprofit@solvechicago.com",
                    AspNetRoles = new List<AspNetRole>
                    {
                        new AspNetRole { Id = "KJHGF", Name = "Nonprofit" }
                    },
                    Nonprofits = new List<Nonprofit>
                    {
                        new Nonprofit()
                        {
                            Addresses = new List<Address>
                            {
                                new Address
                                {
                                    Address1 = "123 Main Street",
                                    Address2 = "Apt 2",
                                    City = "Chicago",
                                    Province = "IL",
                                    Country = "USA",
                                }
                            },
                            PhoneNumbers = new List<PhoneNumber>
                            {
                                new PhoneNumber
                                {
                                    Id = 1,
                                    Number = "1234567890",
                                }
                            },
                            Email = "nonprofit@solvechicago.com",
                            CreatedDate = DateTime.UtcNow.AddDays(-10),
                            Id = 1,
                            Name = "My NPO",
                        }
                    },
                }
            };

            // mock Identity
            var username = "nonprofit@solvechicago.com";
            var userId = "JHUIGYFTRDXS";
            var identity = new GenericIdentity(username, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            Thread.CurrentPrincipal = mockPrincipal.Object;

            // mock controller
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            controllerContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var userSet = new Mock<DbSet<AspNetUser>>().SetupData(users);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(userSet.Object);
            BaseController controller = new BaseController(context.Object)
            {

                //Set your controller ControllerContext with fake context
                ControllerContext = controllerContext.Object
            };
            string name = controller.State.Nonprofit.Name;
            Assert.Equal("My NPO", name);

        }

        [Fact]
        public void BaseController_RefreshState_UpdatesAdmin()
        {

            List<AspNetUser> data = new List<AspNetUser>
            {
                new AspNetUser
                {
                    Id = "JHUIGYFTRDXS",
                    UserName = "admin@solvechicago.com",
                    AspNetRoles = new List<AspNetRole>
                    {
                        new AspNetRole { Id = "KJHGF", Name = "Admin" }
                    },
                    Admins = new List<Admin>
                    {
                        new Admin()
                        {
                            Email = "admin@solvechicago.com",
                            CreatedDate = DateTime.UtcNow.AddDays(-10),
                            Id = 1,
                            FirstName = "Peter",
                            LastName = "Thompson",
                            ProfilePicturePath = "../image.jpg",
                            PhoneNumbers = new List<PhoneNumber>
                            {
                                new PhoneNumber
                                {
                                    Id = 1,
                                    Number = "1234567890"
                                }
                            }
                        }
                    }
                }
            };

            // mock Identity
            var username = "admin@solvechicago.com";
            var userId = "JHUIGYFTRDXS";
            var identity = new GenericIdentity(username, "");
            var nameIdentifierClaim = new Claim(ClaimTypes.NameIdentifier, userId);
            identity.AddClaim(nameIdentifierClaim);

            var mockPrincipal = new Mock<IPrincipal>();
            mockPrincipal.Setup(x => x.Identity).Returns(identity);
            Thread.CurrentPrincipal = mockPrincipal.Object;

            // mock controller
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.SetupGet(p => p.HttpContext.User).Returns(mockPrincipal.Object);
            controllerContext.SetupGet(p => p.HttpContext.Request.IsAuthenticated).Returns(true);

            var set = new Mock<DbSet<AspNetUser>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(set.Object);
            BaseController controller = new BaseController(context.Object)
            {

                //Set your controller ControllerContext with fake context
                ControllerContext = controllerContext.Object
            };
            string name = controller.State.Admin.FirstName;
            Assert.Equal("Peter", name);

        }
    }
}