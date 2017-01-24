using System;

namespace RaisingIt.RecruitmentTest.Domain.Campaigns
{
    public class Campaign
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Goal { get; set; }
    }
}
