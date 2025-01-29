﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Domain.Entities
{
    public class Workplace
    {
        public int Id { get; set; }
        public string WorkplaceName { get; set; } = string.Empty;

        public ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
