using System;
using System.Collections.Generic;

namespace ConsumeAPI.Domain
{
    public class Stuff
    {
        public int Id { get; set; }
        public double Temp1 { get; set; }
        public double Temp2 { get; set; }
        public double Temp3 { get; set; }
        public double Temp4 { get; set; }
        public double Hum1 { get; set; }
        public double Hum2 { get; set; }
        public double Hum3 { get; set; }
        public double Hum4 { get; set; }
        public DateTime Date { get; set; }
        //public ICollection<Stuff> Stuffs { get; set; }
    }
}
