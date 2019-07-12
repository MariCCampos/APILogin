using APILogin.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILogin.SERVICE.Implementattions
{
    public interface ILoginService
    {
        Login Find(Login login);
    }
}
