using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class HospitalizationReason
    {
        public int Id { get; set; }
        public string ReasonName { get; set; } = string.Empty;

        public ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();
    }
}
