using System.Collections.Generic;
using System.Reflection;
using arusha.Models;
using arusha.ViewModels;



namespace arusha.ViewModels
{
    public class StudentViewModel
    {
        public List<Student> Students { get; set; }
        public Gender? SelectedGender { get; set; }
    }
}
