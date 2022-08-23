using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Models
{   
    [Table("Kompanija")]
    public class Kompanija
    { 
        [Key]
        public int KompanijaID {get;set;}

        [Required]
        public string Naziv {get;set;}
        
        public int Prihod {get;set;}

        public int BrojAngazovanja {get;set;}
        public List<Dostava> Dostave {get;set;}
        
    }
}