using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Models
{   
    [Table("Dostava")]
    public class Dostava
    {
        [Key]
        public int DostavaID{get;set;}

        public int ZapreminaPaketa {get;set;}
        public int TezinaPaketa{get;set;}
        public int Cena{get;set;}
        public DateTime DatumPrijema{get;set;}
        public DateTime DatumDostave{get;set;}
        public Kompanija KompanijaSpoj{get;set;}
        public Vozilo VoziloSpoj{get;set;}

        
    }
}