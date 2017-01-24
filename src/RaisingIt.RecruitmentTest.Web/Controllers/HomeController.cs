using System.Threading.Tasks;
using System.Web.Mvc;
using RaisingIt.RecruitmentTest.Domain.Campaigns;

namespace RaisingIt.RecruitmentTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICampaignClient _campaignClient;

        public HomeController(ICampaignClient campaignClient)
        {
            _campaignClient = campaignClient;
        }

        public async Task<ActionResult> Index()
        {
            Campaign[] campaigns = await _campaignClient.ListCampaigns();
            return View(campaigns);
        }
    }
}