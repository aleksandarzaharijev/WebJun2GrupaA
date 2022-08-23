using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Template.Models
{   
    [Table("Vozilo")]
    public class Vozilo
    {
        [Key]
        public int VoziloID{get;set;}

        [Required]
        public string Naziv {get;set;}

        public TipPrevoza Prevoz {get;set;}

        public List<Dostava> VoziloDostava {get;set;}
        
    }
}