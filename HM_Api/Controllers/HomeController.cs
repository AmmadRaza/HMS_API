using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HM_Api.Models;
using System.Data.Entity;


namespace HM_Api.Controllers
{
    public class HomeController : ApiController
    {
        [HttpGet]
        [Route("api/{HM_API}/PatientRegister")]
        //here we can register patient
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
        [Route("api/{HM_API}/UpdatePatient")]
        // here we can update patient what i register in above method
        public bool UpdatePatient(PatientRegister PR)
        {

            using (HMS_APIEntities hms = new HMS_APIEntities())
            {
                PatientRegister UpdatedPatient = (from p in hms.PatientRegisters
                                            where p.PatientId == PR.PatientId
                                            select p).FirstOrDefault();
                UpdatedPatient.Name = PR.Name;
                UpdatedPatient.Phone = PR.Phone;
                UpdatedPatient.CNIC = PR.CNIC;
                hms.SaveChanges();
            }
            return true;
        }


        [HttpGet]
        [Route("api/{HM_API}/UpdatePatient")]
        // here we can delet patient record
        public bool DeletePatient(PatientRegister PR)
        {

            using (HMS_APIEntities hms = new HMS_APIEntities())
            {
                PatientRegister DeletePatient = (from c in hms.PatientRegisters
                                     where c.PatientId == PR.PatientId
                                     select c).FirstOrDefault();
                hms.PatientRegisters.Remove(DeletePatient);
                hms.SaveChanges();
            }
            return true;
        }



        [HttpGet]
        [Route("api/{HM_API}/AddDocter")]
        // here we can add doctors
        public bool AddDocter(AddDoctor DR)
        {
            using (HMS_APIEntities hms = new HMS_APIEntities())
            {
                hms.AddDoctors.Add(DR);
                hms.SaveChanges();
                
            }
            return true;
        }




        [HttpGet]
        [Route("api/{HM_API}/UpdateDoctor")]
        public void UpdateDoctor(Doctor DR)
        {
            using (HMS_APIEntities hms = new HMS_APIEntities())
            {
                if (ModelState.IsValid)
                {
                    DR.Id = 1;
                    hms.Entry(DR).State = EntityState.Modified;
                    hms.SaveChanges();
                    
                }
                
            }
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
