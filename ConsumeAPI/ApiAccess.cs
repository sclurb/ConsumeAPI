using ConsumeAPI.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeAPI
{
    public static class ApiAccess
    {
        private static string apiGetUrl = "https://phtresources.com/api/chart/";
        private static string apiPostUrl = "https://phtresources.com/api/readings/";
        /// <summary>
        /// Post one row to web server.   Will not include the date field.   
        /// That means it will be inserted automaticall with a DateTimeNow
        /// </summary>
        /// <param name="tempHums"></param>
        /// <returns></returns>
        public static async Task PostOneRowToWebServer(Readings tempHums)
        {
            var json = JsonConvert.SerializeObject(tempHums);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(apiPostUrl, data);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("The readings were accepted by the server");
            }
            else
            {
                Console.WriteLine($"Was not able to post the reading at: {DateTime.Now}");
            }
            
        }
        /// <summary>
        /// Posts one row to the web server with an actual date from the local databse.
        /// </summary>
        /// <param name="tempHums"></param>
        /// <returns></returns>
        public static async Task PostReadingWithDateToWebServer(ReadingWithDate tempHums)
        {
            Program.counter++;
            var json = JsonConvert.SerializeObject(tempHums);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(apiPostUrl, data);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{Program.counter}: Accepted by server with  {response.StatusCode}");
            }
            else
            {
                Console.WriteLine($"Was not able to post the reading at: {DateTime.Now}");
            }

        }
        /// <summary>
        /// deletes a row from the web server database when I screw up and put a bad row in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task DeleteOneRowById(int id)
        {
            Program.counter++;
            string url = "https://phtresources.com/api/chart/" + id.ToString() + "/";
            var client = new HttpClient();
            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"{Program.counter} Delete was successful: {response.StatusCode}");
            }
            else
            {
                Console.WriteLine($"Delete failed because {response.StatusCode}");
            }
        }
        /// <summary>
        /// fetches a list of rows from the webserver database by date range
        /// </summary>
        /// <param name="dates"></param>
        /// <returns></returns>
        public static async Task<List<WebReadings>> GetDataFromWebServerWithDateRange(DateRange dates)
        {
            var json = JsonConvert.SerializeObject(dates);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var response = await client.PostAsync(apiGetUrl, data);
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //Program.readings = JsonConvert.DeserializeObject<List<WebReadings>>(responseBody);
            return JsonConvert.DeserializeObject<List<WebReadings>>(responseBody);
        }/// <summary>
        /// I ian't got this to work just yet   future...
        /// </summary>
        /// <returns></returns>
        public static async Task GetDataWithAuthentication()
        {
            var authCredential = Encoding.UTF8.GetBytes("{sclurb@outlook.com}:{Chainsxxx}");
            //var authCredential = Encoding.UTF8.GetBytes("The big round ball was blue");
            using (var client = new HttpClient())
            {


                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authCredential));
                client.BaseAddress = new Uri(apiGetUrl);
                HttpResponseMessage response = await client.GetAsync(apiGetUrl);

                if (response.IsSuccessStatusCode)
                {
                    var readTask = response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var rawResponse = readTask.GetAwaiter().GetResult();
                    Console.WriteLine(rawResponse);
                }
                Console.WriteLine("Complete");
                Console.ReadKey();
            }
        }

    }
}
