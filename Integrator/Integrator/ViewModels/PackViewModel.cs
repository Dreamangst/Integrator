using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Integrator.ViewModels
{
    public class PackViewModel
    {
        [Key]
        public long PackID { get; set; }

        [Required]
        public string nombre { get; set; }

        [DataType(DataType.MultilineText)]
        public string detalles { get; set; }

        [Required]
        public long stock { get; set; }

    }
}