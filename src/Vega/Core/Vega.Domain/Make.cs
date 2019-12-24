using System;
using System.Collections.Generic;
using System.Text;

namespace Vega.Domain
{
    public class Make : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}
