﻿using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RaisingIt.RecruitmentTest.Domain.Donations;

namespace RaisingIt.RecruitmentTest.Tests.Integration.Domain.Donations
{
    [TestFixture]
    public class DonationClientTests
    {
        [Test]
        public async Task should_return_some_data_from_api()
        {
            // given
            var client = new DonationClient();

            // when
            Donation[] result = await client.ListDonations();

            // then
            Assert.That(result, Is.Not.Empty);

            foreach (var donation in result)
            {
                Assert.That(donation.Campaign, Is.Not.EqualTo(Guid.Empty));
                Assert.That(donation.Name, Is.Not.Null.Or.Empty);
                Assert.That(donation.Message, Is.Not.Null.Or.Empty);
                Assert.That(donation.Amount, Is.EqualTo(0));
                Assert.That(donation.TimeStamp, Is.Not.Null.Or.Empty);
            }
        }
    }
}