using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Model.Security
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string FIO { get; set; }
        public IEnumerable<RolesUsers> RolesUsers { get; set; }

    }
}
