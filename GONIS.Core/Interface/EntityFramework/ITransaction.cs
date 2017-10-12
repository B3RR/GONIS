using System;
using System.Collections.Generic;
using System.Text;
using GONIS.Core.Model;

namespace GONIS.Core.Interface.EntityFramework
{
    public interface ITransaction
    {
        void Commit();
    }
}
