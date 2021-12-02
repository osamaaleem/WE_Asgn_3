using System.ComponentModel.DataAnnotations;

namespace WE_Asgn_3.Models
{
    public class OprSys
    {
        [Required]
        [Display(Name = "Operating System")]
        public string Name { get; set; }
    }
}