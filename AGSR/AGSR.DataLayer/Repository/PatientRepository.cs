﻿using AGSR.DataLayer.Entities;
using AGSR.DataLayer.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace AGSR.DataLayer.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePatientAsync(Patient patient)
        {
            _dbContext.Set<Patient>().Add(patient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(Guid id)
        {
            _dbContext.Set<Patient>().Remove(await _dbContext.Set<Patient>().FindAsync(id));
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Patient> GetPatient(Guid id)
        {
            return await _dbContext.Set<Patient>().FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetPatientListAsync()
        {
            return await _dbContext.Set<Patient>().AsNoTracking().ToListAsync();
        }

        public async Task UpdatePatientAsync(Patient patient)
        {
            var updatedPatient = await _dbContext.Set<Patient>().FindAsync(patient.Name.Id);

            _dbContext.Set<Patient>().Entry(updatedPatient).State = EntityState.Modified;

            updatedPatient.Name.Family = patient.Name.Family;
            updatedPatient.Name.Use = patient.Name.Use;
            updatedPatient.Active = patient.Active;
            updatedPatient.BirthDate = patient.BirthDate;
            updatedPatient.Gender = patient.Gender;

            await _dbContext.SaveChangesAsync();
        }
    }
}
