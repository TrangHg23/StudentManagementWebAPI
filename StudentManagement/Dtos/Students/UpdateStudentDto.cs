using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dtos.Students
{
    public class UpdateStudentDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
