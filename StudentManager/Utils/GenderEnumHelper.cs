using StudentManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Utils
{
    public static class GenderEnumHelper
    {
        public static Array Values => Enum.GetValues(typeof(Gender));

    }
}
