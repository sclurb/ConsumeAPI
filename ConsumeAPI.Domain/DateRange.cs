using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeAPI.Domain
{
    /// <summary>
    /// This is used to send in an api to request 
    /// a range of rows based on their date
    /// </summary>
    public class DateRange
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
