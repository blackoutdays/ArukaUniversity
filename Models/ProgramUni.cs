using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arusha.Models
{
    public class ProgramUni
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProgramId { get; set; }

        [Required(ErrorMessage = "UniversityId is required")]
        public int UniversityId { get; set; }

        [Required(ErrorMessage = "AcademicDepartmentId is required")]
        public int AcademicDepartmentId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "StartDate is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDate is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        // Constructor
        public ProgramUni()
        {
        }
    }
}
