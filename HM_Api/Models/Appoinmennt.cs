using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_Api.Models
{
    public class Appoinmennt
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public string CNIC { get; set; }

        public string Phone { get; set; }

        public  string Date { get; set; }

        public int DrId { get; set; }
    }
}