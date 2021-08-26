using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneBook.Data;
using PhoneBook.Data.Models;

namespace PhoneBook.Repository
{
    public class Repository : IRepository
    {
        #region Constructor

        public Repository(ILogger<Repository> logger,
            PhoneBookContext phoneBookContext)
        {
            _logger = logger;
            _phoneBookContext = phoneBookContext;
        }

        #endregion

        #region Private Fields


        private readonly ILogger<Repository> _logger;
        private readonly PhoneBookContext _phoneBookContext;

        #endregion


        #region Methods

        public bool AddEntryToPhoneBook(PhoneBookEntry phoneBookEntry)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(phoneBookEntry.PhoneNumber))
                {
                    var phoneBook = _phoneBookContext.Phonebook.Find(1); //Assuming only one Phonebook exists
                 var r=   _phoneBookContext.PhonebookEntry.Add(new PhoneBookEntry
                    {
                                Name = phoneBookEntry.Name,
                                PhoneNumber = phoneBookEntry.PhoneNumber,
                                PhoneBook = phoneBook
                    });
                 if (r.Entity.PhoneNumber == phoneBookEntry.PhoneNumber)
                 {
                     return true;
                 }
                }

                _phoneBookContext.SaveChanges();
                _logger.LogError($"{nameof(AddEntryToPhoneBook)}: New Entry has been added..");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }

            return false;

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