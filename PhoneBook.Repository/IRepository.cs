using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneBook.Data.Models;

namespace PhoneBook.Repository
{
    public interface IRepository
    {
        bool AddEntryToPhoneBook(string name, string phoneNumber);
        List<PhoneBookModel> GetPhoneBook();
    }
}
