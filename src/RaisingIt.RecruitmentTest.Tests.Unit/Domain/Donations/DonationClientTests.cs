using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpectedObjects;
using Flurl;
using Flurl.Http.Testing;
using NUnit.Framework;
using RaisingIt.RecruitmentTest.Domain;
using RaisingIt.RecruitmentTest.Domain.Donations;

namespace RaisingIt.RecruitmentTest.Tests.Unit.Domain.Donations
{
    [TestFixture]
    public class DonationClientTests
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
            _httpTest.RespondWithJson(new List<Donation>());
            var client = new DonationClient();

            // when
            await client.ListDonations();

            // then
            _httpTest.ShouldHaveCalled(ClientHelpers.BaseUrl.AppendPathSegment("donation"));
        }

        [Test]
        public async Task should_return_expected_data()
        {
            // given
            var expectedResult = new[]
            {
                new Donation
                {
                    Campaign = "test-desc",
                    Date = "24/01/2017",
                    Guid = Guid.NewGuid(),
                    Name = "some-name"
                }
            };

            _httpTest.RespondWithJson(expectedResult);
            var client = new DonationClient();

            // when
            Donation[] result = await client.ListDonations();

            // then
            result.ToExpectedObject().ShouldEqual(expectedResult);
        }
    }
}