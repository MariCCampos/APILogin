using APILogin.MODEL;
using System.Collections.Generic;
using APILogin.DATA.VO;
using APILogin.DATA.Converters;
using APILogin.REPOSITORY;


namespace APILogin.SERVICE.Implementattions
{
    public class LoginServiceImpl : ILoginService
    {
        
        private ILoginRepository _repository;

        private readonly LoginConverter _converter;

        public LoginServiceImpl(ILoginRepository repository)
        {
            _repository = repository;
            _converter = new LoginConverter();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public bool Exist(long id)
        {
            return _repository.Exist(id);
        }

        public LoginVO Consult(LoginVO login)
        {
            var loginEntity = _converter.Parse(login);
            loginEntity = _repository.Consult(loginEntity);
            if (loginEntity != null) return _converter.Parse(loginEntity);
            return null;
        }

        public LoginVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<LoginVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public LoginVO Update(LoginVO login)
        {
            var loginEntity = _converter.Parse(login);
            loginEntity = _repository.Update(loginEntity);
            return _converter.Parse(loginEntity);
        }
    }
}
