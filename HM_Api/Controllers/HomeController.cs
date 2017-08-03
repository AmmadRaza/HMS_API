using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HM_Api.Models;


namespace HM_Api.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/{HM_API}/PatientRegister")]
        public bool PatientRegister(PatientRegister PR)
        {
           
            using(HMS_APIEntities hms = new HMS_APIEntities())
            {
                hms.PatientRegisters.Add(PR);
                hms.SaveChanges();
                int id = PR.PatientId;
            }
            return true;
        }


        [HttpGet]
        [Route("api/{HM_API}/HireDocter")]
        public bool HireDocter(Doctor HR)
        {

            return true;
        }

        [HttpGet]
        [Route("api/{HM_API}/Pannel")]
        public bool Pannel(PatientRegister PR)
        {

            return true;
        }

        [HttpGet]
        [Route("api/{HM_API}/Appoinment")]
        public bool Appoinment(PatientRegister PR)
        {

            return true;
        }


        [HttpGet]
        [Route("api/{HM_API}/Billing")]
        public bool Billing()
        {

            return true;
        }
    }
}
