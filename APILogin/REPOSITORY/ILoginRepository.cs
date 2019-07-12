using APILogin.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILogin.REPOSITORY
{
    interface ILoginRepository
    {
        Login Find(Login login );
    }
}
