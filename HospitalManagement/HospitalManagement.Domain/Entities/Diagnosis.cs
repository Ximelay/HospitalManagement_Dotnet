using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();
    }
}
