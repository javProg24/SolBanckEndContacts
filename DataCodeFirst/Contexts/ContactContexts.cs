using DataCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCodeFirst.Contexts
{
    public class ContactContexts:DbContext
    {
        public DbSet<Contact> Contacts {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI;Database=firstcodeContact;User ID=sa;password=SQL123;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e=>e.ID);
                entity.ToTable("Contact");
                entity.Property(e => e.Nombre).HasMaxLength(255).IsRequired();
                entity.Property(e=>e.Apellido).HasMaxLength(255).IsRequired();
                entity.Property(e=>e.Numero).IsRequired();
                entity.Property(e=>e.Estado).IsRequired();
            });
             /*OnModelCreatingPartial(modelBuilder);*/
            base.OnModelCreating(modelBuilder);
        }
        /*partial void OnModelCreatingPartial(ModelBuilder modelBuilder);*/
    }
}
