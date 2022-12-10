using System;
using System.Collections.Generic;
using System.Text;

namespace DmvAppointmentScheduler
{
    public class Customer
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Duration { get; set; }
    }

    public class CustomerList
    {
        public List<Customer> Customers { get; set; }
    }
}
