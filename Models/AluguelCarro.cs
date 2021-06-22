using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autentication.Models
{
    public class AluguelCarro
    {
        [Key]
        public int ID { get; set; }

        public string NomedoCarro { get; set; }

        public string Valor { get; set; }
    }
}
