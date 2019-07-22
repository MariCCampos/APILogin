using APILogin.MODEL;
using APILogin.MODEL.CONTEXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILogin.REPOSITORY
{
    public class LoginRepositoryImpl : ILoginRepository
    {
        private readonly MySQLContext _context;

        public LoginRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Login Consult(Login login)
        {
            
            var result = _context.Login.SingleOrDefault(b => b.Usuario == login.Usuario && b.Senha == login.Senha);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public void Delete(long id)
        {
            var result = _context.Login.SingleOrDefault(u => u.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Login.Remove(result);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Login> FindAll()
        {
            return _context.Login.ToList();
        }

        public Login FindById(long id)
        {
            return _context.Login.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Login Update(Login login)
        {
            if (!Exist(login.Id)) return null;

            var result = _context.Login.SingleOrDefault(b => b.Id == login.Id);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(login);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public bool Exist(long? id)
        {
            return _context.Login.Any(p => p.Id.Equals(id));
        }

    }
}
