using System;
using System.Collections.Generic;
using System.Text;

namespace DmvAppointmentScheduler
{
    public class Teller
    {
        public string Id { get; set; }
        public string SpecialtyType { get; set; }
        public string Multiplier { get; set; }
        public double MinutesWorked { get; set; } = 0;
    }

    public class TellerList
    {
        public List<Teller> Tellers { get; set; }
    }
}
