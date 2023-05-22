using Microsoft.EntityFrameworkCore;
using SoulBeastApiTest.Models;
using System.Diagnostics;
using System.Security;

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
        public DbSet<Item> Items { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SoulbeastSkill> SoulbeastSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soulbeast>()
                .HasMany(soulbeast => soulbeast.Skills)
                .WithMany(skill => skill.Soulbeasts)
                .UsingEntity<SoulbeastSkill>();
        }
    }
}
