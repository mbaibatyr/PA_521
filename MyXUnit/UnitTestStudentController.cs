using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using MyTest.Model;
using MyTest.Abstract;
using MyTest.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MyXUnit
{
    public class UnitTestStudentController
    {
        [Fact]
        public async Task GetById_WhenStudentExists_ReturnsOk()
        {
            // Arrange
            var mockRepo = new Mock<IStudent>();
            var testStudent = new Student(1, "Иван", 20);

            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(testStudent);

            var controller = new StudentController(mockRepo.Object);

            // Act
            var result = await controller.GetById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualStudent = Assert.IsType<Student>(okResult.Value);
            Assert.Equal("Иван", actualStudent.Name);
        }
    }
}
