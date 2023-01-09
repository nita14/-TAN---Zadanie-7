using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse
{
    public class ProductWarehouse
    {


        [Required(ErrorMessage = "IdProduct is required")]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "IdWarehouse is required")]
        public int IdWarehouse { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "CreatedAt is required")]
        public string CreatedAt { get; set; }

    }
}
