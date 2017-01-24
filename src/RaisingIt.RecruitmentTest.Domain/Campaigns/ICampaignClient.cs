using System.Threading.Tasks;

namespace RaisingIt.RecruitmentTest.Domain.Campaigns
{
    public interface ICampaignClient
    {
        Task<Campaign[]> ListCampaigns();
    }
}