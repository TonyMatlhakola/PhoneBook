using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Data.Models
{
    public class PhoneBookModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("Id", Order = 1)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<PhoneBookEntry> ContactsDetails { get; set; }
    }
}
