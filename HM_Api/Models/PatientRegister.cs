using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HM_Api.Models
{
    public class PatientRegister
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public int CNIC { get; set; }

        public DateTime Date { get; set; }
    }

    public class ProductBusinessLogic
    {
        public HMS_APIEntities Context;
        public PatientRegister()
        {
            Context = new HMS_APIEntities();
        }

        public IQueryable<PatientRegister> GetPAtient(PatientRegister SearchModel)
        {
            var result = Context.PatientRegisters.AsQueryable();
            if (SearchModel != null)
            {
                if (SearchModel.Id.HasValue)
                    result = result.Where(x => x.PatientId == SearchModel.Id);
                if (!string.IsNullOrEmpty(SearchModel.Name))
                    result = result.Where(x => x.Name.Contains(SearchModel.Name));
               
                if (!string.IsNullOrEmpty(SearchModel.Phone))
                    result = result.Where(x => x.Phone == SearchModel.Phone);
            }
            return result;
        }
    }
}