using APILogin.MODEL;

namespace APILogin.SERVICE.Implementattions
{
    public class LoginServiceImpl : ILoginService
    {
        private readonly MySQLContext _context;
        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }
        public Login Find(Login login)
        {
            return _context.Login.Any(u => u.User.Equals(user));
            //return login;
            //fazer lógica do FIND(Post) aqui
        }
    }
}
