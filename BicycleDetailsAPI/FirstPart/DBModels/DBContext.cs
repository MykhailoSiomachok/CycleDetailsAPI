using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LowerLayer
{
    public class DBContext : DbContext 
    {
        public DbSet<BicycleDetail> Details { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=ec2-54-74-77-126.eu-west-1.compute.amazonaws.com;Port=5432;Database=d641s8codj57bn;User Id=rhmjlukeflujpe;Password=bcbb2db71329689b8d269f0e108452652dcbb18680a4df3b5bcd32fd247dbf73;SSL Mode=Require;TrustServerCertificate=True");
        }
    }
}
