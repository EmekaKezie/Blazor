using Blazor.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Data
{
    public class UserData
    {
        public static async Task<User> Login(Login model)
        {
            User data = null;

            try
            {
                HttpClient client = new HttpClient();

                model = new Login
                {
                    username = model.username?.Trim(),
                    password = model.password
                };

                string json = JsonConvert.SerializeObject(model);
                var headers = new StringContent(json, Encoding.UTF8, "application/json");
                var uri = "http://localhost:8082/Tests/phpapi_test/Api/Login";
                HttpResponseMessage httpResponse = await client.PostAsync(uri, headers);

                //var requestURI = new Uri(String.Format("http://localhost:8082/Tests/phpapi_test/Api/GetUsers"));
                //HttpResponseMessage httpResponse = await client.GetAsync(requestURI);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<User>(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return data;
        }


        public static async Task<List<User>> GetUsers()
        {
            List<User> data = null;
            try
            {
                HttpClient httpClient = new HttpClient();
                var requestURI = new Uri(String.Format("http://localhost:8082/Tests/phpapi_test/Api/GetUsers"));
                HttpResponseMessage httpResponse = await httpClient.GetAsync(requestURI);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    data = new List<User>();
                    data = JsonConvert.DeserializeObject<List<User>>(result);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }


        public static async Task<User> GetUser(string id)
        {
            User data = null;
            try
            {
                HttpClient httpClient = new HttpClient();
                var requestURI = new Uri(String.Format("http://localhost:8082/Tests/phpapi_test/Api/GetUser?id={0}", id));
                HttpResponseMessage httpResponse = await httpClient.GetAsync(requestURI);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<User>(result);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return data;
        }



        public static async Task<bool> CreateUser(UserCreate model)
        {
            bool ret = false;

            try
            {
                model = new UserCreate
                {
                    firstname = model.firstname?.Trim(),
                    surname = model.surname?.Trim(),
                    username = model.username?.Trim(),
                    password = model.password?.Trim()
                };

                HttpClient httpClient = new HttpClient();

                string json = JsonConvert.SerializeObject(model);
                var headers = new StringContent(json, Encoding.UTF8, "application/json");
                var uri = "http://localhost:8082/Tests/phpapi_test/Api/CreateAccount";
                HttpResponseMessage httpResponse = await httpClient.PostAsync(uri, headers);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    //data = new List<User>();
                    //data = JsonConvert.DeserializeObject<List<User>>(result);
                    ret = true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ret;
        }
    }
}
