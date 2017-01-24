using System;

namespace RaisingIt.RecruitmentTest.Domain.Donations
{
    public class Donation
    {
        public Guid Campaign { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public string Message { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
