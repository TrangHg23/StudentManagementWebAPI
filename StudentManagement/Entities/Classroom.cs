using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Entities
{
    public class Classroom
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Tên lớp dài tối đa 50 ký tự")]
        public string Name { get; set; }
        [MinLength(5, ErrorMessage = "Mã lớp dài tối thiểu 5 ký tự")]
        public string Code {  get; set; }
        public int MaxStudent {  get; set; }
    }
}
