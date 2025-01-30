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
    public class MedicalCardService : IMedicalCardService
    {
        private readonly HospitalDbContext _context;

        public MedicalCardService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MedicalCard>> GetAllMedicalCardsAsync()
        {
            return await _context.MedicalCards.Include(m => m.Patient).ToListAsync();
        }

        public async Task<MedicalCard?> GetMedicalCardByIdAsync(int id)
        {
            return await _context.MedicalCards.Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<MedicalCard> CreateMedicalCardAsync(MedicalCard medicalCard)
        {
            _context.MedicalCards.Add(medicalCard);
            await _context.SaveChangesAsync();
            return medicalCard;
        }

        public async Task<MedicalCard?> UpdateMedicalCardAsync(int id, MedicalCard updatedMedicalCard)
        {
            var medicalCard = await _context.MedicalCards.FindAsync(id);
            if (medicalCard == null) return null;

            medicalCard.IssueDate = updatedMedicalCard.IssueDate;
            medicalCard.PatientId = updatedMedicalCard.PatientId;

            await _context.SaveChangesAsync();
            return medicalCard;
        }

        public async Task<bool> DeleteMedicalCardAsync(int id)
        {
            var medicalCard = await _context.MedicalCards.FindAsync(id);
            if (medicalCard == null) return false;

            _context.MedicalCards.Remove(medicalCard);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
