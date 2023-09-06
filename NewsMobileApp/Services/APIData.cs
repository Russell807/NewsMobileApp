using NewsMobileApp.MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsMobileApp.Services
{
    public static class APIData
    {
        public static async Task<Root> GetNews()
        {
            var httpClient = new HttpClient();
           var jsonData = await httpClient.GetStringAsync("https://gnews.io/api/v4/top-headlines?category=general&apikey=086839f056fa5c00260c81d20cc15a3c&topic=breaking-newa&lang=en");
            var result = JsonConvert.DeserializeObject<Root>(jsonData);
            return result;
        }
    }
}
