using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeAPI.Domain
{

    /// <summary>
    /// Represents the data structure when a HTTPClient PostAync with ToDate and FromeDate
    /// are used to get data from the webserver via a web api
    /// </summary>
    public class WebReadings
    {
        public int Id { get; set; }
        public decimal Temp1 { get; set; }
        public decimal Temp2 { get; set; }
        public decimal Temp3 { get; set; }
        public decimal Temp4 { get; set; }
        public decimal Hum1 { get; set; }
        public decimal Hum2 { get; set; }
        public decimal Hum3 { get; set; }
        public decimal Hum4 { get; set; }
        public DateTime Date { get; set; }
   
    }
}
