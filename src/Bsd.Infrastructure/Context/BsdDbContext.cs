﻿using Bsd.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Bsd.Infrastructure.Context
{
    public class BsdDbContext : DbContext
    {
#pragma warning disable CS8618
        public BsdDbContext(DbContextOptions<BsdDbContext> options) : base(options) { }
        public DbSet<BsdEntity> BsdEntities { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Rubric> Rubrics { get; set; }
        public DbSet<EmployeeRubric> EmployeeRubrics { get; set; }

#pragma warning restore CS8618

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}