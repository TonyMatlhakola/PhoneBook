using Microsoft.EntityFrameworkCore;
using PhoneBook.Data.Models;

namespace PhoneBook.Data
{
    public class PhoneBookContext: DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {

        }
        public DbSet<PhoneBookModel> Phonebook { get; set; }
        public DbSet<PhoneBookEntry> PhonebookEntry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PhoneBookModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            
            });

            modelBuilder.Entity<PhoneBookEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PhoneNumber);
                entity.HasOne(d => d.PhoneBook)
                    .WithMany(p => p.ContactsDetails);
            });
 


        }



    }
}
