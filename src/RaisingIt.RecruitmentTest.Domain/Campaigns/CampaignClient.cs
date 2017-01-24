using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System;

namespace RaisingIt.RecruitmentTest.Domain.Campaigns
{
    public class CampaignClient : ICampaignClient
    {
        public async Task<Campaign[]> ListCampaigns()
        {
            return await ClientHelpers.BaseUrl
                                .AppendPathSegment("campaigns")
                                .GetJsonAsync<Campaign[]>();
        }

        public async Task<Campaign> GetCampaign(Guid guid)
        {
            return await ClientHelpers.BaseUrl
                                .AppendPathSegment("campaigns")
                                .AppendPathSegment(guid)
                                .GetJsonAsync<Campaign>();
        }
    }
}