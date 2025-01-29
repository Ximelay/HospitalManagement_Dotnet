using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public DateTime LastVisitDate { get; set; }
        public DateTime? NextVisitDate { get; set; }

        public int MedicalCardId { get; set; }
        public MedicalCard MedicalCard { get; set; }

        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}
