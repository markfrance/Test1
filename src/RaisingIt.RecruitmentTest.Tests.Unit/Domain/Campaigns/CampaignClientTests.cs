using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpectedObjects;
using Flurl;
using Flurl.Http.Testing;
using NUnit.Framework;
using RaisingIt.RecruitmentTest.Domain;
using RaisingIt.RecruitmentTest.Domain.Campaigns;

namespace RaisingIt.RecruitmentTest.Tests.Unit.Domain.Campaigns
{
    [TestFixture]
    public class CampaignClientTests
    {
        private HttpTest _httpTest;

        [SetUp]
        public void Setup()
        {
            _httpTest = new HttpTest();
        }

        [TearDown]
        public void TearDown()
        {
            _httpTest.Dispose();
        }

        [Test]
        public async Task should_call_expected_url()
        {
            // given
            _httpTest.RespondWithJson(new List<Campaign>());
            var client = new CampaignClient();

            // when
            await client.ListCampaigns();

            // then
            _httpTest.ShouldHaveCalled(ClientHelpers.BaseUrl.AppendPathSegment("campaigns"));
        }

        [Test]
        public async Task should_return_expected_data()
        {
            // given
            var expectedResult = new[]
            {
                new Campaign
                {
                    Description = "test-desc",
                    Goal = 324234,
                    Guid = Guid.NewGuid(),
                    Name = "some-name"
                }
            };

            _httpTest.RespondWithJson(expectedResult);
            var client = new CampaignClient();

            // when
            Campaign[] result = await client.ListCampaigns();

            // then
            result.ToExpectedObject().ShouldEqual(expectedResult);
        }
    }
}