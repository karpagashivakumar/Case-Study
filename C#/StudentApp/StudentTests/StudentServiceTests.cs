using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using StudentDAL;

namespace StudentTests
{
    [TestFixture]
    public class StudentServiceTests
    {
        private Mock<IStudentRepository> _mockRepo;
        private StudentService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IStudentRepository>();
            _service = new StudentService(_mockRepo.Object);
        }

        [Test]
        public void AddStudent_ShouldCallRepositoryAdd()
        {
            var student = new Student { RollNo = 1, Name = "Alice", Email = "alice@example.com" };

            _service.AddStudent(student);

            _mockRepo.Verify(r => r.Add(student), Times.Once);
        }

        [Test]
        public void GetAllStudents_ShouldReturnAllStudents()
        {
            var students = new List<Student>
            {
                new Student { RollNo = 1, Name = "Alice", Email = "alice@example.com" },
                new Student { RollNo = 2, Name = "Bob", Email = "bob@example.com" }
            };

            _mockRepo.Setup(r => r.GetAll()).Returns(students);

            var result = _service.GetAllStudents();

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void DeleteStudent_ShouldCallRepositoryDelete()
        {
            _service.DeleteStudent(1);

            _mockRepo.Verify(r => r.Delete(1), Times.Once);
        }

        [Test]
        public void UpdateStudent_ShouldCallRepositoryUpdate()
        {
            var student = new Student { RollNo = 1, Name = "Updated", Email = "update@example.com" };

            _service.UpdateStudent(student);

            _mockRepo.Verify(r => r.Update(student), Times.Once);
        }

        [Test]
        public void GetByRollNo_ShouldReturnCorrectStudent()
        {
            var student = new Student { RollNo = 1, Name = "Alice", Email = "alice@example.com" };
            _mockRepo.Setup(r => r.GetByRollNo(1)).Returns(student);

            var result = _service.GetStudentByRollNo(1);

            Assert.AreEqual("Alice", result.Name);
        }

        [Test]
        public void GetByName_ShouldReturnCorrectStudent()
        {
            var student = new Student { RollNo = 2, Name = "Bob", Email = "bob@example.com" };
            _mockRepo.Setup(r => r.GetByName("Bob")).Returns(student);

            var result = _service.GetStudentByName("Bob");

            Assert.AreEqual("Bob", result.Name);
        }
    }
}
