namespace Identity.Application.Contracts.Dtos
{
    public class UserClaims
    {
        public string UserName { get; set; }
        public object Claims { get; set; }
    }
}
