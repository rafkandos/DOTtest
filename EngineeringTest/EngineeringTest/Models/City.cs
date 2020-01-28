using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EngineeringTest.Models;

namespace EngineeringTest.Models
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int city_id { get; set; }

        public string type { get; set; }

        public string city_name { get; set; }

        public string postal_code { get; set; }

        public int province_id { get; set; }

        [ForeignKey("province_id")]
        public virtual Province Province { get; set; }
    }

    public class Cities
    {
        public int city_id { get; set; }

        public string type { get; set; }

        public string city_name { get; set; }

        public string postal_code { get; set; }

        public int province_id { get; set; }

        public string province { get; set; }
    }
}
