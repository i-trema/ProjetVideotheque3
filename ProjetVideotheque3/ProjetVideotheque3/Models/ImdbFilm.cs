using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetVideotheque3.Models
{
    public class ImdbFilm
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Titre { get; set; }

        [JsonProperty("image")]
        public string ImageUrl { get; set; }

        [JsonProperty("linkEmbed")]
        public string LienTrailer { get; set; }

        [JsonProperty("plotLocal")]
        public string Synopsis { get; set; }

        [JsonProperty("runtimeMins")]
        public int DureeMins { get; set; }
        [JsonProperty("imDBRating")]
        public double IMDbNote { get; set; }



    }
}
