using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmachy
{
    interface IUserService
    {
        bool checkUserAuthentication(User user);
    }
}
