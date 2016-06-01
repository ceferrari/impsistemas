﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TrabalhoPO.Models;

namespace TrabalhoPO.DAL
{
    public class MyContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public MyContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrabalhoPO;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}