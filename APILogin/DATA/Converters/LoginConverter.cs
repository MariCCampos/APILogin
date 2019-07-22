using APILogin.MODEL;
using System.Collections.Generic;
using System.Linq;
using APILogin.DATA.Converter;
using APILogin.DATA.VO;

namespace APILogin.DATA.Converters
{
    public class LoginConverter : IParser<LoginVO, Login>, IParser<Login, LoginVO>
    {
        public Login Parse(LoginVO origin)
        {
            if (origin == null) return new Login();
            return new Login
            {
                Id = origin.Id,
                Usuario = origin.Usuario,
                Senha = origin.Senha
            };
        }

        public LoginVO Parse(Login origin)
        {
            if (origin == null) return new LoginVO();
            return new LoginVO
            {
                Id = origin.Id,
                Usuario = origin.Usuario,
                Senha = origin.Senha
            };
        }

        public List<Login> ParseList(List<LoginVO> origin)
        {
            if (origin == null) return new List<Login>();
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<LoginVO> ParseList(List<Login> origin)
        {
            if (origin == null) return new List<LoginVO>();
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
