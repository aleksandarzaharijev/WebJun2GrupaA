using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Template.Models
{   
    [Table("TipPrevoza")]
    public class TipPrevoza
    {
        [Key]
        public int TipID{get;set;}

        [Required]
        public string Naziv {get;set;}
        
    }
}