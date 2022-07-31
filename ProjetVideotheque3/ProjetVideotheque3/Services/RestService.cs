using Newtonsoft.Json;
using ProjetVideotheque3.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjetVideotheque3.Services
{
    public class RestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<List<ImdbFilm>> GetFilmsAsync(string uri)
        {

            
            List<ImdbFilm> films = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    
                    string content = await response.Content.ReadAsStringAsync();

                    var model = JsonConvert.DeserializeObject<ApiResponseModel>(content);
                    
                    films = model.results;
;                   
                    
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return films;
        }

        public async Task<ImdbFilm> GetFilmAsync(string uri)
        {
            ImdbFilm film = null;

            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    film = JsonConvert.DeserializeObject<ImdbFilm>(content);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return film;
        }
    }
}
