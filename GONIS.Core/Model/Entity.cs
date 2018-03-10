using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string WhoCreated { get; set; }
        public DateTime WhenCreated { get; set; }
        public string WhoUpdated { get; set; }
        public DateTime? WhenUpdated { get; set; }
        public bool IsDel { get; set; }
    }

}
