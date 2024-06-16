using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace arusha.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [ForeignKey("ProgramUni")]
        public int? ProgramId { get; set; }

        [ForeignKey("Degree")]
        public int? DegreeId { get; set; }

        [Required(ErrorMessage = "Please enter full name")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please select country")]
        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please enter birth date")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please select gender")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter GPA")]
        [Display(Name = "GPA")]
        [Range(0, 4.0, ErrorMessage = "GPA must be between 0.0 and 4.0")]
        public decimal Gpa { get; set; }

        [Required(ErrorMessage = "Please enter major")]
        public string Major { get; set; }
        [NotMapped]
        public int Age
        {
            get
            {
                // Рассчитываем возраст на основе даты рождения
                if (BirthDate != DateTime.MinValue)
                {
                    var today = DateTime.Today;
                    var age = today.Year - BirthDate.Year;
                    if (BirthDate.Date > today.AddYears(-age)) age--; // Уменьшаем возраст, если день рождения еще не наступил в этом году
                    return age;
                }
                return 0;
            }
        }

        // Navigation properties
        public virtual ProgramUni ProgramUni { get; set; }
    }
}
