using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressType { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public int AddressTypeId { get; set; }
        public AddressType? AddressTypeEntity { get; set; }
    }
}
