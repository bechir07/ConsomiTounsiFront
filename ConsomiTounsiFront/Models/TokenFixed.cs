using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ConsomiTounsiFront.Models
{
    public static class TokenFixed
    {

          public static string token= "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJyb290IiwiZXhwIjoxNjE5NTc2ODUwLCJpYXQiOjE2MTk1NTg4NTAsImF1dGhvcml0aWVzIjpbIkRlbGl2ZXJ5TWVuIl19.MdSkLv7XNL4Z7NFu_C7Qir0eAOExZnjgwPe14ReQ2RsUloB17bV--SmVbb3Tkq6FHr8PoI9rTh3j_fCuXt3O4w";
          public static User GetUser()
        {
            HttpClient httpClient;
            httpClient = new System.Net.Http.HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", String.Format("Bearer {0}", token));
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            var response = httpClient.GetAsync("http://localhost:8082/ConsomiTounsi/Delivery/GetLoggedUser").Result;
            if (response.IsSuccessStatusCode)
            {
              return  response.Content.ReadAsAsync<User>().Result;
            }
            else
            {
                return null;
            }
        }
            }
}