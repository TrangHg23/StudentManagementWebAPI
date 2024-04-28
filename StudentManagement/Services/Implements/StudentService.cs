using Microsoft.AspNetCore.Mvc;
using StudentManagement.DbContexts;
using StudentManagement.Dtos.Students;
using StudentManagement.Entities;
using StudentManagement.Exceptions;
using StudentManagement.Services.Abstract;

namespace StudentManagement.Services.Implements
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Student CreateStudent(CreateStudentDto input)
        {

            var student = new Student
            {
                Name = input.Name,
                Code = input.Code,
                DateOfBirth = input.DateOfBirth,

            };
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges(); //auto-increment for Id
            return student;
        }

        public void DeleteStudent(int id)
        {
            var findStudent = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (findStudent == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có mã số {id}");
            }

            _dbContext.Students.Remove(findStudent);
            _dbContext.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            var findStudent = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (findStudent == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có mã số {id}");
            }
            return findStudent;

        }

        public void UpdateStudent(int id, [FromBody] UpdateStudentDto student)
        {
            var findStudent = _dbContext.Students.FirstOrDefault(s => s.Id == id);
            if (findStudent == null)
            {
                throw new UserFriendlyException($"Không tìm thấy sinh viên có mã số {id}");
            }
            else
            {
                findStudent.Name = student.Name;
                findStudent.Code = student.Code;
                findStudent.DateOfBirth = student.DateOfBirth;
                _dbContext.SaveChanges();
            }
        }
    }
}
