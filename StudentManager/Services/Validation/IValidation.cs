using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Services.Validation
{
    public interface IValidation<T>
    {
        (bool,string) Validate(T data);
    }
}
