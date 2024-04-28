using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dtos.Students
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
