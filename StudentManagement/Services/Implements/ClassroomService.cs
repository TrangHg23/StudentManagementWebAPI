using Microsoft.AspNetCore.Mvc;
using StudentManagement.DbContexts;
using StudentManagement.Dtos.Classrooms;
using StudentManagement.Dtos.Students;
using StudentManagement.Entities;
using StudentManagement.Exceptions;
using StudentManagement.Services.Abstract;

namespace StudentManagement.Services.Implements
{
    public class ClassroomService : IClassroomService
    {
        private readonly ApplicationDbContext _dbContext;
        public ClassroomService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddStudent(AddStudentToClassDto input)
        {
            foreach (var studentId in input.StudentIds)
            {
                _dbContext.Registers.Add(
                    new Register
                    {
                        ClassroomId = input.ClassroomId,
                        StudentId = studentId,
                    }
                );
                _dbContext.SaveChanges();
            }
        }

        public List<StudentDto> GetAllStudent(int classroomId)
        {
            var result =
                from studentClass in _dbContext.Registers
                join student in _dbContext.Students on studentClass.StudentId equals student.Id
                join classroom in _dbContext.Classrooms on studentClass.ClassroomId equals classroom.Id
                where studentClass.ClassroomId == classroomId
                select new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    Code = student.Code,
                    DateOfBirth = student.DateOfBirth,
                    //ClassroomName = classroom.Name
                };
            return result.ToList();
        }

        public Classroom CreateClassroom(CreateClassroomDto input)
        {

            var classroom = new Classroom
            {
                Name = input.Name,
                Code = input.Code,
                MaxStudent = input.MaxStudent,

            };
            _dbContext.Classrooms.Add(classroom);
            _dbContext.SaveChanges(); //auto-increment for Id
            return classroom;
        }

        public void DeleteClassroom(int id)
        {
            var findClassroom = _dbContext.Classrooms.FirstOrDefault(s => s.Id == id);
            if (findClassroom == null)
            {
                throw new UserFriendlyException($"Không tìm thấy lớp học có mã số {id}");
            }

            _dbContext.Classrooms.Remove(findClassroom);
            _dbContext.SaveChanges();
        }

        public List<Classroom> GetAllStudents()
        {
            return _dbContext.Classrooms.ToList();
        }

        public Classroom GetClassroomById(int id)
        {
            var findClassroom = _dbContext.Classrooms.FirstOrDefault(s => s.Id == id);
            if (findClassroom == null)
            {
                throw new UserFriendlyException($"Không tìm thấy lớp h có mã số {id}");
            }
            return findClassroom;

        }

        public void UpdateClassroom(int id, [FromBody] UpdateClassroomDto classroom)
        {
            var findClassroom = _dbContext.Classrooms.FirstOrDefault(s => s.Id == id);
            if (findClassroom == null)
            {
                throw new UserFriendlyException($"Không tìm thấy lớp học có mã số {id}");
            }
            else
            {
                findClassroom.Name = classroom.Name;
                findClassroom.Code = classroom.Code;
                findClassroom.MaxStudent = classroom.MaxStudent;
                _dbContext.SaveChanges();
            }
        }
    }
}
