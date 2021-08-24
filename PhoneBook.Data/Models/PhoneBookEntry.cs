using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Data.Models
{
    public class PhoneBookEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", Order = 1)]
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public string PhoneNumber { get; set; }
      
        public virtual PhoneBookModel PhoneBook { get; set; }

    }
}
