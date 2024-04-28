using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.Students;
using StudentManagement.Entities;

namespace StudentManagement.Services.Abstract
{
    public interface IStudentService
    {
        Student CreateStudent(CreateStudentDto input);
        void UpdateStudent(int id, [FromBody] UpdateStudentDto student);
        void DeleteStudent(int id);
        List<Student> GetAllStudents();
        Student GetStudentById(int id);
    }
}
