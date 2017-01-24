using System;

namespace RaisingIt.RecruitmentTest.Domain.Donations
{
    public class Donation
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Campaign { get; set; }
        public string Date { get; set; }
    }
}
