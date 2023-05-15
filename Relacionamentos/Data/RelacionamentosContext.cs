using Microsoft.EntityFrameworkCore;
using Relacionamentos.Models;

namespace Relacionamentos.Data
{
    public class RelacionamentosContext:DbContext
    {
        public RelacionamentosContext(DbContextOptions <RelacionamentosContext> options): base (options) { }
        public DbSet<PostClass> Post { get; set; }
        public DbSet<BlogClass> Blog { get; set; }
    }
}
