using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ITHoot.Models
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext()
        {
        }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options):base(options)
        {
        }

        public DbSet<ProgrammerModel> Programmers { get; set; }

        public DbSet<CompanyModel> Companies { get; set; }

        public DbSet<ProjectModel> Projects { get; set; }

        public DbSet<ProgrammersAndProjects> ProgrammersAndProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammerModel>()
                .HasKey(x => x.IdProgrammer);
            modelBuilder.Entity<ProjectModel>()
                .HasKey(x => x.IdProject);

            modelBuilder.Entity<ProgrammersAndProjects>()
                .HasKey(x => new { x.IdProgrammer, x.IdProject });
            modelBuilder.Entity<ProgrammersAndProjects>()
                .HasOne(x => x.ProgrammersModel)
                .WithMany(m => m.ProjectsModel)
                .HasForeignKey(x => x.IdProgrammer);
            modelBuilder.Entity<ProgrammersAndProjects>()
                .HasOne(x => x.ProjectsModel)
                .WithMany(e => e.ProgrammersModel)
                .HasForeignKey(x => x.IdProject);
        }
    }

}
