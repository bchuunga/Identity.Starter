using System.ComponentModel.DataAnnotations;

namespace Identity.Application.Contracts.Dtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool FreeTrial { get; set;}
        public bool Admin { get; set; }
    }
}
