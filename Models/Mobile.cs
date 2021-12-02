using System;
using System.ComponentModel.DataAnnotations;
using WE_Asgn_3.CustomValidation;

namespace WE_Asgn_3.Models
{
    public class Mobile
    {
        public int Id { get; set; }
        [Required]
        [ValidImei(ErrorMessage = "Please Enter a valid IMEI")]
        public string Imei { get; set; }

        public OprSys OprSys { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string ShortDate { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        [Display(Name = "Weight(g)")]
        public int GramWeight { get; set; }
        [Required]
        public string ModelNo { get; set; }
        [Required]
        [Display(Name = "RAM(GB)")]
        public int GbRam { get; set; }
        [Required]
        public int Price { get; set; }
    }
}