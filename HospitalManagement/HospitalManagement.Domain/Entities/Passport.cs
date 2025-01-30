using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class Passport
    {
        public int Id { get; set; }
        public string SeriesNumber { get; set; } = string.Empty;
        public DateTime IssueDate { get; set; }

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
