using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace interaktivWebb.Infrastructure
{
    public class ApiClient : IApiClient
    {
        //Request / response

        private readonly HttpClient client = new HttpClient();

        public async Task<T> GetAsync<T>(string endpoint)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            try
            {
                

                using var response = await client.SendAsync(request); 

                

                if (response.IsSuccessStatusCode)
                {
                    var resJson = await response.Content.ReadAsStringAsync(); 



                    var data = JsonConvert.DeserializeObject<T>(resJson);
                    

                    return data;
                }
                
                throw new Exception("api is down at the moment");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<T>> GetAsyncList<T>(string endpoint)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            try
            {
               

                using var response = await client.SendAsync(request); 

              

                if (response.IsSuccessStatusCode)
                {
                    var resJson = await response.Content.ReadAsStringAsync(); 



                    var data = JsonConvert.DeserializeObject<List<T>>(resJson); 


                    return data;
                }

                throw new Exception("api is down at the moment");

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
