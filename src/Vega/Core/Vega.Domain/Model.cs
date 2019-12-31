using System;
using System.Collections.Generic;
using System.Text;

namespace Vega.Domain
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public Guid MakeId { get; set; }
        public Make Make { get; set; }
    }
}
