using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetVideotheque3.Models
{
    public class LienFilmPersonne
    {
        public int IdFilm { get; set; }
        public int IdPersonne { get; set; }
        public Role Role { get; set; }
    }
}
