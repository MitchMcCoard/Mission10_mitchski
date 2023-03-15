using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission10_mitchski.Models
{
    public class Transaction
    {
        [Key]
        [BindNever]
        public int TransactionID { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> LineItems { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter an address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLinee3 { get; set; }

        [Required(ErrorMessage ="Please enter a City")]
        public string City { get; set; }

        [Required(ErrorMessage ="Please enter a  state")]
        public string State { get; set; }

        [Required(ErrorMessage ="Please enter a zip code")]
        public int Zip { get; set; }

        [Required(ErrorMessage ="Please enter a country")]
        public string Country { get; set; }
    }
}
