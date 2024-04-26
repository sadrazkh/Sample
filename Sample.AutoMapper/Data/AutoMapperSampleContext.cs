using System.Data;
using System.Reflection.Emit;
using System.Reflection;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Sample.AutoMapper.Entities;

namespace Sample.AutoMapper.Data;
public class AutoMapperSampleContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public AutoMapperSampleContext(DbContextOptions options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        //modelBuilder.AddSoftDelete<BaseEntity>(entitiesAssembly);
    }

}


