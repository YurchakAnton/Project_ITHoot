using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ITHoot.Models
{
    public class CompanyModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Company")]
        [Column(TypeName = "nvarchar(30)")]
        public string NameOfCompany { get; set; }


        [MaxLength(60)]
        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Company Location")]
        [Column(TypeName = "nvarchar(60)")]
        public string CompanyLocation { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Activity")]
        [Column(TypeName = "nvarchar(20)")]
        public string ActivityOfCompany { get; set; }
    }
}
