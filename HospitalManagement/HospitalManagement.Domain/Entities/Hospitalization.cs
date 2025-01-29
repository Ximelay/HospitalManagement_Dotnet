using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class Hospitalization
    {
        public int Id { get; set; }
        public DateTime HospitalizationDate { get; set; }
        public string? ConditionDescription { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int HospitalizationReasonId { get; set; }
        public HospitalizationReason HospitalizationReason { get; set; }
    }
}
