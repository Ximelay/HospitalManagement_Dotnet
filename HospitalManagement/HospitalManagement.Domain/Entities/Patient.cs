using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string InsurancePolicyNumber { get; set; } = string.Empty;
        public string TelephoneNumber { get; set; } = string.Empty;
        public string? EmailAddress { get; set; }

        // Убедись, что здесь только ID рабочего места
        public int WorkplaceId { get; set; }  // Связь с Workplace по ID
        public Workplace? Workplace { get; set; }  // Навигационное свойство

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
        public MedicalCard? MedicalCard { get; set; }
        public Passport? Passport { get; set; }
        public ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();
    }
}
