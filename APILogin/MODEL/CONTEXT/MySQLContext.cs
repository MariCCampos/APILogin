using Microsoft.EntityFrameworkCore;

namespace APILogin.MODEL.CONTEXT
{
    public MySQLContext()
    {

    }

    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

    public DbSet<Login>  { get; set; }
}
