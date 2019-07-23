using APILogin.DATA;
using APILogin.DATA.VO;
using APILogin.MODEL;
using System.Collections.Generic;

namespace APILogin.SERVICE.Implementattions
{
    public interface ILoginService
    {
        LoginVO Consult(LoginVO login);
        LoginVO Create(LoginVO login);
        List<LoginVO> FindAll();
        LoginVO Update(LoginVO login);
        void Delete(long id);
    }
}
