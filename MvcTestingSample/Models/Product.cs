using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTestingSample.Models
{
    public class Product
    {
        private string productName;

        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName
        {
            get => productName;
            set
            {   // QA&R can refactor this into a single lamba expression
                // however I want to save how it is manually constructed
                if (value == null)
                {
                    throw new ArgumentNullException($"{nameof(productName)} cannot be null, sorry Mr. Null...");
                }
                productName = value;
            }
        }

        public string ProductPrice { get; set; }
    }
}
