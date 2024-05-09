using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Dtos.Classrooms
{
    public class CreateClassroomDto
    {
            [StringLength(50, ErrorMessage = "Tên lớp dài tối đa 50 ký tự")]
            public string Name { get; set; }
            [MinLength(5, ErrorMessage = "Mã lớp dài tối thiểu 5 ký tự")]
            public string Code { get; set; }
            [Range(1, 50, ErrorMessage ="Lớp phải có tối thiểu 1 học sinh")]
            public int MaxStudent { get; set; }
        
    }

}
