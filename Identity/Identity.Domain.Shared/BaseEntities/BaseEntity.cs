﻿namespace Identity.Domain.Shared.BaseEntities
{
    public class BaseEntity
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
    }
}
