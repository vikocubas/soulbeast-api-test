using Microsoft.EntityFrameworkCore;
using SoulBeastApiTest.Models;

namespace SoulBeastApiTest.Data
{
    public class DataContext : DbContext
    {
        //Adicionando o contexto do banco de dados
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {  
        }

        //Mostra para o Dbcontext a onde estão as tabelas
        public DbSet<Soulbeast> Soulbeasts { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Medal> Medals { get; set; }
    }
}
