using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using PhoneBook.Data;
using PhoneBook.Data.Models;
using PhoneBook.Repository;
using Xunit;

namespace PhoneBook.Tests
{
    public class RepositoryTests
    {
        #region Private Fields

        private readonly IRepository _repository;

        #endregion

        #region Constructor

        public RepositoryTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhoneBookContext>();
            optionsBuilder.UseSqlServer("SqlServer");
            var logger = NullLogger<Repository.Repository>.Instance;
            var phoneBookContext = new PhoneBookContext(optionsBuilder.Options);

            _repository = new Repository.Repository(logger, phoneBookContext);
        }

        #endregion

        [Fact]
        public void When_GetPhoneBook_Expect_PhoneBook_With_List_Of_Entries()
        {
            var phonebookWithListEntries = _repository.GetPhoneBook();

            Assert.True(phonebookWithListEntries.Any());
        }


        [Fact]
        public void When_AddEntryToPhoneBook_Expect_Entry_Added_In_Database()
        {
            var entries = new PhoneBookEntry
            {
                Name = "TestName",
                PhoneNumber = "0766782345"
            };

            var entrieResponse = _repository.AddEntryToPhoneBook(entries);
            Assert.True(entrieResponse);

        }
    }
}