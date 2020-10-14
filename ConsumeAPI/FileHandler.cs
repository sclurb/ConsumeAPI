using ConsumeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsumeAPI
{
    public class FileHandler 
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Sends all the readings in an incoming list to a file for inspection...
        /// </summary>
        /// <param name="webReadings"></param>
        public void SendWebReadingsToFile(List<WebReadings> webReadings)
        {
            int count = 0;

            using System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\WebResults.txt");
            foreach (var read in webReadings.OrderBy(o => o.Date.Year)
                .ThenBy(o => o.Date.Month).ThenBy(o => o.Date.Day)
                .ThenBy(o => o.Date.Hour).ThenBy(o => o.Date.Minute))
            {
                count++;
                file.WriteLine($"{count}- {read.Id}\tTemp1 " + $"{read.Temp1}\tTemp2 {read.Temp2}\tTemp3 {read.Temp3}\tTemp4 {read.Temp4}\tHum1 {read.Hum1}\tHum2 {read.Hum2}\tHum3 {read.Hum3}\tHum4 {read.Hum4}\t{read.Date}");
            }
        }
        /// <summary>
        /// sends a list of readings from the local db to a file 
        /// </summary>
        /// <param name="readings"></param>
        public void SendLocalDbReadingsToFile(List<WebReadings> readings)
        {
            int count = 0;

            using System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Temp\LocalDbResults.txt");
            foreach (var read in readings.OrderBy(o => o.Date.Year)
                .ThenBy(o => o.Date.Month).ThenBy(o => o.Date.Day)
                .ThenBy(o => o.Date.Hour).ThenBy(o => o.Date.Minute))
            {
                count++;
                file.WriteLine($"{count}- {read.Id}\tTemp1 " + $"{read.Temp1}\tTemp2 {read.Temp2}\tTemp3 {read.Temp3}\tTemp4 {read.Temp4}\tHum1 {read.Hum1}\tHum2 {read.Hum2}\tHum3 {read.Hum3}\tHum4 {read.Hum4}\t{read.Date}");
            }
        }
    }
}
