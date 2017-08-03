using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_Api.Models
{
    public class PatientRegister
    {
        public int PatientId { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public int CNIC { get; set; }
    }
}