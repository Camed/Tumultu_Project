using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumultu.Application.Common.Models;

public class CreateUserResult
{
    public Result? Result { get; set; }
    public Guid Guid { get; set; }
}
