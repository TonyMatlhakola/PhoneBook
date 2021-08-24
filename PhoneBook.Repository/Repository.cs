using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PhoneBook.Data;
using PhoneBook.Data.Models;
using PhoneBook.Data.Options;

namespace PhoneBook.Repository
{
    public class Repository : IRepository
    {
        #region Constructor

        public Repository(ILogger<Repository> logger,
            IOptions<PhoneBookOptions> options, PhoneBookContext phoneBookContext)
        {
            _logger = logger;
           _options = options;
           _phoneBookContext = phoneBookContext;
        }

        #endregion

        #region Private Fields


        private readonly ILogger<Repository> _logger;
        private readonly IOptions<PhoneBookOptions> _options;
        private readonly PhoneBookContext _phoneBookContext;

        #endregion


        #region Methods

        public bool AddEntryToPhoneBook(string name, string phoneNumber)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(phoneNumber))
                {
                    var phoneBook = _phoneBookContext.Phonebook.Find(1); //Assuming only one Phonebook exists
                    _phoneBookContext.PhonebookEntry.Add(new PhoneBookEntry
                    {
                                Name = name,
                                PhoneNumber = phoneNumber,
                                PhoneBook = phoneBook
                    });
                }

                _phoneBookContext.SaveChanges();
                _logger.LogError($"{nameof(AddEntryToPhoneBook)}: New Phonebook and Entry has been added..");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

            return true;

        }

        public List<PhoneBookModel> GetPhoneBook()
        {
            var phoneBook = new List<PhoneBookModel>();
            try
            {
                phoneBook = _phoneBookContext.Phonebook.Include(x => x.ContactsDetails).ToList();
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return phoneBook;
        }

        #endregion
    }
}