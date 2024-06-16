using System;

namespace arusha.Models
{
    public class University
    {
        public int UniversityId { get; set; }
        public int? ProgramId { get; set; }
        public string Name { get; set; } // Объявлено как не nullable
        public DateTime FoundedYear { get; set; }
        public string Location { get; set; } // Объявлено как не nullable
        public string Website { get; set; } // Объявлено как не nullable
        public string AccreditationStatus { get; set; } // Объявлено как не nullable


        // Конструктор по умолчанию
        public University()
        {
        }
    }
}
//l