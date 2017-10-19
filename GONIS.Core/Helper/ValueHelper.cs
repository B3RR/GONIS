using System;
using System.Collections.Generic;
using System.Text;

namespace GONIS.Core.Helper
{
    public class ValueHelper
    {
        public static void CheckObjectEqualNull(object obj)
            {
                if (obj != null)
                {
                    if (obj is string && String.IsNullOrWhiteSpace(obj.ToString()))
                    {
                        throw new ArgumentNullException($"String is empty");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Object is null");
                }
        }
       

    }
}
