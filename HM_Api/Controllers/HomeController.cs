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
        public bool AddDocter(Doctor DR)
        {
            using (HMS_APIEntities hms = new HMS_APIEntities())
            {
                hms.Doctors.Add(DR);
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
                int id = DR.Id;
                if (ModelState.IsValid)
                {
                    DR.Id = id;
                    hms.Entry(DR).State = EntityState.Modified;
                    hms.SaveChanges();
                    
                }
                
            }
        }

        [HttpGet]
        [Route("api/{HM_API}/DeleteDoctor")]
        // here we can delet patient record
        public bool DeleteDoctor(Doctor DR)
        {

            using (HMS_APIEntities hms = new HMS_APIEntities())
            {
                Doctor DeleteDoctor = (from d in hms.Doctors
                                                 where d.Id == DR.Id
                                                 select d).FirstOrDefault();
                hms.Doctors.Remove(DeleteDoctor);
                hms.SaveChanges();
            }
            return true;
        }

        public bool GenerateSalary(decimal hoursWorkedTextBox, decimal hourlyPayRateTextBox )
        {
            try
            {
                // Named constants 
                decimal BASE_HOURS = 40m;
                decimal OVERTIME_RATE = 1.5m;
 
                // Local variables 
                decimal hoursWorked;     
                decimal hourlyPayRate;    
                decimal basePay;          
                decimal overtimeHours;
                decimal overtimePay;       
                decimal grossPay;        
 
                // Get the hours worked and hourly pay rate. 
                hoursWorked = (hoursWorkedTextBox);
                hourlyPayRate =(hourlyPayRateTextBox);
 
                // Determine the gross pay. 
                if (hoursWorked > BASE_HOURS)
                {
                    // Calculate the base pay (without overtime). 
                    basePay = hourlyPayRate * BASE_HOURS;
 
                    // Calculate the number of overtime hours. 
                    overtimeHours = hoursWorked - BASE_HOURS;
 
                    // Calculate the overtime pay. 
                    overtimePay = overtimeHours * hourlyPayRate * OVERTIME_RATE;
 
                    // Calculate the gross pay. 
                    grossPay = basePay + overtimePay;
                }
                else
                {
                    // Calculate the gross pay. 
                    grossPay = hoursWorked * hourlyPayRate;
                }
 
            }
            catch (Exception ex)
            {
               
            }
              return true;
        }
        
        public string GetAllDoctorSalries(int did)
        {
            using (HMS_APIEntities db = new HMS_APIEntities())
            {
                string output = "";

               
                var list = db.Doctors.Single(s => s.Id == did);

                if (list.Salary == null)
                {
                    output = "--";
                }
                else
                {
                    output = String.Format("{0:0.##}", list.Salary);
                }
                return output;
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
        public bool Appoinment(PatientRegister SearchModel)
        {
            using (HMS_APIEntities hms = new HMS_APIEntities())
            {
                // i put business logic in a (PatientRegister.cs) for sorting by Id,Name,Phone 
                var business = new ProductBusinessLogic();
                var model = business.PatientRegister(SearchModel);
                
            }
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
