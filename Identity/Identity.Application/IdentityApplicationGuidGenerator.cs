namespace Identity.Application
{
    public static class IdentityApplicationGuidGenerator
    {
        public static string Generate = Guid.NewGuid().ToString();
    }
}
