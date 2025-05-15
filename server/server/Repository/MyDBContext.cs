using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Contracts;
using server.Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Repository
{
    public class MyDBContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Pasture> Pastures { get; set; }
        public DbSet<Crop> SeedCrops { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<WorkOnFields> WorkOnFields { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Equipment> MachineryEquipment { get; set; }
        public DbSet<EquipmentOnFields> EquipmentOnFields { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<RepairLog> RepairLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CropConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new FieldConfiguration());
            modelBuilder.ApplyConfiguration(new PastureConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentConfiguration());
            modelBuilder.ApplyConfiguration(new RepairLogConfiguration());
            modelBuilder.ApplyConfiguration(new WorkOnFieldsConfiguration());
            modelBuilder.ApplyConfiguration(new EquipmentOnFieldsConfiguration());
        }
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
        }
    }
}