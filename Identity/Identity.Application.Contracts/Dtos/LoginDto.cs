using System.ComponentModel.DataAnnotations;

namespace Identity.Application.Contracts.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
