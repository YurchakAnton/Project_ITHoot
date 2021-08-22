using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_ITHoot.Models
{
    public class ProgrammersAndProjects
    {
        /*[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }*/
        public int IdProgrammer { get; set; }

        [ForeignKey("IdProgrammer")]
        public virtual ProgrammerModel ProgrammersModel { get; set; }
        public int IdProject { get; set; }

        [ForeignKey("IdProject")]
        public virtual ProjectModel ProjectsModel { get; set; }
    }
}
