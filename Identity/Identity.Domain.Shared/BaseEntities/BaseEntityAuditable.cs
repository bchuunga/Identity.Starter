namespace Identity.Domain.Shared.BaseEntities
{
    public class BaseEntityAuditable
    {
        public string CreatedById { get; set; }
        public DateTime Created { get; set; }
    }
}
