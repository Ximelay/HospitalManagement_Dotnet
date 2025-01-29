using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class MedicalProcedure
    {
        public int Id { get; set; }
        public DateTime ProcedureDate { get; set; }
        public string? ProcedureName { get; set; }
        public string? Results { get; set; }
        public string? Recommendations { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int MedicalHistoryId { get; set; }
        public MedicalHistory MedicalHistory { get; set; }

        public int ProcedureTypeId { get; set; }
        public ProcedureType ProcedureType { get; set; }
    }
}
