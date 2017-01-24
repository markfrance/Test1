using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using RaisingIt.RecruitmentTest.Domain.Campaigns;
using RaisingIt.RecruitmentTest.Web.Controllers;

namespace RaisingIt.RecruitmentTest.Tests.Unit.Web.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _homeController;
        private Mock<ICampaignClient> _campaignClientMock;

        [SetUp]
        public void Setup()
        {
            _campaignClientMock = new Mock<ICampaignClient>();
            _homeController = new HomeController(_campaignClientMock.Object);
        }

        [Test]
        public async Task should_return_expected_view_model()
        {
            // given
            var expectedCampaigns = new[] { new Campaign() };
            _campaignClientMock
                .Setup(x => x.ListCampaigns())
                .ReturnsAsync(expectedCampaigns);

            // when
            var result = await _homeController.Index() as ViewResult;

            // then
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Model as Campaign[], Is.EqualTo(expectedCampaigns));
        }
    }
}