using Microsoft.AspNetCore.Mvc;
using StudentManagement.Dtos.Classrooms;
using StudentManagement.Dtos.Students;
using StudentManagement.Entities;

namespace StudentManagement.Services.Abstract
{
    public interface IClassroomService
    {
        void AddStudent(AddStudentToClassDto input);
        List<StudentDto> GetAllStudent(int classroomId);
        Classroom CreateClassroom(CreateClassroomDto input);
        void DeleteClassroom(int id);

        List<Classroom> GetAllStudents();
        Classroom GetClassroomById(int id);
        void UpdateClassroom(int id, [FromBody] UpdateClassroomDto classroom);

    }
}
