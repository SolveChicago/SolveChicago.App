﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using SolveChicago.Web.Controllers;

namespace SolveChicago.Tests.Controllers
{     
    [TestClass]
    public class RegisterControllerTest
    {
        //[TestMethod]
        public void Can_Register_Member()
        {
            string email = string.Format("{0}@solvechicago.com", Guid.NewGuid().ToString());
            string password = Guid.NewGuid().ToString();

            RegisterController controller = new RegisterController();
            controller.Member(new Web.Models.RegisterViewModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = password
            }).Wait();
        }
    }
}
