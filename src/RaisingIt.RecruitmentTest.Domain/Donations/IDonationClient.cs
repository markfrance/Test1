using System.Threading.Tasks;

namespace RaisingIt.RecruitmentTest.Domain.Donations
{
    public interface IDonationClient
    {
        Task<Donation[]> ListDonations();
    }
}