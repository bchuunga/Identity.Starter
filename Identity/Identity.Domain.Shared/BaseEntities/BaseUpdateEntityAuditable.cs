namespace Identity.Domain.Shared.BaseEntities
{
    public class BaseUpdateEntityAuditable : BaseEntityAuditable
    {
        public string ModifiedById { get; set; }
        public DateTime Modified { get; set; }
    }
}
