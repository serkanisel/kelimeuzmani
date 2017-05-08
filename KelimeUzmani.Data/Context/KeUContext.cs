using KelimeUzmani.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelimeUzmani.Data
{
    public class KeuContext:DbContext 
    {
        public KeuContext()
            :base("KeuContext")
        { }

        public DbSet<User> User { get; set; }
        public DbSet<SampleSentence> SampleSentence { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<WordList> WordList { get; set; }
        public DbSet<WordListWords> WordListWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //ilişkleri kuruyoruz. one-to-many olarak 
            //modelBuilder.Entity<WordList>()
            //    .HasRequired<User>(x => x.User)
            //    .WithMany(x => x.WordLists)
            //    .HasForeignKey(x => x.UserID);

            //modelBuilder.Entity<WordListWords>()
            //    .HasRequired<Word>(x => x.Word)
            //    .WithMany(x => x.WordListWords)
            //    .HasForeignKey(x => x.WordID);

            //modelBuilder.Entity<WordListWords>()
            //    .HasRequired<WordList>(x => x.WordList)
            //    .WithMany(x => x.WordListWords)
            //    .HasForeignKey(x => x.WordListID);


            base.OnModelCreating(modelBuilder);
        }
    }
}
