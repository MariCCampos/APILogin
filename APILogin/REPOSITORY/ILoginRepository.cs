using APILogin.DATA.VO;
using APILogin.MODEL;
using System.Collections.Generic;

namespace APILogin.REPOSITORY
{
    public interface ILoginRepository
    {
        Login Consult(Login login);
        Login FindById(long id);
        List<Login> FindAll();
        Login Update(Login login);
        void Delete(long id);
        bool Exist(long? id);
    }
}
