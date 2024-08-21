using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DoctorManagementSystem
{
    class Program
    {

        public class Doctor
        {
            public string RegistrationNo { get; set; }
            public string DoctorName { get; set; }
            public string ContactNo { get; set; }
            public string ClinicTimings { get; set; }
            public string City { get; set; }
            public string Specialization { get; set; }
            public string ClinicAddress { get; set; }
       
            

            public bool IsValidRegistrationNo()
            {
                return Regex.IsMatch(RegistrationNo, @"^\d{7}$");
            }

            public bool IsValidDoctorName()
            {
                return Regex.IsMatch(DoctorName, @"^[a-zA-Z\s]+$");
            }
            public bool IsValidContactNo()
            {
                return Regex.IsMatch(ContactNo, @"^\d{10}$");
            }
            public bool IsValidSpecialization()
            {
                return Regex.IsMatch(Specialization, @"^[a-zA-Z\s]+$");
            }

            public override string ToString()
            {
                return $"Registration No: {RegistrationNo}, Name: {DoctorName}, Contact No: {ContactNo}, Timings: {ClinicTimings}, City: {City}, Specialization: {Specialization}, Address: {ClinicAddress}";
            }
        }

        public static void Main(string[] args)
        {
            List<Doctor> doctors = new List<Doctor>();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Doctor Management System");
                Console.WriteLine("1. Add Doctor Information");
                Console.WriteLine("2. Display Doctors List");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddDoctor(doctors);
                        break;
                    case "2":
                        DisplayDoctors(doctors);
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, Please try again.");
                        break;
                }
            }
        }

        static void AddDoctor(List<Doctor> doctors)
        {
            Console.Clear();
            Doctor doctor = new Doctor();

            // Get Registration No and it should accept 7 digits
            Console.Write("Enter Registration No (7 digits): ");
            doctor.RegistrationNo = Console.ReadLine();
            while (!doctor.IsValidRegistrationNo())
            {
                Console.WriteLine("Registration No has Invalid. It should accept 7 digits only.");
                Console.Write("Please Enter Registration No: ");
                doctor.RegistrationNo = Console.ReadLine();
            }

            // Get Doctor Name and It should accept Alphabets
            Console.Write("Enter Doctor Name: ");
            doctor.DoctorName = Console.ReadLine();
            while (!doctor.IsValidDoctorName())
            {
                Console.WriteLine("Doctor Name has Invalid. It should accept alphabets only.");
                Console.Write("please Enter the Doctor Name: ");
                doctor.DoctorName = Console.ReadLine();
            }

            // Get City
            Console.Write("Enter City: ");
            doctor.City = Console.ReadLine();

            // Get Contact No and validation for accepting 10 digits
            Console.Write("Enter Contact No (10 digits): ");
            doctor.ContactNo = Console.ReadLine();
            while (!doctor.IsValidContactNo())
            {
                Console.WriteLine("Invalid Contact No. It should accept 10 digits only.");
                Console.Write("Please Enter Contact No: ");
                doctor.ContactNo = Console.ReadLine();
            }


            // Get Clinic Timings
            Console.Write("Enter Clinic Timings: ");
            doctor.ClinicTimings = Console.ReadLine();


            // Get Area of Specialization and validation of accepting the alphabets
            Console.Write("Please Enter Area of Specialization: ");
            doctor.Specialization = Console.ReadLine();
            while (!doctor.IsValidSpecialization())
            {
                Console.WriteLine("Invalid Area of Specialization. It should accept alphabets only.");
                Console.Write("Please Enter the Area of Specialization: ");
                doctor.Specialization = Console.ReadLine();
            }

            // Get Clinic Address
            Console.Write("Enter Clinic Address: ");
            doctor.ClinicAddress = Console.ReadLine();
            
            
            doctors.Add(doctor);
            Console.WriteLine("Doctor record added successfully. Press Enter to continue.");
            Console.ReadLine();
        }

        static void DisplayDoctors(List<Doctor> doctors)
        {
            Console.Clear();
            Console.WriteLine("Doctor List:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor);
            }
            Console.WriteLine("Press Enter to return to the Main Menu.");
            Console.ReadLine();
        }
    }

}