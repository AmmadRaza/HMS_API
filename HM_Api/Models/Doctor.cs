using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_Api.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CNIC { get; set; }

        public double Salary { get; set; }
    }
}