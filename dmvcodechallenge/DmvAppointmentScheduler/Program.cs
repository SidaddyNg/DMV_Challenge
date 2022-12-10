using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DmvAppointmentScheduler
{
    class Program
    {
        public static Random random = new Random();
        public static List<Appointment> appointmentList = new List<Appointment>();

        static void Main(string[] args)
        {
            List<Customer> customers = ReadCustomerData().Customers;
            List<Teller> tellers = ReadTellerData().Tellers;
            Calculation(customers, tellers);
            OutputTotalLengthToConsole();

        }

        private static CustomerList ReadCustomerData()
        {
            string fileName = "CustomerData.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"InputData\", fileName);
            string jsonString = File.ReadAllText(path);
            CustomerList customerData = JsonConvert.DeserializeObject<CustomerList>(jsonString);
            return customerData;

        }

        private static TellerList ReadTellerData()
        {
            string fileName = "TellerData.json";
            string path = Path.Combine(Environment.CurrentDirectory, @"InputData\", fileName);
            string jsonString = File.ReadAllText(path);
            TellerList tellerData = JsonConvert.DeserializeObject<TellerList>(jsonString);
            return tellerData;

        }

        // Your code goes here .....
        // Re-write this method to be more efficient instead of a assigning all customers to the same teller
        static void Calculation(List<Customer> customers, List<Teller> tellers)
        {
            foreach (Customer customer in customers)
            {
                var appointment = new Appointment(customer, tellers[0]);
                appointmentList.Add(appointment);
            }
        }

        static void OutputTotalLengthToConsole()
        {
            var tellerAppointments =
                from appointment in appointmentList
                group appointment by appointment.teller into tellerGroup
                select new
                {
                    teller = tellerGroup.Key,
                    totalDuration = tellerGroup.Sum(x => x.duration),
                };
            var max = tellerAppointments.OrderBy(i => i.totalDuration).LastOrDefault();
            Console.WriteLine($"Number of Appointments: {appointmentList.Count}");
            Console.WriteLine("Teller " + max.teller.Id + " will work for " + max.totalDuration + " minutes!");
        }

    }
}
