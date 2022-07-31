using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjetVideotheque3.Models
{
    public class Image
    {
        public int Id { get; set; }

        
        public byte[] Contenu { get; set; }

        public string ImageUrl { get; set; }
        public bool EstImagePrincipale { get; set; }

        public int IdFilm { get; set; }
        [ForeignKey(nameof(IdFilm))]
        public virtual Film Film { get; set; }
    }
}
