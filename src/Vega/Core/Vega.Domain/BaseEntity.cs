using System;

namespace Vega.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
