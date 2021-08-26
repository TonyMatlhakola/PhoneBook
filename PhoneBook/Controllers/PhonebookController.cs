using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Data.Models;
using PhoneBook.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebookController : ControllerBase
    {
        #region Private Fields
        private readonly IRepository _repository;


        #endregion

        #region Constructor

        public PhonebookController(IRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods

        
        [HttpGet]
        public IActionResult GetPhoneBook()
        {
            var phonebookEntries = _repository.GetPhoneBook();
            if (phonebookEntries.Any()) return Ok(phonebookEntries);
            return NotFound(phonebookEntries);
        }

        [HttpPost]
        public IActionResult AddEntryToPhoneBook(PhoneBookEntry phoneBookEntry)
        {
            var isEntryAdded = _repository.AddEntryToPhoneBook(phoneBookEntry);

            if (isEntryAdded) return Ok();

            return NotFound();
        }

        #endregion
    }
}