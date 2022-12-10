using System;
using System.Collections.Generic;
using System.Text;

namespace DmvAppointmentScheduler
{
    public class Appointment
    {
        public Customer customer { get; set; }
        public Teller teller { get; set; }
        public double duration { get; set; }
        public Appointment(Customer customer, Teller teller)
        {
            this.customer = customer;
            this.teller = teller;
            if (customer.Type == teller.SpecialtyType)
            {
                this.duration = Math.Ceiling(Convert.ToDouble(customer.Duration) * Convert.ToDouble(teller.Multiplier));
            }
            else
            {
                this.duration = Convert.ToDouble(customer.Duration);
            }

            teller.MinutesWorked += duration;
        }
    }
}
