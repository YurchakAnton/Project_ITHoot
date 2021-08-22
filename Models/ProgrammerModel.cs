using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ITHoot.Models
{
    public class ProgrammerModel
    {

        [Key]
        public int IdProgrammer { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Full Name")]
        [Column(TypeName = "nvarchar(30)")]
        public string FullName { get; set; }


        [MaxLength(20)]
        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Position")]
        [Column(TypeName = "nvarchar(20)")]
        public string Position { get; set; }

        [MaxLength(20)]
        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Activity")]
        [Column(TypeName = "nvarchar(20)")]
        public string Activity { get; set; }

        public List<ProgrammersAndProjects> ProjectsModel { get; set; }
    }
}
