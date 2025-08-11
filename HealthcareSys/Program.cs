using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthcareSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var healthSystem = new HealthSystemApp();
            healthSystem.BuildPrescriptionMap();

            while (true)
            {
                Console.WriteLine("Healthcare System Management");
                Console.WriteLine("1. Add patient");
                Console.WriteLine("2. List all patients");
                Console.WriteLine("3. Add prescription for a patient");
                Console.WriteLine("4. View prescriptions for a patient");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");
                var input = Console.ReadLine();
                Console.WriteLine();

                if (input == "1")
                {
                    Console.Write("Enter patient ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("Invalid ID.\n"); continue; }
                    Console.Write("Enter full name: ");
                    var name = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter age: ");
                    if (!int.TryParse(Console.ReadLine(), out int age)) { Console.WriteLine("Invalid age.\n"); continue; }
                    Console.Write("Enter gender: ");
                    var gender = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(gender)) { Console.WriteLine("Name and gender are required.\n"); continue; }
                    if (healthSystem.AddPatient(id, name.Trim(), age, gender.Trim(), out string error))
                        Console.WriteLine("Patient added successfully.\n");
                    else
                        Console.WriteLine(error + "\n");
                }
                else if (input == "2")
                {
                    var patients = healthSystem.GetAllPatients();
                    if (patients.Count == 0) Console.WriteLine("No patients found.\n");
                    else
                    {
                        Console.WriteLine("All Patients:");
                        foreach (var patient in patients) Console.WriteLine(patient.ToString());
                        Console.WriteLine();
                    }
                }
                else if (input == "3")
                {
                    Console.Write("Enter prescription ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int prescriptionId)) { Console.WriteLine("Invalid prescription ID.\n"); continue; }
                    Console.Write("Enter patient ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int patientId)) { Console.WriteLine("Invalid patient ID.\n"); continue; }
                    Console.Write("Enter medication name: ");
                    var med = Console.ReadLine() ?? string.Empty;
                    Console.Write("Enter date issued (yyyy-MM-dd), leave empty for today: ");
                    var dateStr = Console.ReadLine();
                    DateTime dateIssued = DateTime.Today;
                    if (!string.IsNullOrWhiteSpace(dateStr) && !DateTime.TryParse(dateStr, out dateIssued))
                    {
                        Console.WriteLine("Invalid date format.\n");
                        continue;
                    }
                    if (string.IsNullOrWhiteSpace(med)) { Console.WriteLine("Medication name is required.\n"); continue; }
                    if (healthSystem.AddPrescription(prescriptionId, patientId, med.Trim(), dateIssued, out string error))
                        Console.WriteLine("Prescription added successfully.\n");
                    else
                        Console.WriteLine(error + "\n");
                }
                else if (input == "4")
                {
                    Console.Write("Enter patient ID: ");
                    if (!int.TryParse(Console.ReadLine(), out int patientId)) { Console.WriteLine("Invalid patient ID.\n"); continue; }
                    var patients = healthSystem.GetAllPatients();
                    var patient = patients.FirstOrDefault(p => p.Id == patientId);
                    if (patient == null) { Console.WriteLine($"Patient with ID {patientId} not found.\n"); continue; }
                    Console.WriteLine($"Prescriptions for {patient.Name} (ID: {patientId}):");
                    var prescriptions = healthSystem.GetPrescriptionsForPatient(patientId);
                    if (prescriptions.Count == 0) Console.WriteLine("No prescriptions found for this patient.\n");
                    else { foreach (var pr in prescriptions) Console.WriteLine(pr.ToString()); Console.WriteLine(); }
                }
                else if (input == "5")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.\n");
                }
            }
        }
    }
}
