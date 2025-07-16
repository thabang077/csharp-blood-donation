using Microsoft.EntityFrameworkCore;

namespace ReactWebApiBloodType.Model
{
    public class DonationDBContext : DbContext
    { public DonationDBContext(DbContextOptions<DonationDBContext> options) : base(options)
        {


        }

        public DbSet<DonationCandidate> DonationCandidates { get; set; }

    }
}
