﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SolveChicago.Web.Models;
using SolveChicago.Common;
using SolveChicago.Web.Controllers;
using System.Diagnostics.CodeAnalysis;
using SolveChicago.Entities;
using SolveChicago.Service;

namespace SolveChicago.Web.Controllers
{
    [ExcludeFromCodeCoverage]
    public class RegisterController : BaseController
    {

        //
        // GET: /Register/Admin
        [AllowAnonymous]
        public ActionResult Admin(string inviteCode)
        {
            string userId = "";
            AdminService service = new AdminService(this.db);
            if (!service.ValidateAdminInvite(HttpUtility.UrlDecode(inviteCode), ref userId)) // refactor to be encryption check
            {
                return HttpNotFound();
            }
            AdminRegisterViewModel model = new AdminRegisterViewModel();
            model.InvitedByUserId = userId;
            model.InviteCode = inviteCode;
            return View(model);
        }

        //
        // POST: /Register/Admin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Admin(AdminRegisterViewModel model)
        {
            var result = await CreateAccount(model.Email, model.Password, Enumerations.Role.Admin, model.InvitedByUserId, model.InviteCode);
            if (result != null)
                return result;
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Register/Member
        [AllowAnonymous]
        public ActionResult Member(int? id)
        {
            MemberRegisterViewModel model = new MemberRegisterViewModel
            {
                MemberId = id,
            };
            if(id.HasValue)
            {
                Member member = db.Members.Find(id.Value);
                if (member != null)
                    model.Email = member.Email;
            }
            return View(model);
        }

        //
        // POST: /Register/Member
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Member(RegisterViewModel model)
        {
            var result = await CreateAccount(model.Email, model.Password, Enumerations.Role.Member);
            if (result != null)
                return result;
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Register/Corporation
        [AllowAnonymous]
        public ActionResult Corporation()
        {
            return View();
        }

        //
        // POST: /Register/Corporation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Corporation(RegisterViewModel model)
        {
            var result = await CreateAccount(model.Email, model.Password, Enumerations.Role.Corporation);
            if (result != null)
                return result;
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Register/Referrer
        [AllowAnonymous]
        public ActionResult Referrer()
        {
            return View();
        }

        //
        // POST: /Register/Referrer
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Referrer(RegisterViewModel model)
        {
            var result = await CreateAccount(model.Email, model.Password, Enumerations.Role.Referrer);
            if (result != null)
                return result;
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Register/CaseManager
        [AllowAnonymous]
        public ActionResult CaseManager(int? nonprofitId)
        {
            if (!nonprofitId.HasValue)
                return HttpNotFound();
            ViewBag.NonProfitId = nonprofitId.Value;
            return View();
        }

        //
        // POST: /Register/CaseManager
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CaseManager(RegisterViewModel model)
        {
            var result = await CreateAccount(model.Email, model.Password, Enumerations.Role.CaseManager);
            if (result != null)
                return result;
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Register/Nonprofit
        [AllowAnonymous]
        public ActionResult Nonprofit()
        {
            return View();
        }

        //
        // POST: /Register/Nonprofit
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Nonprofit(RegisterViewModel model)
        {
            var result = await CreateAccount(model.Email, model.Password, Enumerations.Role.Nonprofit);
            if (result != null)
                return result;
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}