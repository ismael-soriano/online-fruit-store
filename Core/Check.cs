using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Check
    {
        public static void NotNull(object argument, string argumentName)
        {
            if (null == argument)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
