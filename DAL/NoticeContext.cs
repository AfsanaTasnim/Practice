using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Practice.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Practice.DAL
{
    public class NoticeContext : DbContext
    {
        public NoticeContext() : base("NoticeContext")
        {
        }

        public DbSet<Notice> Notices { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Phy> Physics { get; set; }

        public DbSet<AllTheTeacher> AllTheTeachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}