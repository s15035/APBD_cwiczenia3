using cwiczenia3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia3.DAL
{
    public class MockDbService : IDbService
    {
        private static ICollection<Student> _students = new List<Student>();

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student { IdStudent = 1, FirstName = "Wiktor", LastName = "Wrobel", IndexNumber = "s15035" },
                new Student { IdStudent = 2, FirstName = "Anna", LastName = "Manna", IndexNumber = "s81274" },
                new Student { IdStudent = 3, FirstName = "Maria", LastName = "Jakas", IndexNumber = "s47893" },
                new Student { IdStudent = 4, FirstName = "Tomcio", LastName = "Paluch", IndexNumber = "s64379" },
                new Student { IdStudent = 5, FirstName = "Janusz", LastName = "Cebka", IndexNumber = "s23097" }
            };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public Student GetStudent(int id)
        {
            var student = _students.Where(student => student.IdStudent == id);
            if (!student.Any()) return null;
            return student.ToList().First();
        }

        public void AddStudent(Student newStudent)
        {
            if (_students.Count(student => newStudent.IndexNumber == student.IndexNumber) > 0)
                throw new DataException($"Such student {newStudent.IndexNumber} already exist.");

            _students.Add(newStudent);
        }

        public void DeleteStudent(int id)
        {
            var student = _students.Where(student => student.IdStudent == id).ToList().First();
            _students.Remove(student);
        }
    }
}
