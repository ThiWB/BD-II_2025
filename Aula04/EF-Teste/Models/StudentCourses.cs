using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Teste.Models
{
    [PrimaryKey(nameof(StudentID), nameof(CourseID))]
    public class StudentCourses
    {        
        public int StudentID { get; set; }

        //Property Navigations - Representam entidades relacionadas à entidade principal. As chaves estrangeiras são geralmente representadas por propriedades de navegação.

        [ForeignKey(nameof(StudentID))]
        public Student? Student { get; set; }

        public int CourseID { get; set; }

        [ForeignKey(nameof(CourseID))]
        public Course? Course { get; set; }
    }
}
