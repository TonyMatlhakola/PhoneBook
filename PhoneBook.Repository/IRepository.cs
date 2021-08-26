using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Data.Models;

namespace PhoneBook.Repository
{
    public interface IRepository
    {
        bool AddEntryToPhoneBook(PhoneBookEntry pohBookEntry);
        List<PhoneBookModel> GetPhoneBook();
    }
}
