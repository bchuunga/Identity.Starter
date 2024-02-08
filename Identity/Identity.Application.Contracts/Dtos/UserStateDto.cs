namespace Identity.Application.Contracts.Dtos
{
    public class UserStateDto
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
    }
}
