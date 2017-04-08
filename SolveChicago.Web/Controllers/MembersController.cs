﻿using SolveChicago.Common.Models.Profile.Member;
using SolveChicago.Entities;
using SolveChicago.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolveChicago.Web.Controllers
{
    // GET: Members
    [Authorize(Roles = "Admin, Nonprofit, CaseManager, Member")]
    public class MembersController : BaseController, IDisposable
    {
        public MembersController(SolveChicagoEntities entities = null)
        {
            if (entities == null)
                db = new SolveChicagoEntities();
            else
                db = entities;
        }
        public MembersController() : base() { }

        public ActionResult Index(int? memberId)
        {
            ImpersonateMember(memberId);
            MemberService service = new MemberService(this.db);
            MemberProfile model = service.Get(State.MemberId);
            return View(model);
        }

        public ActionResult Details(int? memberId)
        {
            return Index(memberId);
        }
    }
}