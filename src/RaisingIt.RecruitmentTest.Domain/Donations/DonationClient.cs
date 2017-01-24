using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RaisingIt.RecruitmentTest.Domain.Donations
{
    public class DonationClient : IDonationClient
    {
        public async Task<Donation[]> ListDonations()
        {
            return await ClientHelpers.BaseUrl
                                .AppendPathSegment("donations")
                                .GetJsonAsync<Donation[]>();
        }


    }
}