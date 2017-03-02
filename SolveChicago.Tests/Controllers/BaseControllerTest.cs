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
using SolveChicago.Web.Data;

namespace SolveChicago.Tests.Controllers
{
    public class BaseControllerTest
    {
        [Fact]
        public void MemberRedirect_WithEntity_Returns_Member_Index()
        {
            List<Member> data = new List<Member>
            {
                new Member
                {
                    Email = "member@solvechicago.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Id = 1,
                    FirstName = "Tom",
                    LastName = "Elliot",
                    Phone = "1234567890",
                    ProfilePicturePath = "../image.jpg",
                }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("Members", result.RouteValues["controller"]);
        }

        [Fact]
        public void MemberRedirect_WithEntity_Returns_Profile_Member()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1 }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("Member", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void MemberRedirect_NoEntity_Returns_Member_Index()
        {
            List<Member> data = new List<Member>
            {
                new Member()
                {
                    Email = "member@solvechicago.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Id = 1,
                    FirstName = "Tom",
                    LastName = "Elliot",
                    Phone = "1234567890",
                    ProfilePicturePath = "../image.jpg",
                }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("Members", result.RouteValues["controller"]);
        }

        [Fact]
        public void MemberRedirect_NoEntity_Returns_Profile_Member()
        {
            List<Member> data = new List<Member>
            {
                new Member() { Id = 1 }
            };

            var set = new Mock<DbSet<Member>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.Members).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.MemberRedirect(1);

            Assert.Equal("Member", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void CaseManagerRedirect_WithEntity_Returns_CaseManager_Index()
        {
            CaseManager entity = new CaseManager
            {
                Email = "casemanager@solvechicago.com",
                CreatedDate = DateTime.UtcNow.AddDays(-10),
                Id = 1,
                FirstName = "Tom",
                LastName = "Elliot",
                Phone = "1234567890",
                ProfilePicturePath = "../image.jpg",
            };
            BaseController controller = new BaseController();
            var result = (RedirectToRouteResult)controller.CaseManagerRedirect(entity);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("CaseManagers", result.RouteValues["controller"]);
        }

        [Fact]
        public void CaseManagerRedirect_WithEntity_Returns_Profile_CaseManager()
        {
            CaseManager entity = new CaseManager();
            BaseController controller = new BaseController();
            var result = (RedirectToRouteResult)controller.CaseManagerRedirect(entity);

            Assert.Equal("CaseManager", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void CaseManagerRedirect_NoEntity_Returns_CaseManager_Index()
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
                    Phone = "1234567890",
                    ProfilePicturePath = "../image.jpg",
                }
            };

            var set = new Mock<DbSet<CaseManager>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.CaseManagers).Returns(set.Object);

            BaseController controller = new BaseController(context.Object);
            var result = (RedirectToRouteResult)controller.CaseManagerRedirect(1);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("CaseManagers", result.RouteValues["controller"]);
        }

        [Fact]
        public void CaseManagerRedirect_NoEntity_Returns_Profile_CaseManager()
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
        public void CorporationRedirect_WithEntity_Returns_Corporation_Index()
        {
            Corporation entity = new Corporation
            {
                Email = "corporation@solvechicago.com",
                CreatedDate = DateTime.UtcNow.AddDays(-10),
                Id = 1,
                Name = "Tom Elliot",
            };
            BaseController controller = new BaseController();
            var result = (RedirectToRouteResult)controller.CorporationRedirect(entity);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("Corporations", result.RouteValues["controller"]);
        }

        [Fact]
        public void CorporationRedirect_WithEntity_Returns_Profile_Corporation()
        {
            Corporation entity = new Corporation();
            BaseController controller = new BaseController();
            var result = (RedirectToRouteResult)controller.CorporationRedirect(entity);

            Assert.Equal("Corporation", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void CorporationRedirect_NoEntity_Returns_Corporation_Index()
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
        public void CorporationRedirect_NoEntity_Returns_Profile_Corporation()
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
        public void NonprofitRedirect_WithEntity_Returns_Nonprofit_Index()
        {
            Nonprofit entity = new Nonprofit
            {
                Address1 = "123 Main Street",
                Address2 = "Apt 2",
                City = "Chicago",
                Province = "IL",
                Country = "USA",
                Email = "nonprofit@solvechicago.com",
                CreatedDate = DateTime.UtcNow.AddDays(-10),
                Id = 1,
                Name = "Tom Elliot",
                Phone = "1234567890",
            };
            BaseController controller = new BaseController();
            var result = (RedirectToRouteResult)controller.NonprofitRedirect(entity);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("Nonprofits", result.RouteValues["controller"]);
        }

        [Fact]
        public void NonprofitRedirect_WithEntity_Returns_Profile_Nonprofit()
        {
            Nonprofit entity = new Nonprofit();
            BaseController controller = new BaseController();
            var result = (RedirectToRouteResult)controller.NonprofitRedirect(entity);

            Assert.Equal("Nonprofit", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void NonprofitRedirect_NoEntity_Returns_Nonprofit_Index()
        {
            List<Nonprofit> data = new List<Nonprofit>
            {
                new Nonprofit()
                {
                    Address1 = "123 Main Street",
                    Address2 = "Apt 2",
                    City = "Chicago",
                    Province = "IL",
                    Country = "USA",
                    Email = "nonprofit@solvechicago.com",
                    CreatedDate = DateTime.UtcNow.AddDays(-10),
                    Id = 1,
                    Name = "Tom Elliot",
                    Phone = "1234567890",
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
        public void NonprofitRedirect_NoEntity_Returns_Profile_Nonprofit()
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
        public void AdminRedirect_WithEntity_Returns_Admin_Index()
        {
            Admin entity = new Admin
            {
                Email = "admin@solvechicago.com",
                CreatedDate = DateTime.UtcNow.AddDays(-10),
                Id = 1,
                FirstName = "Tom",
                LastName = "Elliot",
                Phone = "1234567890",
                ProfilePicturePath = "../image.jpg",
            };
            BaseController controller = new BaseController();
            var result = (RedirectToRouteResult)controller.AdminRedirect(entity);

            Assert.Equal("Index", result.RouteValues["action"]);
            Assert.Equal("Admins", result.RouteValues["controller"]);
        }

        [Fact]
        public void AdminRedirect_WithEntity_Returns_Profile_Admin()
        {
            Admin entity = new Admin();
            BaseController controller = new BaseController();
            var result = (RedirectToRouteResult)controller.AdminRedirect(entity);

            Assert.Equal("Admin", result.RouteValues["action"]);
            Assert.Equal("Profile", result.RouteValues["controller"]);
        }

        [Fact]
        public void AdminRedirect_NoEntity_Returns_Admin_Index()
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
                    Phone = "1234567890",
                    ProfilePicturePath = "../image.jpg",
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
        public void AdminRedirect_NoEntity_Returns_Profile_Admin()
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
        public void RefreshState_WithCaseManager_Member()
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
                            Phone = "1234567890",
                            ProfilePicturePath = "../image.jpg",
                            MemberNonprofits = new List<MemberNonprofit>
                            {
                                new MemberNonprofit
                                {
                                    CaseManagerId = 1,
                                    MemberId = 1,
                                    Member = new Member
                                    {
                                        Email = "member@solvechicago.com",
                                        CreatedDate = DateTime.UtcNow.AddDays(-10),
                                        Id = 1,
                                        FirstName = "Tom",
                                        LastName = "Elliot",
                                        Phone = "1234567890",
                                        ProfilePicturePath = "../image.jpg",
                                    },
                                    CaseManager = new CaseManager
                                    {
                                        Id = 1,
                                        FirstName = "Terry",
                                        LastName = "Jones",
                                    }
                                }
                            }
                        }
                    },
                }
            };

            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("member@solvechicago.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            var userSet = new Mock<DbSet<AspNetUser>>().SetupData(users);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(userSet.Object);
            BaseController controller = new BaseController(context.Object);

            //Set your controller ControllerContext with fake context
            controller.ControllerContext = controllerContext.Object;

            string name = controller.State.Member.FirstName;
            Assert.Equal("Tom", name);

            string caseManagerName = controller.State.Member.MemberNonprofits.Select(x => x.CaseManager).First().FirstName;
            Assert.Equal("Terry", caseManagerName);

        }

        [Fact]
        public void RefreshState_CaseManager()
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
                            Phone = "1234567890",
                            ProfilePicturePath = "../image.jpg",
                        }
                    },
                }
            };

            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("casemanager@solvechicago.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            var set = new Mock<DbSet<AspNetUser>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(set.Object);
            BaseController controller = new BaseController(context.Object);

            //Set your controller ControllerContext with fake context
            controller.ControllerContext = controllerContext.Object;

            string name = controller.State.CaseManager.FirstName;
            Assert.Equal("Terry", name);

        }

