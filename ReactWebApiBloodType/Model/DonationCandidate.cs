using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactWebApiBloodType.Model
{
    public class DonationCandidate
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string FullName { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        public int Age { get; set; }

        [Column(TypeName = "nvarchar(4)")]
        public string BloodGroup { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }
        
    }
}
