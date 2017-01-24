using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RaisingIt.RecruitmentTest.Domain.Campaigns;

namespace RaisingIt.RecruitmentTest.Tests.Integration.Domain.Campaigns
{
    [TestFixture]
    public class CampaignClientTests
    {
        [Test]
        public async Task should_return_some_data_from_api()
        {
            // given
            var client = new CampaignClient();

            // when
            Campaign[] result = await client.ListCampaigns();

            // then
            Assert.That(result, Is.Not.Empty);

            foreach (var campaign in result)
            {
                Assert.That(campaign.Guid, Is.Not.EqualTo(Guid.Empty));
                Assert.That(campaign.Name, Is.Not.Null.Or.Empty);
                Assert.That(campaign.Description, Is.Not.Null.Or.Empty);
                Assert.That(campaign.Goal, Is.GreaterThan(0));
            }
        }
    }
}