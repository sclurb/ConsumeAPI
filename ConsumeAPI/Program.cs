using ConsumeAPI.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsumeAPI
{
    class Program
    {



        public static int counter = 0;
        public static List<WebReadings> readings = new List<WebReadings>();
        static async Task Main(string[] args)
        {
            
            FileHandler fileHandler = new FileHandler();

            // await ApiAccess.PostOneRowToWebServer(reads); // send it to the web server

            //for (int i = 205599; i < 206863; i++)
            //{
            //    await ApiAccess.DeleteOneRowById(i);
            //}

            DbAccess access = new DbAccess();

            var dates = new DateRange()
            {
                From = new DateTime(2020, 10, 06, 11, 15, 00),
                To = new DateTime(2020, 10, 15)
            };

            List<WebReadings> result2 = new List<WebReadings>();
            var result1 = access.GetReadingsByDateRangeFromLocalDb(dates);

            foreach (var row in result1)
            {
                WebReadings line = new WebReadings()
                {
                    Id = row.Id,
                    Hum1 = Convert.ToDecimal(row.Hum1),
                    Hum2 = Convert.ToDecimal(row.Hum2),
                    Hum3 = Convert.ToDecimal(row.Hum3),
                    Hum4 = Convert.ToDecimal(row.Hum4),
                    Temp1 = Convert.ToDecimal(row.Temp1),
                    Temp2 = Convert.ToDecimal(row.Temp2),
                    Temp3 = Convert.ToDecimal(row.Temp3),
                    Temp4 = Convert.ToDecimal(row.Temp4),
                    Date = row.Date
                };
                result2.Add(line);

            }

            fileHandler.SendLocalDbReadingsToFile(result2);
            var result3 = result2.FirstOrDefault();
            ReadingWithDate read1 = new ReadingWithDate()
            {
                Temp1 = result3.Temp1,
                Temp2 = result3.Temp2,
                Temp3 = result3.Temp3,
                Temp4 = result3.Temp4,
                Hum1 = result3.Hum1,
                Hum2 = result3.Hum2,
                Hum3 = result3.Hum3,
                Hum4 = result3.Hum4,
                Date = result3.Date
            };

            //await ApiAccess.PostReadingWithDateToWebServer(read1); // send it to the web server
            foreach (var line in result2)
            {
                ReadingWithDate read = new ReadingWithDate()
                {
                    Temp1 = line.Temp1,
                    Temp2 = line.Temp2,
                    Temp3 = line.Temp3,
                    Temp4 = line.Temp4,
                    Hum1 = line.Hum1,
                    Hum2 = line.Hum2,
                    Hum3 = line.Hum3,
                    Hum4 = line.Hum4,
                    Date = line.Date
                };
                await ApiAccess.PostReadingWithDateToWebServer(read); // send it to the web server
            }
            var dateRange = new DateRange()
            {
                From = new DateTime(2020, 10, 05),
                To = new DateTime(2020, 10, 15)
            };
            var result = await ApiAccess.GetDataFromWebServerWithDateRange(dateRange);
            
            fileHandler.SendWebReadingsToFile(result);



            Console.WriteLine("It did it.");

            Console.ReadKey();

  
        }

 

 


 
    }


}
