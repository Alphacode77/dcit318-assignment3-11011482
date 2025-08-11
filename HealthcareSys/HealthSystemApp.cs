using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystem
{
    public class HealthSystemApp
    {
        // Fields
        private Repository<Patient> _patientRepo;
        private Repository<Prescription> _prescriptionRepo;
        private Dictionary<int, List<Prescription>> _prescriptionMap;

        // Constructor
        public HealthSystemApp()
        {
            _patientRepo = new Repository<Patient>();
            _prescriptionRepo = new Repository<Prescription>();
            _prescriptionMap = new Dictionary<int, List<Prescription>>();
        }

        public void SeedData()
        {
            _patientRepo.Add(new Patient(1, "John Doe", 35, "Male"));
            _patientRepo.Add(new Patient(2, "Jane Smith", 28, "Female"));
            _patientRepo.Add(new Patient(3, "Michael Johnson", 42, "Male"));

            _prescriptionRepo.Add(new Prescription(1, 1, "Aspirin", DateTime.Now.AddDays(-30)));
            _prescriptionRepo.Add(new Prescription(2, 1, "Ibuprofen", DateTime.Now.AddDays(-15)));
            _prescriptionRepo.Add(new Prescription(3, 2, "Amoxicillin", DateTime.Now.AddDays(-20)));
            _prescriptionRepo.Add(new Prescription(4, 2, "Vitamin D", DateTime.Now.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(5, 3, "Metformin", DateTime.Now.AddDays(-5)));
        }

        public void BuildPrescriptionMap()
        {
            _prescriptionMap.Clear();
            var allPrescriptions = _prescriptionRepo.GetAll();
            foreach (var prescription in allPrescriptions)
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }
                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
        }

        public bool AddPatient(int id, string name, int age, string gender, out string error)
        {
            error = string.Empty;
            var existing = _patientRepo.GetById(p => p.Id == id);
            if (existing != null)
            {
                error = $"Patient with ID {id} already exists.";
                return false;
            }
            _patientRepo.Add(new Patient(id, name, age, gender));
            return true;
        }

        public bool AddPrescription(int prescriptionId, int patientId, string medicationName, DateTime dateIssued, out string error)
        {
            error = string.Empty;
            var patient = _patientRepo.GetById(p => p.Id == patientId);
            if (patient == null)
            {
                error = $"Patient with ID {patientId} not found.";
                return false;
            }
            var existing = _prescriptionRepo.GetById(pr => pr.Id == prescriptionId);
            if (existing != null)
            {
                error = $"Prescription with ID {prescriptionId} already exists.";
                return false;
            }
            var prescription = new Prescription(prescriptionId, patientId, medicationName, dateIssued);
            _prescriptionRepo.Add(prescription);
            if (!_prescriptionMap.ContainsKey(patientId))
            {
                _prescriptionMap[patientId] = new List<Prescription>();
            }
            _prescriptionMap[patientId].Add(prescription);
            return true;
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepo.GetAll();
        }

        public List<Prescription> GetPrescriptionsByPatientId(int patientId)
        {
            if (_prescriptionMap.ContainsKey(patientId))
            {
                return new List<Prescription>(_prescriptionMap[patientId]);
            }
            return new List<Prescription>();
        }

        public List<Prescription> GetPrescriptionsForPatient(int patientId)
        {
            return GetPrescriptionsByPatientId(patientId);
        }
    }
}

