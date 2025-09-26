using EF_Teste.Data;
using EF_Teste.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Teste.Repository
{
    public class StudentCoursesRepository : IStudentCoursesRepository
    {
        private readonly SchoolContext _schoolContext;

        public StudentCoursesRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }


        public async Task Create(StudentCourses studentCourses)
        {
            await _schoolContext.StudentCourses.AddAsync(studentCourses);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task Delete(StudentCourses studentCourses)
        {
            _schoolContext.Remove(studentCourses);
            await _schoolContext.SaveChangesAsync();
        }

        public async Task<StudentCourses> Get(int studentId, int courseId)
        {
            var data = await _schoolContext.StudentCourses
                        .Include(x => x.Course)
                        .Include(x => x.Student)
                        .Where(w => w.StudentID == studentId && w.CourseID == courseId)
                        .FirstOrDefaultAsync();

            return data;
        }

        public async Task<List<StudentCourses>> GetAll()
        {
            var data = await _schoolContext.StudentCourses
            .Include(x => x.Course)
            .Include(x => x.Student)
            .ToListAsync();

            return data;
        }

        public async Task<StudentCourses>? GetByCourseId(int courseId)
        {
            var data = await _schoolContext.StudentCourses
                        .Include(x => x.Course)
                        .Include(x => x.Student)
                        .Where(w => w.Course!.Name!.ToLower().Contains(name.ToLower()))
                        .ToListAsync();

            return data;
        }

        public Task<List<StudentCourses>> GetByCourseName(string name)
        {
            var data = await _schoolContext.StudentCourses
            .Include(x => x.Course)
            .Include(x => x.Student)
            .Where(w => w.Course!.Name!.ToLower().Contains(name.ToLower()))
            .ToListAsync();

            return data;
        }

        public Task<StudentCourses>? GetByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<StudentCourses>> GetByStudentName(string name)
        {
            throw new NotImplementedException();
        }

        public Task Update(StudentCourses studentCourses)
        {
            throw new NotImplementedException();
        }

        Task<List<StudentCourses>> IStudentCoursesRepository.Get(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        Task<List<StudentCourses>>? IStudentCoursesRepository.GetByCourseId(int courseId)
        {
            throw new NotImplementedException();
        }

        Task<List<StudentCourses>>? IStudentCoursesRepository.GetByStudentId(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}
