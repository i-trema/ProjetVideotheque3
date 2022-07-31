using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetVideotheque3.Models
{
    public class ApiResponseModel
    {
        [NotMapped]
        public string expression { get; set; }

        [NotMapped]
        public List<ImdbFilm> results { get; set; }
    }
}
