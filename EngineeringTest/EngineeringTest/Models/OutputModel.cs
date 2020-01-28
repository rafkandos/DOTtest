using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineeringTest.Models
{
    public class OutputModel
    {
    }

    public class paramName
    {
        public string province { get; set; }
    }

    public class query
    {
        public string id { get; set; }
        public string key { get; set; }
    }

    public class status
    {
        public int code { get; set; }

        public string description { get; set; }
    }

    public class OutputProvince
    {
        public object Province { get; set; }
    }

    public class ResultProvince
    {
        public object query { get; set; }
        public object status { get; set; }
        public object result { get; set; }
    }

    public class OutputCity
    {
        public object City { get; set; }
    }

    public class ResultCity
    {
        public object query { get; set; }
        public object status { get; set; }
        public object result { get; set; }
    }

    public class ResultAPI
    {
        public object rajaongkir { get; set; }
    }

    public class ResultAnying
    {
        //public object query { get; set; }
        //public object status { get; set; }
        public object result { get; set; }
    }
}
