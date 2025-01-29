using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.Application.Interfaces;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;



namespace HospitalManagement.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext _context;

        public PatientService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient?> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FindAsync();
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient?> UpdatePatientAsync(int id, Patient updatePatient)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return null;

            patient.FirstName = updatePatient.FirstName;
            patient.LastName = updatePatient.LastName;
            patient.MiddleName = updatePatient.MiddleName;
            patient.BirthDate = updatePatient.BirthDate;
            patient.Gender = updatePatient.Gender;
            patient.InsurancePolicyNumber = updatePatient.InsurancePolicyNumber;
            patient.TelephoneNumber = updatePatient.TelephoneNumber;
            patient.EmailAddress = updatePatient.EmailAddress;

            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<bool> DeletePatientAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
