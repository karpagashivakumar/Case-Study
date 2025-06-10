using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDAL
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();

        public List<Student> GetAll() => _students;

        public Student GetByRollNo(int rollNo) => _students.FirstOrDefault(s => s.RollNo == rollNo);

        public Student GetByName(string name) => _students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        public void Add(Student student) => _students.Add(student);

        public void Update(Student student)
        {
            var existing = GetByRollNo(student.RollNo);
            if (existing != null)
            {
                existing.Name = student.Name;
                existing.Email = student.Email;
            }
        }

        public void Delete(int rollNo)
        {
            var student = GetByRollNo(rollNo);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }

}
