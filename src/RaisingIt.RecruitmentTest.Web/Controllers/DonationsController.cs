using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaisingIt.RecruitmentTest.Domain.Donations;
using System.Threading.Tasks;

namespace RaisingIt.RecruitmentTest.Web.Controllers
{
    public class DonationsController : Controller
    {
        private readonly IDonationClient _donationClient;

        public DonationsController(IDonationClient donationClient)
        {
            _donationClient = donationClient;
        }

        public async Task<ActionResult> Index()
        {
            Donation[] donations = await _donationClient.ListDonations();
            return View(donations);
        }

        // GET: Donations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Back()
        {
            return RedirectToAction("Index", "Home", new { });
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donations/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Donations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
