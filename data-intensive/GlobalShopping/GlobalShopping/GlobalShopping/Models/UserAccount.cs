using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GlobalShopping.Models
{
    public class UserAccount
    {
        public int? ID { get; set; }
        [DisplayName("First name")]
        public required string FirstName { get; set; }
        [DisplayName("Last name")]
        public required string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("DOB")]
        public DateTime DateOfBirth { get; set; }
        public bool Active { get; set; } = true;
    }
}
