using System;
using Newtonsoft.Json;
using weatherApp.Models;

namespace weatherApp.Services
{
	public static class ApiServices

	{
        // Function to get the weather based on the coordinator
        public static async Task<Root> GetWeather(double latitude, double longitude)
		{

			var httpClient = new HttpClient();

            // Send a GET request to the Url and return the response 
            var res = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=b59fa67e534c859f2b3d52bf83da5295", latitude, longitude));

            //  Converting the JSON data into .NET object.
            return JsonConvert.DeserializeObject<Root>(res);
		}
    }
}

