using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class MedicalCard
    {
        public int Id { get; set; }
        public DateTime IssueDate { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
    }
}
