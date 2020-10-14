using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeAPI.Domain
{
    /// <summary>
    /// Represents the data structure for the IoT device.
    /// This data object lives in the database on the 
    /// webserver PHTResources.com.   It is used to send
    /// data via an HTTPClient PostAync
    /// The Id is missing since the dabase on the webserver will auto increment.
    /// The DateTime is also missing since the webserver will add a DateTime.Now.AddHours(3)
    /// </summary>
    public class Readings
    {
        public decimal Temp1 { get; set; }
        public decimal Temp2 { get; set; }
        public decimal Temp3 { get; set; }
        public decimal Temp4 { get; set; }
        public decimal Hum1 { get; set; }
        public decimal Hum2 { get; set; }
        public decimal Hum3 { get; set; }
        public decimal Hum4 { get; set; }

    }
}
