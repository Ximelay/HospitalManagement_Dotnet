using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class AddressType
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
