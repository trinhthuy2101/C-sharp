using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ASP_NET_MVC.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .Property(e => e.C_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.dep)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Students)
                .WithOptional(e => e.Class1)
                .HasForeignKey(e => e._class);

            modelBuilder.Entity<Department>()
                .Property(e => e.D_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.uni)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Classes)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.dep);

            modelBuilder.Entity<Student>()
                .Property(e => e.S_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.gender)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e._class)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.dep)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<University>()
                .Property(e => e.U_id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<University>()
                .HasMany(e => e.Departments)
                .WithOptional(e => e.University)
                .HasForeignKey(e => e.uni);
        }
    }
}
