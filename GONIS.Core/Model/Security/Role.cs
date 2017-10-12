using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Model.Security
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<RolesUsers> RolesUsers { get; set; }


    }
}
