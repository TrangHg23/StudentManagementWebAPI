using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dtos.Students
{
    public class CreateStudentDto
    {
        [StringLength(50, ErrorMessage = "Tên dài tối đa 50 ký tự")]
        public string Name { get; set; }
        public string Code { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
