using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetVideotheque3.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Synopsis { get; set; }
        public DateTime DateSortie { get; set; }
        public int Duree { get; set; }
        public string LienBandeAnnonce { get; set; }
        public int Note { get; set; }
        public double IMDbNote { get; set; }

        public string Affiche { get; set; }

        [InverseProperty(nameof(Image.Film))]
        public virtual ICollection<Image> Images { get; set; }








    }
}