        [Fact]
        public void RefreshState_Corporation()
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

            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("corporation@solvechicago.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);
            
            var userSet = new Mock<DbSet<AspNetUser>>().SetupData(users);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(userSet.Object);
            BaseController controller = new BaseController(context.Object);

            //Set your controller ControllerContext with fake context
            controller.ControllerContext = controllerContext.Object;

            string name = controller.State.Corporation.Name;
            Assert.Equal("Honda Ferguson", name);

        }

        [Fact]
        public void RefreshState_Nonprofit()
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
                            Address1 = "123 Main Street",
                            Address2 = "Apt 2",
                            City = "Chicago",
                            Province = "IL",
                            Country = "USA",
                            Email = "nonprofit@solvechicago.com",
                            CreatedDate = DateTime.UtcNow.AddDays(-10),
                            Id = 1,
                            Name = "Vladimir Kruschev",
                            Phone = "1234567890",
                        }
                    },
                }
            };

            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("nonprofit@solvechicago.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);
            
            var userSet = new Mock<DbSet<AspNetUser>>().SetupData(users);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(userSet.Object);
            BaseController controller = new BaseController(context.Object);

            //Set your controller ControllerContext with fake context
            controller.ControllerContext = controllerContext.Object;

            string name = controller.State.Nonprofit.Name;
            Assert.Equal("Vladimir Kruschev", name);

        }

        [Fact]
        public void RefreshState_Admin()
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
                            Phone = "1234567890",
                            ProfilePicturePath = "../image.jpg",
                        }
                    }
                }
            };

            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("admin@solvechicago.com");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            var set = new Mock<DbSet<AspNetUser>>().SetupData(data);

            var context = new Mock<SolveChicagoEntities>();
            context.Setup(c => c.AspNetUsers).Returns(set.Object);
            BaseController controller = new BaseController(context.Object);

            //Set your controller ControllerContext with fake context
            controller.ControllerContext = controllerContext.Object;

            string name = controller.State.Admin.FirstName;
            Assert.Equal("Peter", name);

        }
    }
}