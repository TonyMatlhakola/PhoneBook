using PhoneBook.Data.Models;

namespace PhoneBook.Data
{
    public static class InitializePhonebookContext
    {
        public static void Initialize(PhoneBookContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var phonebook = new PhoneBookModel
            {
                Name = "Kamo's Phonebook",
                ContactsDetails = new[]
                {
                    new PhoneBookEntry
                    {
                        Name = "Tom", PhoneNumber = "0735555432"
                    },
                    new PhoneBookEntry
                    {
                        Name = "Andre", PhoneNumber = "0785449867"
                    },
                    new PhoneBookEntry
                    {
                        Name = "Craig", PhoneNumber = "0795609807"
                    },
                    new PhoneBookEntry
                    {
                        Name = "Marvin", PhoneNumber = "0601321221"
                    },
                    new PhoneBookEntry
                    {
                        Name = "Zakes", PhoneNumber = "0610764523"
                    },
                    new PhoneBookEntry
                    {
                        Name = "Jack", PhoneNumber = "0653459656"
                    }
                }
            };

            context.Phonebook.Add(phonebook);
            context.SaveChanges();
        }
    }
}