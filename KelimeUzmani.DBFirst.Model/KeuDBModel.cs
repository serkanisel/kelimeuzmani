namespace KelimeUzmani.DBFirst.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KeuDBModel : DbContext
    {
        public KeuDBModel()
            : base("name=KeuModel")
        {
        }

        public virtual DbSet<SampleSentence> SampleSentence { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Word> Word { get; set; }
        public virtual DbSet<WordList> WordList { get; set; }
        public virtual DbSet<WordListList> WordListList { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SampleSentence>()
                .Property(e => e.Sentence)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Word>()
                .Property(e => e.WordBody)
                .IsUnicode(false);

            modelBuilder.Entity<Word>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.SampleSentence)
                .WithRequired(e => e.Word)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Word>()
                .HasMany(e => e.WordListList)
                .WithRequired(e => e.Word)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WordList>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<WordList>()
                .HasMany(e => e.WordListList)
                .WithRequired(e => e.WordList)
                .WillCascadeOnDelete(false);
        }
    }
}
