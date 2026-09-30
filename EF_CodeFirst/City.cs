using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Capital { get; set; }
        [Range(0, 3000)]
        public int? Year { get; set; }
        public long? Population { get; set; }
        [MaxLength(200)]        
        public string Location { get; set; }

    }
}
