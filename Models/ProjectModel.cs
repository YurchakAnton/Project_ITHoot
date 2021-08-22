using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ITHoot.Models
{
    public class ProjectModel
    {
        [Key]
        public int IdProject { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Name of Project")]
        [Column(TypeName = "nvarchar(30)")]
        public string NameOfProject { get; set; }


        [MaxLength(60)]
        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Project Description")]
        [Column(TypeName = "nvarchar(60)")]
        public string ProjectDescription { get; set; }

        [Required(ErrorMessage = "Пусте поле!")]
        [DisplayName("Time of Project (month)")]
        public int TimeOfProject { get; set; }

        public List<ProgrammersAndProjects> ProgrammersModel { get; set; }
    }
}
