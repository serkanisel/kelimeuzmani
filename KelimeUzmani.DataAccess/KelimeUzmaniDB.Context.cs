﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KelimeUzmani.DataAccess
{
    using Entity;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class KeuDBContext : DbContext
    {
        public KeuDBContext()
            : base("name=KeuDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<SampleSentence> SampleSentence { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<WordList> WordList { get; set; }
        public virtual DbSet<WordListList> WordListList { get; set; }
    }
}
