﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkTask.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GuestBookEntities : DbContext
    {
        public GuestBookEntities()
            : base("name=GuestBookEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Masha> Mashas { get; set; }
        public DbSet<Rec> Recs { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<student> students { get; set; }
        public DbSet<Table1> Table1 { get; set; }
        public DbSet<university> universities { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
